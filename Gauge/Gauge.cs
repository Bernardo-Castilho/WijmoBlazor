using Microsoft.AspNetCore.Components;
using System;

namespace WJ
{
    public enum ShowText
    {
        None,
        Value,
        MinMax,
        All
    }
    public abstract class Gauge : Control
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.gauge.Gauge";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public double? Value
        {
            get => GetProp<double?>("value");
            set => SetProp("value", value);
        }
        [Parameter]
        public double Min
        {
            get => GetProp<double>("min");
            set => SetProp("min", value);
        }
        [Parameter]
        public double Max
        {
            get => GetProp<double>("max");
            set => SetProp("max", value);
        }
        [Parameter]
        public double Step
        {
            get => GetProp<double>("step");
            set => SetProp("step", value);
        }
        [Parameter]
        public bool IsReadOnly
        {
            get => GetProp<bool>("isReadOnly");
            set => SetProp("isReadOnly", value);
        }
        [Parameter]
        public bool IsAnimated
        {
            get => GetProp<bool>("isAnimated");
            set => SetProp("isAnimated", value);
        }
        [Parameter]
        public ShowText ShowText
        {
            get => GetProp<ShowText>("showText");
            set => SetProp("showText", value);
        }
        [Parameter]
        public bool ShowRanges
        {
            get => GetProp<bool>("showRanges");
            set => SetProp("showRanges", value);
        }
        [Parameter]
        public bool StackRanges
        {
            get => GetProp<bool>("stackRanges");
            set => SetProp("stackRanges", value);
        }
        [Parameter]
        public bool ShowTicks
        {
            get => GetProp<bool>("showTicks");
            set => SetProp("showTicks", value);
        }
        [Parameter]
        public bool ShowTickText
        {
            get => GetProp<bool>("showTickText");
            set => SetProp("showTickText", value);
        }
        [Parameter]
        public double? TickSpacing
        {
            get => GetProp<double?>("tickSpacing");
            set => SetProp("tickSpacing", value);
        }
        [Parameter]
        public double? ThumbSize
        {
            get => GetProp<double?>("thumbSize");
            set => SetProp("thumbSize", value);
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region events

        [Parameter]
        public Action<Gauge> ValueChanged { get; set; }

        override protected string RaiseEvent(string name, string args)
        {
            switch (name)
            {
                case "valueChanged":
                    return RaiseEvent<Gauge>(ValueChanged);
            }

            // not our event, allow base class
            return base.RaiseEvent(name, args);
        }
        #endregion
    }
}
