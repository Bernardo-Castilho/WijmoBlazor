using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace WJ
{
    public class Series : MarkupProperty
    {
        /////////////////////////////////////////////////////////
        #region initialize

        public Series() : base()
        {
            _className = "wijmo.chart.Series";
            _propName = "series";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public string Name
        {
            get => GetProp<string>("name");
            set => SetProp("name", value);
        }
        [Parameter]
        public string Binding
        {
            get => GetProp<string>("binding");
            set => SetProp("binding", value);
        }
        [Parameter]
        public string BindingX
        {
            get => GetProp<string>("bindingX");
            set => SetProp("bindingX", value);
        }
        [Parameter]
        public ChartType ChartType
        {
            get => GetProp<ChartType>("chartType");
            set => SetProp("chartType", value);
        }
        [Parameter]
        public string CssClass
        {
            get => GetProp<string>("cssClass");
            set => SetProp("cssClass", value);
        }
        [Parameter]
        public object ItemsSource
        {
            get => GetProp<JsonElement>("itemsSource");
            set => SetProp("itemsSource", value);
        }
        [Parameter]
        public Marker SymbolMarker
        {
            get => GetProp<Marker>("symbolMarker");
            set => SetProp("symbolMarker", value);
        }
        [Parameter]
        public int SymbolSize
        {
            get => GetProp<int>("symbolSize");
            set => SetProp("symbolSize", value);
        }
        [Parameter]
        public SeriesVisibility Visibility
        {
            get => GetProp<SeriesVisibility>("visibility");
            set => SetProp("visibility", value);
        }
        [Parameter]
        public string TooltipContent
        {
            get => GetProp<string>("tooltip.content");
            set => SetProp("tooltip.content", value);
        }
        [Parameter]
        public string Style
        {
            get => GetProp<string>("style");
            set => SetProp("style", value);
        }
        [Parameter]
        public string AltStyle
        {
            get => GetProp<string>("altStyle");
            set => SetProp("altStyle", value);
        }

        #endregion

    }
}
