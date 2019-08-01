using Microsoft.AspNetCore.Components;
using System;

namespace WJ
{
    public class InputColor : DropDown
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.input.InputColor";
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
        public bool ShowAlphaChannel
        {
            get =>GetProp<bool>("showAlphaChannel");
            set =>SetProp("showAlphaChannel", value);
        }
        [Parameter]
        public string[] Palette
        {
            get =>GetProp<string[]>("palette");
            set =>SetProp("palette", value);
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region events

        [Parameter]
        public Action<InputColor> ValueChanged { get; set; }

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
