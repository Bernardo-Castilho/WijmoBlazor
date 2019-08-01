using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace WJ
{
    public class Column : MarkupProperty
    {
        /////////////////////////////////////////////////////////
        #region initialize

        public Column(): base()
        {
            _className = "wijmo.grid.Column";
            _propName = "columns";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public string Binding
        {
            get => GetProp<string>("binding");
            set => SetProp("binding", value);
        }
        [Parameter]
        public string Header
        {
            get => GetProp<string>("header");
            set => SetProp("header", value);
        }

        [Parameter]
        public string Format
        {
            get => GetProp<string>("format");
            set => SetProp("format", value);
        }
        [Parameter]
        public object Width
        {
            get => GetProp<object>("width");
            set => SetProp("width", value);
        }
        [Parameter]
        public string Align
        {
            get => GetProp<string>("align");
            set => SetProp("align", value);
        }
        [Parameter]
        public int? MaxLength
        {
            get => GetProp<int?>("maxLength");
            set => SetProp("maxLength", value);
        }
        [Parameter]
        public string Mask
        {
            get => GetProp<string>("mask");
            set => SetProp("mask", value);
        }
        [Parameter]
        public bool? Visible
        {
            get => GetProp<bool?>("visible");
            set => SetProp("visible", value);
        }
        [Parameter]
        public bool? IsReadOnly
        {
            get => GetProp<bool?>("isReadOnly");
            set => SetProp("isReadOnly", value);
        }
        [Parameter]
        public bool? AllowResizing
        {
            get => GetProp<bool?>("allowResizing");
            set => SetProp("allowResizing", value);
        }
        [Parameter]
        public bool? AllowDragging
        {
            get => GetProp<bool?>("allowDragging");
            set => SetProp("allowDragging", value);
        }
        [Parameter]
        public bool? IsRequired
        {
            get => GetProp<bool?>("isRequired");
            set => SetProp("isRequired", value);
        }
        [Parameter]
        public bool? IsContentHtml
        {
            get => GetProp<bool?>("isContentHtml");
            set => SetProp("isContentHtml", value);
        }
        [Parameter]
        public bool? WordWrap
        {
            get => GetProp<bool?>("wordWrap");
            set => SetProp("wordWrap", value);
        }
        [Parameter]
        public bool? MultiLine
        {
            get => GetProp<bool?>("multiLine");
            set => SetProp("multiLine", value);
        }
        [Parameter]
        public string CssClass
        {
            get => GetProp<string>("cssClass");
            set => SetProp("cssClass", value);
        }
        [Parameter]
        public string CssClassAll
        {
            get => GetProp<string>("cssClassAll");
            set => SetProp("cssClassAll", value);
        }
        [Parameter]
        public IEnumerable<string> DataMap
        {
            get => GetProp<IEnumerable<string>>("dataMap");
            set => SetProp("dataMap", value);
        }
        #endregion
    }
}
