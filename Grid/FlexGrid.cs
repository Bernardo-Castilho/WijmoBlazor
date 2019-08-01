using Microsoft.AspNetCore.Components;
using System;
using System.Text.Json;

namespace WJ
{
    public enum SelectionMode
    {
        None,
        Cell,
        CellRange,
        Row,
        RowRange,
        ListBox,
        MultiRange
    };
    public enum KeyAction
    {
        None,
        MoveDown,
        MoveAcross,
        Cycle,
        CycleOut
    }
    public enum HeadersVisibility
    {
        None = 0,
        Column = 1,
        Row = 2,
        All = 3
    }

    public class FlexGrid : Control
    {
        /////////////////////////////////////////////////////////
        #region initialize

        protected override void OnInit()
        {
            base.OnInit();
            _className = "wijmo.grid.FlexGrid";
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public HeadersVisibility HeadersVisibility
        {
            get => GetProp<HeadersVisibility>("headersVisibility");
            set => SetProp("headersVisibility", value);
        }
        [Parameter]
        public bool StickyHeaders
        {
            get => GetProp<bool>("stickyHeaders");
            set => SetProp("stickyHeaders", value);
        }
        [Parameter]
        public bool AnchorCursor
        {
            get => GetProp<bool>("anchorCursor");
            set => SetProp("anchorCursor", value);
        }
        [Parameter]
        public bool AutoGenerateColumns
        {
            get => GetProp<bool>("autoGenerateColumns");
            set => SetProp("autoGenerateColumns", value);
        }
        [Parameter]
        public bool AutoSearch
        {
            get => GetProp<bool>("autoSearch");
            set => SetProp("autoSearch", value);
        }
        [Parameter]
        public string ColumnLayout
        {
            get => GetProp<string>("columnLayout");
            set => SetProp("columnLayout", value);
        }
        [Parameter]
        public bool IsReadOnly
        {
            get => GetProp<bool>("isReadOnly");
            set => SetProp("isReadOnly", value);
        }
        [Parameter]
        public bool ImeEnabled
        {
            get => GetProp<bool>("imeEnabled");
            set => SetProp("imeEnabled", value);
        }
        [Parameter]
        public bool AllowResizing
        {
            get => GetProp<bool>("allowResizing");
            set => SetProp("allowResizing", value);
        }
        [Parameter]
        public bool DeferResizing
        {
            get => GetProp<bool>("deferResizing");
            set => SetProp("deferResizing", value);
        }
        [Parameter]
        public bool AllowSorting
        {
            get => GetProp<bool>("allowSorting");
            set => SetProp("allowSorting", value);
        }
        [Parameter]
        public bool AllowAddNew
        {
            get => GetProp<bool>("allowAddNew");
            set => SetProp("allowAddNew", value);
        }
        [Parameter]
        public bool NewRowAtTop
        {
            get => GetProp<bool>("newRowAtTop");
            set => SetProp("newRowAtTop", value);
        }
        [Parameter]
        public bool AllowDelete
        {
            get => GetProp<bool>("allowDelete");
            set => SetProp("allowDelete", value);
        }
        [Parameter]
        public HeadersVisibility ShowSelectedHeaders
        {
            get => GetProp<HeadersVisibility>("showSelectedHeaders");
            set => SetProp("showSelectedHeaders", value);
        }
        [Parameter]
        public bool ShowMarquee
        {
            get => GetProp<bool>("showMarquee");
            set => SetProp("showMarquee", value);
        }
        [Parameter]
        public int AlternatingRowStep
        {
            get => GetProp<int>("alternatingRowStep");
            set => SetProp("alternatingRowStep", value);
        }
        [Parameter]
        public bool ValidateEdits
        {
            get => GetProp<bool>("validateEdits");
            set => SetProp("validateEdits", value);
        }
        [Parameter]
        public string GroupHeaderFormat
        {
            get => GetProp<string>("groupHeaderFormat");
            set => SetProp("groupHeaderFormat", value);
        }
        [Parameter]
        public bool AllowDragging
        {
            get => GetProp<bool>("allowDragging");
            set => SetProp("allowDragging", value);
        }
        [Parameter]
        public object ItemsSource
        {
            get => GetProp<JsonElement>("itemsSource");
            set => SetProp("itemsSource", value);
        }
        [Parameter]
        public string ChildItemsPath
        {
            get => GetProp<string>("childItemsPath");
            set => SetProp("childItemsPath", value);
        }
        [Parameter]
        public int FrozenRows
        {
            get => GetProp<int>("frozenRows");
            set => SetProp("frozenRows", value);
        }
        [Parameter]
        public int FrozenColumns
        {
            get => GetProp<int>("frozenColumns");
            set => SetProp("frozenColumns", value);
        }
        [Parameter]
        public CellRange Selection
        {
            get => GetProp<CellRange>("selection");
            set => SetProp("selection", value);
        }
        [Parameter]
        public CellRange[] SelectedRanges
        {
            get => GetProp<CellRange[]>("selectedRanges");
            set => SetProp("selectedRanges", value);
        }
        [Parameter]
        public SelectionMode SelectionMode
        {
            get => GetProp<SelectionMode>("selectionMode");
            set => SetProp("selectionMode", value);
        }
        [Parameter]
        public KeyAction KeyActionTab
        {
            get => GetProp<KeyAction>("keyActionTab");
            set => SetProp("keyActionTab", value);
        }
        [Parameter]
        public KeyAction KeyActionEnter
        {
            get => GetProp<KeyAction>("keyActionEnter");
            set => SetProp("keyActionEnter", value);
        }
        #endregion

        /////////////////////////////////////////////////////////
        #region methods

        public object GetCellData(int row, int col, bool formatted)
        {
            return Call<object>("getCellData", row, col, formatted);
        }
        public bool SetCellData(int row, int col, object value, bool coerce = true, bool invalidate = true)
        {
            return Call<bool>("setCellData", row, col, value, coerce, invalidate);
        }
        public string GetClipString(CellRange rng = null, bool csv = false, bool colHdrs = false, bool rowHdrs = false)
        {
            return Call<string>("getClipString", rng, csv, colHdrs, rowHdrs);
        }
        public void Select(CellRange rng, bool show = true)
        {
            Call<bool>("select", rng, show);
        }
        public void Select(int row, int col)
        {
            Call<bool>("select", row, col);
        }
        public bool ScrollIntoView(int row, int col, bool refresh = true)
        {
            return Call<bool>("scrollIntoView", row, col, refresh);
        }
        public bool StartEditing(bool fullEdit = true, int? row = null, int? col = null, bool focus = false)
        {
            return Call<bool>("startEditing", fullEdit, row, col, focus);
        }
        public bool FinishEditing(bool cancel = false)
        {
            return Call<bool>("finishEditing", cancel);
        }
        #endregion

        /////////////////////////////////////////////////////////
        #region events

        [Parameter]
        public Action<FlexGrid> ItemsSourceChanging { get; set; }
        [Parameter]
        public Action<FlexGrid> ItemsSourceChanged { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> SelectionChanging { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> SelectionChanged { get; set; }
        [Parameter]
        public Action<FlexGrid> LoadingRows { get; set; }
        [Parameter]
        public Action<FlexGrid> LoadedRows { get; set; }
        [Parameter]
        public Action<FlexGrid> UpdatingLayout { get; set; }
        [Parameter]
        public Action<FlexGrid> UpdatedLayout { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> ResizingColumn { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> ResizedColumn { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> AutoSizingColumn { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> AutoSizedColumn { get; set; }
        [Parameter]
        public Action<FlexGrid> StarSizedColumns { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> DraggingColumn { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> DraggingColumnOver { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> DraggedColumn { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> ResizingRow { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> ResizedRow { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> AutoSizingRow { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> AutoSizedRow { get; set; }
        [Parameter]
        public Action<FlexGrid> StarSizedRows { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> DraggingRow { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> DraggingRowOver { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> DraggedRow { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> GroupCollapsedChanging { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> GroupCollapsedChanged { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> SortingColumn { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> SortedColumn { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> BeginningEdit { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> PrepareCellForEdit { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> CellEditEnding { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> CellEditEnded { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> RowEditStarting { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> RowEditStarted { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> RowEditEnding { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> RowEditEnded { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> RowAdded { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> DeletingRow { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> DeletedRow { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> Copying { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> Copied { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> Pasting { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> Pasted { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> PastingCell { get; set; }
        [Parameter]
        public Action<FlexGrid, CellRangeEventArgs> PastedCell { get; set; }
        [Parameter]
        public Action<FlexGrid> UpdatingView { get; set; }
        [Parameter]
        public Action<FlexGrid> UpdatedView { get; set; }

        override protected string RaiseEvent(string name, string args)
        {
            switch (name)
            {
                case "itemsSourceChanging":
                    return RaiseEvent<FlexGrid>(ItemsSourceChanging);
                case "itemsSourceChanged":
                    return RaiseEvent<FlexGrid>(ItemsSourceChanged);
                case "selectionChanging":
                    return RaiseCellRangeEvent(SelectionChanging, args);
                case "selectionChanged":
                    return RaiseCellRangeEvent(SelectionChanged, args);
                case "loadingRows":
                    return RaiseEvent<FlexGrid>(LoadingRows);
                case "loadedRows":
                    return RaiseEvent<FlexGrid>(LoadedRows);
                case "updatingLayout":
                    return RaiseEvent<FlexGrid>(UpdatingLayout);
                case "updatedLayout":
                    return RaiseEvent<FlexGrid>(UpdatedLayout);
                case "resizingColumn":
                    return RaiseCellRangeEvent(ResizingColumn, args);
                case "resizedColumn":
                    return RaiseCellRangeEvent(ResizedColumn, args);
                case "autoSizingColumn":
                    return RaiseCellRangeEvent(AutoSizingColumn, args);
                case "autoSizedColumn":
                    return RaiseCellRangeEvent(AutoSizedColumn, args);
                case "starSizedColumns":
                    return RaiseEvent<FlexGrid>(StarSizedColumns);
                case "draggingColumn":
                    return RaiseCellRangeEvent(DraggingColumn, args);
                case "draggingColumnOver":
                    return RaiseCellRangeEvent(DraggingColumnOver, args);
                case "draggedColumn":
                    return RaiseCellRangeEvent(DraggedColumn, args);
                case "resizingRow":
                    return RaiseCellRangeEvent(ResizingRow, args);
                case "resizedRow":
                    return RaiseCellRangeEvent(ResizedRow, args);
                case "autoSizingRow":
                    return RaiseCellRangeEvent(AutoSizingRow, args);
                case "autoSizedRow":
                    return RaiseCellRangeEvent(AutoSizedRow, args);
                case "draggingRow":
                    return RaiseCellRangeEvent(DraggingRow, args);
                case "draggingRowOver":
                    return RaiseCellRangeEvent(DraggingRowOver, args);
                case "draggedRow":
                    return RaiseCellRangeEvent(DraggedRow, args);
                case "groupCollapsedChanging":
                    return RaiseCellRangeEvent(GroupCollapsedChanging, args);
                case "groupCollapsedChanged":
                    return RaiseCellRangeEvent(GroupCollapsedChanged, args);
                case "sortingColumn":
                    return RaiseCellRangeEvent(SortingColumn, args);
                case "sortedColumn":
                    return RaiseCellRangeEvent(SortedColumn, args);
                case "beginningEdit":
                    return RaiseCellRangeEvent(BeginningEdit, args);
                case "prepareCellForEdit":
                    return RaiseCellRangeEvent(PrepareCellForEdit, args);
                case "cellEditEnding":
                    return RaiseCellRangeEvent(CellEditEnding, args);
                case "cellEditEnded":
                    return RaiseCellRangeEvent(CellEditEnded, args);
                case "rowEditStarting":
                    return RaiseCellRangeEvent(RowEditStarting, args);
                case "rowEditStarted":
                    return RaiseCellRangeEvent(RowEditStarted, args);
                case "rowEditEnding":
                    return RaiseCellRangeEvent(RowEditEnding, args);
                case "rowEditEnded":
                    return RaiseCellRangeEvent(RowEditEnded, args);
                case "rowAdded":
                    return RaiseCellRangeEvent(RowAdded, args);
                case "deletingRow":
                    return RaiseCellRangeEvent(DeletingRow, args);
                case "deletedRow":
                    return RaiseCellRangeEvent(DeletedRow, args);
                case "copying":
                    return RaiseCellRangeEvent(Copying, args);
                case "copied":
                    return RaiseCellRangeEvent(Copied, args);
                case "pasting":
                    return RaiseCellRangeEvent(Pasting, args);
                case "pasted":
                    return RaiseCellRangeEvent(Pasted, args);
                case "pastingCell":
                    return RaiseCellRangeEvent(PastingCell, args);
                case "pastedCell":
                    return RaiseCellRangeEvent(PastedCell, args);
                case "updatingView":
                    return RaiseEvent<FlexGrid>(UpdatingView);
                case "updatedView":
                    return RaiseEvent<FlexGrid>(UpdatedView);
            }

            // not our event, allow base class
            return base.RaiseEvent(name, args);
        }

        protected string RaiseCellRangeEvent(Action<FlexGrid, CellRangeEventArgs> action, string args)
        {
            return RaiseEvent<FlexGrid, CellRangeEventArgs>(action, args);
        }

        #endregion
    }
}
