using Microsoft.AspNetCore.Components;
using System;

namespace WJ
{
    public class InputDateTime : InputDate
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.input.InputDateTime";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public DateTime? TimeMin
        {
            get =>GetProp<DateTime?>("timeMin");
            set =>SetProp("timeMin", value);
        }
        [Parameter]
        public DateTime? TimeMax
        {
            get =>GetProp<DateTime?>("timeMax");
            set =>SetProp("timeMax", value);
        }
        [Parameter]
        public string TimeFormat
        {
            get =>GetProp<string>("timeFormat");
            set =>SetProp("timeFormat", value);
        }
        [Parameter]
        public int TimeStep
        {
            get =>GetProp<int>("timeStep");
            set =>SetProp("timeStep", value);
        }

        #endregion
    }
}
