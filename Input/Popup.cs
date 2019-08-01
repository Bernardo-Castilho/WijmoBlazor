using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace WJ
{
    public enum PopupTrigger
    {
        /** No triggers; popups must be shown and hidden using code. */
        None = 0,
        /** Show or hide the popup when the owner element is clicked. */
        Click = 1,
        /** Hide the popup when it loses focus. */
        Blur = 2,
        /** Show or hide the popup when the owner element is clicked, hide when it loses focus. */
        ClickOrBlur = Click | Blur
    }

    public class Popup : Control
    {
        // to handle popup.Show(modal, callback)
        Action<object> _handleResult;

        // to handle await ShowAsync()
        TaskCompletionSource<object> _tcs;

        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.input.Popup";
            SetProp("removeOnHide", false); // required in Razor
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public PopupTrigger ShowTrigger
        {
            get => GetProp<PopupTrigger>("showTrigger");
            set => SetProp("showTrigger", value);
        }
        [Parameter]
        public PopupTrigger HideTrigger
        {
            get => GetProp<PopupTrigger>("hideTrigger");
            set => SetProp("hideTrigger", value);
        }
        [Parameter]
        public bool FadeIn
        {
            get => GetProp<bool>("fadeIn");
            set => SetProp("fadeIn", value);
        }
        [Parameter]
        public bool FadeOut
        {
            get => GetProp<bool>("fadeOut");
            set => SetProp("fadeOut", value);
        }
        [Parameter]
        public bool Modal
        {
            get => GetProp<bool>("modal");
            set => SetProp("modal", value);
        }
        [Parameter]
        public bool IsDraggable
        {
            get => GetProp<bool>("isDraggable");
            set => SetProp("isDraggable", value);
        }
        [Parameter]
        public bool IsResizable
        {
            get => GetProp<bool>("isResizable");
            set => SetProp("isResizable", value);
        }
        [Parameter]
        public object DialogResult
        {
            get => GetProp<object>("dialogResult");
            set => SetProp("dialogResult", value);
        }
        [Parameter]
        public object DialogResultEnter
        {
            get => GetProp<object>("dialogResultEnter");
            set => SetProp("dialogResultEnter", value);
        }
        // [Parameter] read-only prop
        public bool IsVisible
        {
            get => GetProp<bool>("isVisible");
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region methods

        public void Show(bool? modal = null, Action<object> handleResult = null)
        {
            // handle callbacks from Show(modal, callback)
            _handleResult = handleResult;
            if (handleResult == null)
            {
                Call<bool>("show", modal);
            }
            else
            {
                var netRef = DotNetObjectRef.Create(this);
                Invoke<object>("showPopupWithCallback", netRef, _jsRef, true);
            }
        }
        public void Hide(object dialogResult = null)
        {
            Call<bool>("hide", dialogResult);
        }
        public async Task<object> ShowAsync()
        {
            var netRef = DotNetObjectRef.Create(this);
            Invoke<object>("showPopupWithCallback", netRef, _jsRef, true);
            _tcs = new TaskCompletionSource<object>();
            return await _tcs.Task;
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region events

        [JSInvokable]
        public void _PopupCallback(object result)
        {
            if (_handleResult != null) // handle popup.Show(modal, callback)
            {
                _handleResult.Invoke(result);
                _handleResult = null;
            }
            if (_tcs != null) // handle await x = popup.Show(modal);
            {
                _tcs.SetResult(result);
                _tcs = null;
            }
        }

        [Parameter]
        public Action<Popup, CancelEventArgs> Showing { get; set; }
        [Parameter]
        public Action<Popup> Shown { get; set; }
        [Parameter]
        public Action<Popup, CancelEventArgs> Hiding { get; set; }
        [Parameter]
        public Action<Popup> Hidden { get; set; }

        override protected string RaiseEvent(string name, string args)
        {
            switch (name)
            {
                case "showing":
                    if (Showing != null)
                    {
                        var e = JsonSerializer.Deserialize<CancelEventArgs>(args);
                        Showing?.Invoke(this, e);
                        return JsonSerializer.Serialize(e);
                    }
                    return string.Empty;
                case "shown":
                    Shown?.Invoke(this);
                    return string.Empty;
                case "hiding":
                    if (Hiding != null)
                    {
                        var e = JsonSerializer.Deserialize<CancelEventArgs>(args);
                        Hiding.Invoke(this, e);
                        return JsonSerializer.Serialize(e);
                    }
                    return string.Empty;
                case "hidden":
                    Hidden?.Invoke(this);
                    return string.Empty;
            }

            // not our event, allow base class
            return base.RaiseEvent(name, args);
        }
        #endregion
    }
}
