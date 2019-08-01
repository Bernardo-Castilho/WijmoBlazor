using Microsoft.AspNetCore.Components;

namespace WJ
{
    /// <summary>
    /// Range elements can be added to Gauge controls.
    /// </summary>
    public class Range : MarkupProperty
    {
        /////////////////////////////////////////////////////////
        #region initialize

        public Range() : base()
        {
            _className = "wijmo.gauge.Range";
            _propName = "ranges";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

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
        public double Value
        {
            get => GetProp<double>("value");
            set => SetProp("value", value);
        }
        [Parameter]
        public double Thickness
        {
            get => GetProp<double>("thickness");
            set => SetProp("thickness", value);
        }
        [Parameter]
        public string Color
        {
            get => GetProp<string>("color");
            set => SetProp("color", value);
        }
        [Parameter]
        public string Name
        {
            get => GetProp<string>("name");
            set => SetProp("name", value);
        }
        #endregion

    }
}
