using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace WJ
{
    public enum FilterType
    {
        None = 0,
        Condition = 1,
        Value = 2,
        Both = 3
    }

    public class FlexGridFilter : MarkupProperty
    {
        /////////////////////////////////////////////////////////
        #region initialize

        public FlexGridFilter() : base()
        {
            _className = "wijmo.grid.filter.FlexGridFilter";
            _propName = "(extender)";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public string[] FilterColumns
        {
            get => GetProp<string[]>("filterColumns");
            set => SetProp("filterColumns", value);
        }
        [Parameter]
        public bool ShowFilterIcons
        {
            get => GetProp<bool>("showFilterIcons");
            set => SetProp("showFilterIcons", value);
        }
        [Parameter]
        public bool ShowSortButtons
        {
            get => GetProp<bool>("showSortButtons");
            set => SetProp("showSortButtons", value);
        }

        [Parameter]
        public FilterType DefaultFilterType
        {
            get => GetProp<FilterType>("defaultFilterType");
            set => SetProp("defaultFilterType", value);
        }
        [Parameter]
        public bool ExclusiveValueSearch
        {
            get => GetProp<bool>("exclusiveValueSearch");
            set => SetProp("exclusiveValueSearch", value);
        }
        [Parameter]
        public string FilterDefinition
        {
            get => GetProp<string>("filterDefinition");
            set => SetProp("filterDefinition", value);
        }
        #endregion

        /////////////////////////////////////////////////////////
        #region events

        [Parameter]
        public Action<FlexGridFilter> FilterChanging { get; set; }
        [Parameter]
        public Action<FlexGridFilter> FilterChanged { get; set; }
        [Parameter]
        public Action<FlexGridFilter> FilterApplied { get; set; }

        override protected string RaiseEvent(string name, string args)
        {
            switch (name)
            {
                case "filterChanging":
                    FilterChanging?.Invoke(this);
                    return string.Empty;
                case "filterChanged":
                    FilterChanged?.Invoke(this);
                    return string.Empty;
                case "filterApplied":
                    FilterApplied?.Invoke(this);
                    return string.Empty;
            }

            // not our event, allow base class
            return base.RaiseEvent(name, args);
        }
        #endregion
    }
}
