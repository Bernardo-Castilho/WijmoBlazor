using Microsoft.AspNetCore.Components;
using System;

namespace WJ
{
    public class InputMask : Control
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.input.InputMask";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public string Value
        {
            get =>GetProp<string>("value");
            set =>SetProp("value", value);
        }
        [Parameter]
        public string RawValue
        {
            get =>GetProp<string>("rawValue");
            set =>SetProp("rawValue", value);
        }
        [Parameter]
        public string Mask
        {
            get =>GetProp<string>("mask");
            set =>SetProp("mask", value);
        }
        [Parameter]
        public string PromptChar
        {
            get =>GetProp<string>("promptChar");
            set =>SetProp("promptChar", value);
        }
        [Parameter]
        public string Placeholder
        {
            get =>GetProp<string>("placeholder");
            set =>SetProp("placeholder", value);
        }
        [Parameter]
        public bool IsRequired
        {
            get =>GetProp<bool>("isRequired");
            set =>SetProp("isRequired", value);
        }
        [Parameter]
        public bool IsReadOnly
        {
            get =>GetProp<bool>("isReadOnly");
            set =>SetProp("isReadOnly", value);
        }
        // [Parameter] read-only prop, not Parameter
        public bool IsMaskFull
        {
            get =>GetProp<bool>("maskFull");
        }


        #endregion

        /////////////////////////////////////////////////////////
        #region events

        [Parameter]
        public Action<InputMask> ValueChanged { get; set; }

        override protected string RaiseEvent(string name, string args)
        {
            switch (name)
            {
                case "valueChanged":
                    ValueChanged?.Invoke(this);
                    return string.Empty;
            }

            // not our event, allow base class
            return base.RaiseEvent(name, args);
        }
        #endregion
    }
}
