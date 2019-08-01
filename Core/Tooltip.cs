using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace WJ
{
    public class Tooltip : WijmoObject
    {
        /////////////////////////////////////////////////////////
        #region initialize
        protected override void Initialize()
        {
            _jsRef = Invoke<string>("initTooltip", _host, _props);
        }

        public override Task SetParametersAsync(ParameterCollection parameters)
        {
            var task = base.SetParametersAsync(parameters);
            if (_initialized)
            {
                Invoke<string>("initTooltip", _host, _props, _jsRef); // in case ChildContent/CssClass have changed
            }
            return task;
        }
        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public bool IsContentHtml
        {
            get => GetProp<bool>("isContentHtml");
            set => SetProp("isContentHtml", value);
        }
        [Parameter]
        public string CssClass
        {
            get => GetProp<string>("cssClass");
            set => SetProp("cssClass", value);
        }
        [Parameter]
        public double Gap
        {
            get => GetProp<double>("gap");
            set => SetProp("gap", value);
        }
        [Parameter]
        public bool ShowAtMouse
        {
            get => GetProp<bool>("showAtMouse");
            set => SetProp("showAtMouse", value);
        }
        [Parameter]
        public double ShowDelay
        {
            get => GetProp<double>("showDelay");
            set => SetProp("showDelay", value);
        }
        [Parameter]
        public double HideDelay
        {
            get => GetProp<double>("hideDelay");
            set => SetProp("hideDelay", value);
        }
        #endregion
    }
}
