using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace WJ
{
    /// <summary>
    /// Base class for markup properties such as Gauge.Range, FlexGrid.Column,
    /// and FlexChart.Series.
    /// </summary>
    public abstract class MarkupProperty : WijmoObject
    {
        protected string _propName; // name of the property in the parent control

        protected override void Initialize()
        {
            var netRef = DotNetObjectRef.Create(this);
            var events = GetEventNames();
            _jsRef = Invoke<string>("initMarkupProperty", netRef, _host, _propName, _className, _props, events);
        }
    }
}
