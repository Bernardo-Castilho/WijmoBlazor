using Microsoft.AspNetCore.Components;
using System;

namespace WJ
{
    public class BulletGraph : LinearGauge
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.gauge.BulletGraph";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public double? Target
        {
            get =>GetProp<double?>("target");
            set =>SetProp("target", value);
        }
        [Parameter]
        public double? Good
        {
            get =>GetProp<double?>("good");
            set =>SetProp("good", value);
        }
        [Parameter]
        public double? Bad
        {
            get =>GetProp<double?>("bad");
            set =>SetProp("bad", value);
        }

        #endregion
    }
}
