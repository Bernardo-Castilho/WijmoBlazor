using Microsoft.AspNetCore.Components;
using System;
using System.Text.Json;

namespace WJ
{
    public class ComboBox : DropDown
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.input.ComboBox";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public object ItemsSource
        {
            get =>GetProp<JsonElement>("itemsSource");
            set =>SetProp("itemsSource", value);
        }
        [Parameter]
        public bool ShowGroups
        {
            get =>GetProp<bool>("showGroups");
            set =>SetProp("showGroups", value);
        }
        [Parameter]
        public string DisplayMemberPath
        {
            get =>GetProp<string>("displayMemberPath");
            set =>SetProp("displayMemberPath", value);
        }
        [Parameter]
        public string HeaderPath
        {
            get =>GetProp<string>("headerPath");
            set =>SetProp("headerPath", value);
        }
        [Parameter]
        public string SelectedValuePath
        {
            get =>GetProp<string>("selectedValuePath");
            set =>SetProp("selectedValuePath", value);
        }
        [Parameter]
        public bool IsContentHtml
        {
            get =>GetProp<bool>("isContentHtml");
            set =>SetProp("isContentHtml", value);
        }
        [Parameter]
        public bool TrimText
        {
            get =>GetProp<bool>("trimText");
            set =>SetProp("trimText", value);
        }
        [Parameter]
        public int SelectedIndex
        {
            get =>GetProp<int>("selectedIndex");
            set =>SetProp("selectedIndex", value);
        }
        [Parameter]
        public object SelectedItem
        {
            get =>GetProp<JsonElement>("selectedItem");
            set =>SetProp("selectedItem", value);
        }
        [Parameter]
        public object SelectedValue
        {
            get =>GetProp<JsonElement>("selectedValue");
            set =>SetProp("selectedValue", value);
        }
        [Parameter]
        public bool IsEditable
        {
            get =>GetProp<bool>("isEditable");
            set =>SetProp("isEditable", value);
        }
        [Parameter]
        public int MaxDropDownHeight
        {
            get =>GetProp<int>("maxDropDownHeight");
            set =>SetProp("maxDropDownHeight", value);
        }
        [Parameter]
        public int MaxDropDownWidth
        {
            get =>GetProp<int>("maxDropDownWidth");
            set =>SetProp("maxDropDownWidth", value);
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region events

        [Parameter]
        public Action<ComboBox> ItemsSourceChanged { get; set; }
        [Parameter]
        public Action<ComboBox> SelectedIndexChanged { get; set; }

        override protected string RaiseEvent(string name, string args)
        {
            switch (name)
            {
                case "itemsSourceChanged":
                    ItemsSourceChanged?.Invoke(this);
                    return string.Empty;
                case "selectedIndexChanged":
                    SelectedIndexChanged?.Invoke(this);
                    return string.Empty;
            }

            // not our event, allow base class
            return base.RaiseEvent(name, args);
        }
        #endregion
    }
}
