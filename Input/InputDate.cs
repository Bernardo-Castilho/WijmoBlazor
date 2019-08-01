using Microsoft.AspNetCore.Components;
using System;

namespace WJ
{
    public enum DateSelectionMode
    {
        None,
        Day,
        Month
    };

    public class InputDate : DropDown
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.input.InputDate";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public DateTime? Value
        {
            get =>GetProp<DateTime?>("value");
            set =>SetProp("value", value);
        }
        [Parameter]
        public DateSelectionMode SelectionMode

        {
            get =>GetProp<DateSelectionMode>("selectionMode");
            set =>SetProp("selectionMode", value);
        }
        [Parameter]
        public DateTime? Min
        {
            get =>GetProp<DateTime?>("min");
            set =>SetProp("min", value);
        }
        [Parameter]
        public DateTime? Max
        {
            get =>GetProp<DateTime?>("max");
            set =>SetProp("max", value);
        }
        [Parameter]
        public bool RepeatButtons
        {
            get =>GetProp<bool>("repeatButtons");
            set =>SetProp("repeatButtons", value);
        }
        [Parameter]
        public bool ShowYearPicker
        {
            get =>GetProp<bool>("showYearPicker");
            set =>SetProp("showYearPicker", value);
        }
        [Parameter]
        public string Format
        {
            get =>GetProp<string>("format");
            set =>SetProp("format", value);
        }
        [Parameter]
        public string Mask
        {
            get =>GetProp<string>("mask");
            set =>SetProp("mask", value);
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region events

        [Parameter]
        public Action<InputDate> ValueChanged { get; set; }

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
