using Microsoft.AspNetCore.Components;
using System;

namespace WJ
{
    public enum NeedleShape
    {
        None,
        Triangle,
        Diamond,
        Hexagon,
        Rectangle,
        Arrow,
        WideArrow,
        Pointer,
        WidePointer,
        Outer
    };
    public enum NeedleLength
    {
        Outer,
        Middle,
        Inner
    };

    public class RadialGauge : Gauge
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.gauge.RadialGauge";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public double StartAngle
        {
            get =>GetProp<double>("startAngle");
            set =>SetProp("startAngle", value);
        }
        [Parameter]
        public double SweepAngle
        {
            get =>GetProp<double>("sweepAngle");
            set =>SetProp("sweepAngle", value);
        }
        [Parameter]
        public bool AutoScale
        {
            get =>GetProp<bool>("autoScale");
            set =>SetProp("autoScale", value);
        }
        [Parameter]
        public NeedleShape NeedleShape
        {
            get =>GetProp<NeedleShape>("needleShape");
            set =>SetProp("needleShape", value);
        }
        [Parameter]
        public NeedleLength NeedleLength
        {
            get =>GetProp<NeedleLength>("needleLength");
            set =>SetProp("needleLength", value);
        }

        #endregion
    }
}
