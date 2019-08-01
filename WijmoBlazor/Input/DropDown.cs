using Microsoft.AspNetCore.Components;
using System;
using System.Text.Json;

namespace WJ
{
    public abstract class DropDown : Control
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.input.DropDown";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public string Text
        {
            get =>GetProp<string>("text");
            set =>SetProp("text", value);
        }
        [Parameter]
        public bool IsReadOnly
        {
            get =>GetProp<bool>("isReadOnly");
            set =>SetProp("isReadOnly", value);
        }
        [Parameter]
        public bool IsRequired
        {
            get =>GetProp<bool>("isRequired");
            set =>SetProp("isRequired", value);
        }
        [Parameter]
        public string Placeholder
        {
            get =>GetProp<string>("placeholder");
            set =>SetProp("placeholder", value);
        }
        [Parameter]
        public bool IsDroppedDown
        {
            get =>GetProp<bool>("isDroppedDown");
            set =>SetProp("isDroppedDown", value);
        }
        [Parameter]
        public string DropDownCssClass
        {
            get =>GetProp<string>("dropDownCssClass");
            set =>SetProp("dropDownCssClass", value);
        }
        [Parameter]
        public bool ShowDropDownButton
        {
            get =>GetProp<bool>("showDropDownButton");
            set =>SetProp("showDropDownButton", value);
        }
        [Parameter]
        public bool AutoExpandSelection
        {
            get =>GetProp<bool>("autoExpandSelection");
            set =>SetProp("autoExpandSelection", value);
        }
        [Parameter]
        public bool IsAnimated
        {
            get =>GetProp<bool>("isAnimated");
            set =>SetProp("isAnimated", value);
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region methods

        public void SelectAll()
        {
            Invoke<bool>("selectAll");
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region events

        [Parameter]
        public Action<DropDown> TextChanged { get; set; }
        [Parameter]
        public Action<DropDown, CancelEventArgs> IsDroppedDownChanging { get; set; }
        [Parameter]
        public Action<DropDown> IsDroppedDownChanged { get; set; }

        override protected string RaiseEvent(string name, string args)
        {
            switch (name)
            {
                case "textChanged":
                    TextChanged?.Invoke(this);
                    return string.Empty;
                case "isDroppedDownChanging":
                    if (IsDroppedDownChanging != null)
                    {
                        var e = JsonSerializer.Deserialize<CancelEventArgs>(args);
                        IsDroppedDownChanging.Invoke(this, e);
                        return JsonSerializer.Serialize(e);
                    }
                    return string.Empty;
                case "isDroppedDownChanged":
                    IsDroppedDownChanged?.Invoke(this);
                    return string.Empty;
            }

            // not our event, allow base class
            return base.RaiseEvent(name, args);
        }
        #endregion
    }
}
