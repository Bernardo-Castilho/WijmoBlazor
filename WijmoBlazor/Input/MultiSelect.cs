using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace WJ
{
    public class MultiSelect : ComboBox
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.input.MultiSelect";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public bool ShowSelectAllCheckbox
        {
            get => GetProp<bool>("showSelectAllCheckbox");
            set => SetProp("showSelectAllCheckbox", value);
        }
        [Parameter]
        public string SelectAllLabel
        {
            get => GetProp<string>("selectAllLabel");
            set => SetProp("selectAllLabel", value);
        }
        [Parameter]
        public string CheckedMemberPath
        {
            get => GetProp<string>("checkedMemberPath");
            set => SetProp("checkedMemberPath", value);
        }
        [Parameter]
        public int MaxHeaderItems
        {
            get => GetProp<int>("maxHeaderItems");
            set => SetProp("maxHeaderItems", value);
        }
        [Parameter]
        public string HeaderFormat
        {
            get => GetProp<string>("headerFormat");
            set => SetProp("headerFormat", value);
        }
        [Parameter]
        public object CheckedItems // REVIEW: this doesn't work...
        {
            get => GetProp<JsonElement>("checkedItems");
            set => SetProp("checkedItems", value);
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region events

        [Parameter]
        public Action<MultiSelect> CheckedItemsChanged { get; set; }

        override protected string RaiseEvent(string name, string args)
        {
            switch (name)
            {
                case "checkedItemsChanged":
                    CheckedItemsChanged?.Invoke(this);
                    return string.Empty;
            }

            // not our event, allow base class
            return base.RaiseEvent(name, args);
        }
        #endregion
    }
}
