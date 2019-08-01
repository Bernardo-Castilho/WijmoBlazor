using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace WJ
{
    public class AutoComplete : ComboBox
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.input.AutoComplete";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public int MinLength
        {
            get =>GetProp<int>("minLength");
            set =>SetProp("minLength", value);
        }
        [Parameter]
        public int MaxItems
        {
            get =>GetProp<int>("maxItems");
            set =>SetProp("maxItems", value);
        }
        [Parameter]
        public int Delay
        {
            get =>GetProp<int>("delay");
            set =>SetProp("delay", value);
        }
        [Parameter]
        public string SearchMemberPath
        {
            get =>GetProp<string>("searchMemberPath");
            set =>SetProp("searchMemberPath", value);
        }
        [Parameter]
        public string CssMatch
        {
            get =>GetProp<string>("cssMatch");
            set =>SetProp("cssMatch", value);
        }

        #endregion
    }
}
