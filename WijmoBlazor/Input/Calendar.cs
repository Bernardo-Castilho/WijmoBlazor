using Microsoft.AspNetCore.Components;
using System;

namespace WJ
{
    public class Calendar : Control
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.input.Calendar";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public DateTime? Value
        {
            //get =>Convert.ToDateTime(_GetProp<string>("value"));
            get =>GetProp<DateTime?>("value");
            set =>SetProp("value", value);
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region events

        [Parameter]
        public Action<Calendar> ValueChanged { get; set; }

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
