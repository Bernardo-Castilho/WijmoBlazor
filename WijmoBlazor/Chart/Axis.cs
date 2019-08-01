using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace WJ
{
    public abstract class Axis : MarkupProperty
    {
        /////////////////////////////////////////////////////////
        #region initialize

        public Axis() : base()
        {
            _className = "wijmo.chart.Axis";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public bool AxisLine
        {
            get => GetProp<bool>("axisLine");
            set => SetProp("axisLine", value);
        }
        [Parameter]
        public string Binding
        {
            get => GetProp<string>("binding");
            set => SetProp("binding", value);
        }
        [Parameter]
        public string Format
        {
            get => GetProp<string>("format");
            set => SetProp("format", value);
        }
        [Parameter]
        public object ItemsSource
        {
            get => GetProp<JsonElement>("itemsSource");
            set => SetProp("itemsSource", value);
        }
        [Parameter]
        public string LabelAlign
        {
            get => GetProp<string>("labelAlign");
            set => SetProp("labelAlign", value);
        }
        [Parameter]
        public int LabelAngle
        {
            get => GetProp<int>("labelAngle");
            set => SetProp("labelAngle", value);
        }
        [Parameter]
        public int LabelPadding
        {
            get => GetProp<int>("labelPadding");
            set => SetProp("labelPadding", value);
        }
        [Parameter]
        public bool Labels
        {
            get => GetProp<bool>("labels");
            set => SetProp("labels", value);
        }
        [Parameter]
        public double LogBase
        {
            get => GetProp<double>("logBase");
            set => SetProp("logBase", value);
        }
        [Parameter]
        public bool MajorGrid
        {
            get => GetProp<bool>("majorGrid");
            set => SetProp("majorGrid", value);
        }
        [Parameter]
        public TickMark MajorTickMarks
        {
            get => GetProp<TickMark>("majorTickMarks");
            set => SetProp("majorTickMarks", value);
        }
        [Parameter]
        public double MajorUnit
        {
            get => GetProp<double>("majorUnit");
            set => SetProp("majorUnit", value);
        }
        [Parameter]
        public bool MinorGrid
        {
            get => GetProp<bool>("minorGrid");
            set => SetProp("minorGrid", value);
        }
        [Parameter]
        public TickMark MinorTickMarks
        {
            get => GetProp<TickMark>("minorTickMarks");
            set => SetProp("minorTickMarks", value);
        }
        [Parameter]
        public double MinorUnit
        {
            get => GetProp<double>("minorUnit");
            set => SetProp("minorUnit", value);
        }
        [Parameter]
        public object Max
        {
            get => GetProp<object>("max");
            set => SetProp("max", value);
        }
        [Parameter]
        public object Min
        {
            get => GetProp<object>("min");
            set => SetProp("min", value);
        }
        [Parameter]
        public string Name
        {
            get => GetProp<string>("name");
            set => SetProp("name", value);
        }
        [Parameter]
        public double Origin
        {
            get => GetProp<double>("origin");
            set => SetProp("origin", value);
        }
        [Parameter]
        public OverlappingLabels OverlappingLabels
        {
            get => GetProp<OverlappingLabels>("overlappingLabels");
            set => SetProp("overlappingLabels", value);
        }
        [Parameter]
        public bool Reversed
        {
            get => GetProp<bool>("reversed");
            set => SetProp("reversed", value);
        }
        [Parameter]
        public string Title
        {
            get => GetProp<string>("title");
            set => SetProp("title", value);
        }
        #endregion

    }
}
