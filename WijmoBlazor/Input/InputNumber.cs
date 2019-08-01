using Microsoft.AspNetCore.Components;
using System;

namespace WJ
{
    public class InputNumber : Control
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.input.InputNumber";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public double? Value
        {
            get =>GetProp<double?>("value");
            set =>SetProp("value", value);
        }
        [Parameter]
        public double? Min
        {
            get =>GetProp<double?>("min");
            set =>SetProp("min", value);
        }
        [Parameter]
        public double? Max
        {
            get =>GetProp<double?>("max");
            set =>SetProp("max", value);
        }
        [Parameter]
        public double Step
        {
            get =>GetProp<double>("step");
            set =>SetProp("step", value);
        }
        [Parameter]
        public string Format
        {
            get =>GetProp<string>("format");
            set =>SetProp("format", value);
        }
        [Parameter]
        public string Text
        {
            get =>GetProp<string>("text");
            set =>SetProp("text", value);
        }
        [Parameter]
        public bool ShowSpinner
        {
            get =>GetProp<bool>("showSpinner");
            set =>SetProp("showSpinner", value);
        }
        [Parameter]
        public bool RepeatButtons
        {
            get =>GetProp<bool>("repeatButtons");
            set =>SetProp("repeatButtons", value);
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
        public Action<InputNumber> ValueChanged { get; set; }
        [Parameter]
        public Action<InputNumber> TextChanged { get; set; }

        override protected string RaiseEvent(string name, string args)
        {
            switch (name)
            {
                case "valueChanged":
                    ValueChanged?.Invoke(this);
                    return string.Empty;
                case "textChanged":
                    TextChanged?.Invoke(this);
                    return string.Empty;
            }

            // not our event, allow base class
            return base.RaiseEvent(name, args);
        }
        #endregion
    }
}
