using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace WJ
{
    public class Menu : ComboBox
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.input.Menu";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public string Header
        {
            get =>GetProp<string>("header");
            set => SetProp("header", value);
        }
        [Parameter]
        public string SubItemsPath
        {
            get =>GetProp<string>("subItemsPath");
            set => SetProp("subItemsPath", value);
        }
        [Parameter]
        public bool OpenOnHover
        {
            get =>GetProp<bool>("openOnHover");
            set => SetProp("openOnHover", value);
        }
        [Parameter]
        public bool CloseOnLeave
        {
            get =>GetProp<bool>("closeOnLeave");
            set => SetProp("closeOnLeave", value);
        }
        [Parameter]
        public bool IsButton
        {
            get =>GetProp<bool>("isButton");
            set => SetProp("isButton", value);
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region events

        [Parameter]
        public Action<Menu> ItemClicked { get; set; }

        override protected string RaiseEvent(string name, string args)
        {
            switch (name)
            {
                case "itemClicked":
                    ItemClicked?.Invoke(this);
                    return string.Empty;
            }

            // not our event, allow base class
            return base.RaiseEvent(name, args);
        }
        #endregion
    }
}
