using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace WJ
{
    public enum ChartType
    {
        Column,
        Bar,
        Scatter,
        Line,
        LineSymbols,
        Area,
        Bubble,
        Candlestick,
        HighLowOpenClose,
        Spline,
        SplineSymbols,
        SplineArea,
        Funnel
    }
    public enum Stacking
    {
        None,
        Stacked,
        Stacked100pc
    }
    public enum Marker
    {
        Dot,
        Box
    }
    public enum SeriesVisibility
    {
        Visible,
        Plot,
        Legend,
        Hidden
    }

    public enum TickMark
    {
        None,
        Outside,
        Inside,
        Cross
    }
    public enum OverlappingLabels
    {
        Auto,
        Show
    }
    public enum Orientation
    {
        Auto,
        Vertical,
        Horizontal
    }
    public enum Position
    {
        None,
        Left,
        Top,
        Right,
        Bottom,
        Auto
    }

    public class FlexChart : Control
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.chart.FlexChart";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public object ItemsSource
        {
            get => GetProp<JsonElement>("itemsSource");
            set => SetProp("itemsSource", value);
        }
        [Parameter]
        public ChartType ChartType
        {
            get => GetProp<ChartType>("chartType");
            set => SetProp("chartType", value);
        }
        [Parameter]
        public string BindingX
        {
            get => GetProp<string>("bindingX");
            set => SetProp("bindingX", value);
        }
        [Parameter]
        public string TooltipContent
        {
            get => GetProp<string>("tooltip.content");
            set => SetProp("tooltip.content", value); // REVIEW: works only from the cache
        }
        [Parameter]
        public Stacking Stacking
        {
            get => GetProp<Stacking>("stacking");
            set => SetProp("stacking", value);
        }
        [Parameter]
        public int SymbolSize
        {
            get => GetProp<int>("symbolSize");
            set => SetProp("symbolSize", value);
        }
        [Parameter]
        public bool LegendToggle
        {
            get => GetProp<bool>("legendToggle");
            set => SetProp("legendToggle", value);
        }
        [Parameter]
        public string Header
        {
            get => GetProp<string>("header");
            set => SetProp("header", value);
        }
        [Parameter]
        public string Footer
        {
            get => GetProp<string>("footer");
            set => SetProp("footer", value);
        }

        #endregion
    }
}