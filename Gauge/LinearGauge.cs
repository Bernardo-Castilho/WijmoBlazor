using Microsoft.AspNetCore.Components;
using System;

namespace WJ
{
    public enum GaugeDirection
    {
        Right,
        Left,
        Up,
        Down
    };

    public class LinearGauge : Gauge
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.gauge.LinearGauge";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public GaugeDirection Direction
        {
            get =>GetProp<GaugeDirection>("direction");
            set =>SetProp("direction", value);
        }

        #endregion
    }
}
