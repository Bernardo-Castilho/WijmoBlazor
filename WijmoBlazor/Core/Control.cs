using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;

namespace WJ
{
    /// <summary>
    /// Base class for Wijmo controls.
    /// </summary>
    public abstract class Control : WijmoObject
    {
        /////////////////////////////////////////////////////////
        ///
        #region overrides
        protected override void Initialize()
        {
            var netRef = DotNetObjectRef.Create(this);
            var events = GetEventNames();
            _jsRef = Invoke<string>("initControl", netRef, _host, _className, _props, events);
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region methods

        public bool Focus()
        {
            return Call<bool>("focus");
        }
        public bool ContainsFocus()
        {
            return Call<bool>("containsFocus");
        }
        public void Invalidate(bool fullUpdate = false)
        {
            Call<object>("invalidate", fullUpdate);
        }
        public void Refresh(bool fullUpdate = false)
        {
            Call<object>("refresh", fullUpdate);
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public string Class
        {
            get => _props["class"] as string;
            set => _props["class"] = value;
        }
        [Parameter]
        public bool IsDisabled
        {
            get => GetProp<bool>("isDisabled");
            set => SetProp("isDisabled", value);
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region events

        // events
        [Parameter]
        public Action<Control> GotFocus { get; set; }
        [Parameter]
        public Action<Control> LostFocus { get; set; }
        [Parameter]
        public Action<Control> Refreshing { get; set; }
        [Parameter]
        public Action<Control> Refreshed { get; set; }

        protected override string RaiseEvent(string name, string args)
        {
            switch (name)
            {
                case "gotFocus":
                    return RaiseEvent<Control>(GotFocus);
                case "lostFocus":
                    return RaiseEvent<Control>(LostFocus);
                case "refreshing":
                    return RaiseEvent<Control>(Refreshing);
                case "refreshed":
                    return RaiseEvent<Control>(Refreshed);
            }

            // not our event, allow base class
            return base.RaiseEvent(name, args);
        }
        #endregion
    }
}
