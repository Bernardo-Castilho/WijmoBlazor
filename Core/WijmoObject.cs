using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace WJ
{
    /// <summary>
    /// Base class for controls that may contain child elements
    /// (for example grid columns, chart series, gauge ranges).
    /// </summary>
    public abstract class WijmoObject : ComponentBase, IDisposable
    {
        protected ElementRef _host; // object's host element
        protected string _className; // object's full class name
        protected Dictionary<string, object> _props = new Dictionary<string, object>(); // object properties
        protected bool _initialized; // initialization flag
        protected string _jsRef; // key into JS object map

        [Inject]
        private IComponentContext ComponentContext { get; set; }

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "div");
            builder.AddElementReferenceCapture(1, r => _host = r);
            builder.AddContent(2, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        private RenderFragment ChildContent { get; set; }

        // check whether we can invoke JS synchronously
        protected bool InvokeSyncSupported()
        {
            return ComponentContext.IsConnected && JSRuntime is IJSInProcessRuntime;
        }

        // invoke wijmoBlazor method
        protected T Invoke<T>(string method, params object[] args)
        {
            // can't call JavaScript until connected.
            // https://docs.microsoft.com/en-us/aspnet/core/blazor/javascript-interop?view=aspnetcore-3.0#detect-when-a-blazor-app-is-prerendering
            if (!ComponentContext.IsConnected)
            {
                return default(T);
            }

            method = "wijmoBlazor." + method;
            var rt = JSRuntime as IJSInProcessRuntime;
            if (rt != null)
            {
                // use synchronous calls if possible (client-side Blazor, return value OK)
                // invoke JSRuntime synchronously by downcasting it to IJSInProcessRuntime:
                // https://blog.logrocket.com/working-with-the-blazor-javascript-interop-3c2a8d0eb56c
                return rt.Invoke<T>(method, args);
            }
            else
            {
                // REVIEW: return value is useless here
                JSRuntime.InvokeAsync<T>(method, args);
                return default(T);
            }
        }

        // invoke control method
        protected T Call<T>(string method, params object[] args)
        {
            return Invoke<T>("call", _jsRef, method, args);
        }

        // get/set props
        protected T GetProp<T>(string name)
        {
            if (InvokeSyncSupported() && _jsRef != null)
            {
                T value = Invoke<T>("getProp", _jsRef, name);
                _props[name] = value;
                return value;
            }
            else
            {
                object value;
                _props.TryGetValue(name, out value);
                return (T)value;
            }
        }
        protected void SetProp(string name, object value)
        {
            // convert WijmoObject values into JSRef strings
            var obj = value as WijmoObject;
            if (obj != null && obj._jsRef != null)
            {
                //Console.WriteLine("replacing {0} with {1}", value, obj._jsRef);////
                value = obj._jsRef;
            }

            object oldVal;
            if (_props.TryGetValue(name, out oldVal) && object.Equals(value, oldVal))
            {
                // same value, don't set again
                // this avoids refreshing CollectionViews on clicks
            }
            else
            {
                _props[name] = value;
                if (_jsRef != null)
                {
                    Invoke<object>("setProp", _jsRef, name, value);
                }
            }
        }

        // build a list of the events that have handlers attached to them
        // only these will be invoked, this is a huge perf gain
        // NOTE: events must be public!
        protected virtual List<string> GetEventNames()
        {
            var eventNames = new List<string>();
            foreach (PropertyInfo pi in this.GetType().GetProperties())
            {
                var type = pi.PropertyType;
                if (type.IsGenericType)
                {
                    var def = type.GetGenericTypeDefinition();
                    if (def == typeof(Action<>) || def == typeof(Action<,>)) // sender[, args]
                    {
                        var action = pi.GetValue(this);
                        if (action != null)
                        {
                            var camelCase = char.ToLower(pi.Name[0]) + pi.Name.Substring(1);
                            eventNames.Add(camelCase);
                        }
                    }
                }
            }
            return eventNames;
        }

        // update props with new parameter values (skipping actions and other problematic types)
        public override Task SetParametersAsync(ParameterCollection parameters)
        {
            foreach (Parameter p in parameters)
            {
                var value = p.Value;
                if (value == null || value is string || value is DateTime || value.GetType().IsPrimitive)
                {
                    var name = char.ToLower(p.Name[0]) + p.Name.Substring(1);
                    SetProp(name, value);
                }
            }
            return base.SetParametersAsync(parameters);
        }

        protected abstract void Initialize();

        // Invoked after each render of the component.
        // Called for the first time when the component is initialized and then after 
        // every re-render.
        protected override void OnAfterRender()
        {
            //Console.WriteLine("OnAfterRender, _initialized: {0}", _initialized);
            if (!_initialized) // do this only once
            {
                _initialized = true;
                Initialize();
            }
        }

        // dispose of the object (WijmoObject is IDisposable)
        public void Dispose()
        {
            Invoke<bool>("dispose", _jsRef);
        }

        [JSInvokable]
        public string InvokeRaiseEvent(string name, string args)
        {
            // raise the event, get updated args (e.g. e.cancel = true)
            args = RaiseEvent(name, args);

            // return the (possibly changed) event arguments
            return args;
        }

        /// <summary>
        /// Raises an event on the control.
        /// </summary>
        /// <param name="name">Event name (JS camel-case).</param>
        /// <param name="args">JSON string with the event parameters.</param>
        /// <returns>
        /// A JSON string with the (possibly modified) event arguments 
        /// or null to indicate the event was not handled and allow classes 
        /// further up in the hierarchy to handle it.
        /// </returns>
        protected virtual string RaiseEvent(string name, string args)
        {
            throw new Exception("Unknown event: " + name);
        }

        // shorthand
        protected string RaiseEvent<T>(Action<T> action)
            where T : WijmoObject
        {
            action?.Invoke(this as T);
            return string.Empty;
        }
        protected string RaiseEvent<T, A>(Action<T, A> action, string args)
            where T : WijmoObject
            where A : class
        {
            if (action != null)
            {
                var e = JsonSerializer.Deserialize<A>(args);
                action.Invoke(this as T, e as A);
                if (e is CancelEventArgs)
                {
                    return JsonSerializer.Serialize(e); // to allow canceling the event
                }
            }
            return string.Empty;
        }
        protected string RaiseCancelableEvent<T, A>(Action<T, A> action, string args) 
            where T : WijmoObject
            where A : CancelEventArgs
        {
            if (action != null)
            {
                var e = JsonSerializer.Deserialize<A>(args);
                action.Invoke(this as T, e as A);
                return JsonSerializer.Serialize(e); // to allow canceling the event
            }
            return string.Empty;
        }

    }
}
