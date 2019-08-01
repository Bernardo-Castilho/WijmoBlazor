using Microsoft.AspNetCore.Components;

namespace WJ
{
    public class GroupPanel : Control
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.grid.grouppanel.GroupPanel";
        }
        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public object Grid
        {
            get => GetProp<object>("grid");
            set => SetProp("grid", value);
        }
        [Parameter]
        public bool HideGroupedColumns
        {
            get => GetProp<bool>("hideGroupedColumns");
            set => SetProp("hideGroupedColumns", value);
        }
        [Parameter]
        public bool ShowDragGlyphs
        {
            get => GetProp<bool>("showDragGlyphs");
            set => SetProp("showDragGlyphs", value);
        }
        [Parameter]
        public int MaxGroups
        {
            get => GetProp<int>("maxGroups");
            set => SetProp("maxGroups", value);
        }
        [Parameter]
        public string Placeholder
        {
            get => GetProp<string>("placeholder");
            set => SetProp("placeholder", value);
        }
        #endregion
    }
}
