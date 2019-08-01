using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace WJ
{
    public class ListBox : Control
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.input.ListBox";
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
        public bool IsContentHtml
        {
            get =>GetProp<bool>("isContentHtml");
            set =>SetProp("isContentHtml", value);
        }
        [Parameter]
        public int? MaxHeight
        {
            get =>GetProp<int?>("maxHeight");
            set =>SetProp("maxHeight", value);
        }
        [Parameter]
        public string DisplayMemberPath
        {
            get =>GetProp<string>("displayMemberPath");
            set =>SetProp("displayMemberPath", value);
        }
        [Parameter]
        public string SelectedValuePath
        {
            get =>GetProp<string>("selectedValuePath");
            set =>SetProp("selectedValuePath", value);
        }
        [Parameter]
        public string CheckedMemberPath
        {
            get =>GetProp<string>("checkedMemberPath");
            set =>SetProp("checkedMemberPath", value);
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
        public IEnumerable CheckedItems
        {
            get =>GetProp<IEnumerable<JsonElement>>("checkedItems");
            set =>SetProp("checkedItems", value);
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region methods

        public void ShowSelection(bool setFocus = false)
        {
            Invoke<bool>("showSelection", setFocus);
        }
        public void LoadList()
        {
            Invoke<bool>("loadList");
        }
        public bool GetItemChecked(int index)
        {
            return Invoke<bool>("getItemChecked", index);
        }
        public bool SetItemChecked(int index, bool chk)
        {
            return Invoke<bool>("setItemChecked", index, chk);
        }
        public bool ToggleItemChecked(int index)
        {
            bool chk = !GetItemChecked(index);
            return Invoke<bool>("setItemChecked", index, chk);
        }
        #endregion

        /////////////////////////////////////////////////////////
        #region events

        [Parameter]
        public Action<ListBox> SelectedIndexChanged { get; set; }
        [Parameter]
        public Action<ListBox> ItemsChanged { get; set; }
        [Parameter]
        public Action<ListBox> LoadingItems { get; set; }
        [Parameter]
        public Action<ListBox> LoadedItems { get; set; }
        [Parameter]
        public Action<ListBox> ItemChecked { get; set; }
        [Parameter]
        public Action<ListBox> CheckedItemsChanged { get; set; }

        override protected string RaiseEvent(string name, string args)
        {
            switch (name)
            {
                case "selectedIndexChanged":
                    SelectedIndexChanged?.Invoke(this);
                    return string.Empty;
                case "itemsChanged":
                    ItemsChanged?.Invoke(this);
                    return string.Empty;
                case "loadingItems":
                    LoadingItems?.Invoke(this);
                    return string.Empty;
                case "loadedItems":
                    LoadedItems?.Invoke(this);
                    return string.Empty;
                case "itemChecked":
                    ItemChecked?.Invoke(this);
                    return string.Empty;
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
