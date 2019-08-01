using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace WJ
{
    public class MultiAutoComplete : AutoComplete
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.input.MultiAutoComplete";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public int MaxSelectedItems
        {
            get => GetProp<int>("maxSelectedItems");
            set => SetProp("maxSelectedItems", value);
        }
        [Parameter]
        public string SelectedMemberPath
        {
            get => GetProp<string>("selectedMemberPath");
            set => SetProp("selectedMemberPath", value);
        }
        [Parameter]
        public IEnumerable SelectedItems
        {
            get => GetProp<IEnumerable<JsonElement>>("selectedItems");
            set => SetProp("selectedItems", value);
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region events

        [Parameter]
        public Action<MultiAutoComplete> SelectedItemsChanged { get; set; }

        override protected string RaiseEvent(string name, string args)
        {
            switch (name)
            {
                case "selectedItemsChanged":
                    SelectedItemsChanged?.Invoke(this);
                    return string.Empty;
            }

            // not our event, allow base class
            return base.RaiseEvent(name, args);
        }
        #endregion
    }
}
