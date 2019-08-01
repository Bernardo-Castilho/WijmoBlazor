using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace WJ
{
    public class Legend : MarkupProperty
    {
        /////////////////////////////////////////////////////////
        #region initialize

        public Legend() : base()
        {
            _className = "wijmo.chart.Legend";
            _propName = "legend";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public Orientation Orientation
        {
            get => GetProp<Orientation>("orientation");
            set => SetProp("orientation", value);
        }
        [Parameter]
        public Position Position
        {
            get => GetProp<Position>("position");
            set => SetProp("position", value);
        }
        [Parameter]
        public string Title
        {
            get => GetProp<string>("title");
            set => SetProp("title", value);
        }
        [Parameter]
        public string TitleAlign
        {
            get => GetProp<string>("titleAlign");
            set => SetProp("titleAlign", value);
        }
        #endregion
    }
}
