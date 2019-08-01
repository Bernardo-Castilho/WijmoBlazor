using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace WJ
{
    public enum NotifyCollectionChangedAction
    {
        Add,
        Remove,
        Change,
        Reset
    }

    public class NotifyCollectionChangedEventArgs
    {
        public NotifyCollectionChangedAction Action { get; }
        public int Index { get; }
        public object Item { get; }
    }

    public class SortDescription
    {
        public string Property { get; set; }
        public bool? Ascending { get; set; }
    }

    /// <summary>
    /// CollectionView that can be shared by components on a page.
    /// </summary>
    public class CollectionView : WijmoObject
    {
        /////////////////////////////////////////////////////////
        #region initialize
        protected override void Initialize()
        {
            var netRef = DotNetObjectRef.Create(this);
            var events = GetEventNames();
            _jsRef = Invoke<string>("initCollectionView", netRef, _host, _props, events);
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region properties

        [Parameter]
        public object SourceCollection
        {
            get => GetProp<JsonElement>("sourceCollection");
            set => SetProp("sourceCollection", value);
        }
        [Parameter]
        public bool CanFilter
        {
            get => GetProp<bool>("canFilter");
            set => SetProp("canFilter", value);
        }
        [Parameter]
        public bool CanGroup
        {
            get => GetProp<bool>("canGroup");
            set => SetProp("canGroup", value);
        }
        [Parameter]
        public bool CanSort
        {
            get => GetProp<bool>("canSort");
            set => SetProp("canSort", value);
        }
        [Parameter]
        public int CurrentPosition
        {
            get => GetProp<int>("currentPosition");
            set => SetProp("currentPosition", value);
        }
        [Parameter]
        public object CurrentItem
        {
            get => GetProp<JsonElement>("currentItem");
            set => SetProp("currentItem", value);
        }
        [Parameter]
        public IEnumerable<string> GroupDescriptions
        {
            get => GetProp<IEnumerable<string>>("groupDescriptions");
            set => SetProp("groupDescriptions", value);
        }
        [Parameter]
        public IEnumerable<SortDescription> SortDescriptions
        {
            get => GetProp<IEnumerable<SortDescription>>("sortDescriptions");
            set => SetProp("sortDescriptions", value);
        }
        [Parameter]
        public bool UseStableSort
        {
            get => GetProp<bool>("useStableSort");
            set => SetProp("useStableSort", value);
        }
        [Parameter]
        public bool SortNullsFirst
        {
            get => GetProp<bool>("sortNullsFirst");
            set => SetProp("sortNullsFirst", value);
        }
        [Parameter]
        public bool TrackChanges
        {
            get => GetProp<bool>("trackChanges");
            set => SetProp("trackChanges", value);
        }
        public IEnumerable<JsonElement> ItemsAdded
        {
            get => GetProp<IEnumerable<JsonElement>>("itemsAdded");
        }
        public IEnumerable<JsonElement> ItemsRemoved
        {
            get => GetProp<IEnumerable<JsonElement>>("itemsRemoved");
        }
        public IEnumerable<JsonElement> ItemsEdited
        {
            get => GetProp<IEnumerable<JsonElement>>("itemsEdited");
        }
        [Parameter]
        public bool CanAddNew
        {
            get => GetProp<bool>("canAddNew");
            set => SetProp("canAddNew", value);
        }
        [Parameter]
        public bool CanCancelEdit
        {
            get => GetProp<bool>("canCancelEdit");
            set => SetProp("canCancelEdit", value);
        }
        [Parameter]
        public bool CanRemove
        {
            get => GetProp<bool>("canRemove");
            set => SetProp("canRemove", value);
        }
        public object CurrentAddItem
        {
            get => GetProp<JsonElement>("currentAddItem");
        }
        public object CurrentEditItem
        {
            get => GetProp<JsonElement>("currentEditItem");
        }
        public bool IsAddingNew
        {
            get => GetProp<bool>("isAddingNew");
        }
        public bool IsEditingItem
        {
            get => GetProp<bool>("isEditingItem");
        }
        [Parameter]
        public bool CanChangePage
        {
            get => GetProp<bool>("canChangePage");
            set => SetProp("canChangePage", value);
        }
        public int PageIndex
        {
            get => GetProp<int>("pageIndex");
        }
        [Parameter]
        public int PageSize
        {
            get => GetProp<int>("pageSize");
            set => SetProp("pageSize", value);
        }
        public int ItemCount
        {
            get => GetProp<int>("itemCount");
        }
        public int TotalItemCount
        {
            get => GetProp<int>("totalItemCount");
        }
        public int PageCount
        {
            get => GetProp<int>("pageCount");
        }

        #endregion

        /////////////////////////////////////////////////////////
        #region methods

        public bool MoveCurrentToFirst()
        {
            return Call<bool>("moveCurrentToFirst");
        }
        public bool MoveCurrentToLast()
        {
            return Call<bool>("moveCurrentToLast");
        }
        public bool MoveCurrentToPrevious()
        {
            return Call<bool>("moveCurrentToPrevious");
        }
        public bool MoveCurrentToNext()
        {
            return Call<bool>("moveCurrentToNext");
        }
        public int MoveCurrentToPosition(int index)
        {
            return Call<int>("moveCurrentToPosition", index);
        }
        public void ClearChanges()
        {
            Call<object>("clearChanges");
        }
        public void Refresh()
        {
            Call<object>("refresh");
        }
        public bool MoveToFirstPage()
        {
            return Call<bool>("moveToFirstPage");
        }
        public bool MoveToLastPage()
        {
            return Call<bool>("moveToLastPage");
        }
        public bool MoveToPreviousPage()
        {
            return Call<bool>("moveToPreviousPage");
        }
        public bool MoveToNextPage()
        {
            return Call<bool>("moveToNextPage");
        }
        public bool MoveToPage(int index)
        {
            return Call<bool>("moveToPage", index);
        }
        #endregion

        /////////////////////////////////////////////////////////
        #region events

        [Parameter]
        public Action<CollectionView, CancelEventArgs> SourceCollectionChanging { get; set; }
        [Parameter]
        public Action<CollectionView> SourceCollectionChanged { get; set; }
        [Parameter]
        public Action<CollectionView, NotifyCollectionChangedEventArgs> CollectionChanged { get; set; }
        [Parameter]
        public Action<CollectionView, CancelEventArgs> CurrentChanging { get; set; }
        [Parameter]
        public Action<CollectionView> CurrentChanged { get; set; }
        [Parameter]
        public Action<CollectionView, CancelEventArgs> PageChanging { get; set; }
        [Parameter]
        public Action<CollectionView> PageChanged { get; set; }

        #endregion

        override protected string RaiseEvent(string name, string args)
        {
            switch (name)
            {
                case "sourceCollectionChanging":
                    return RaiseEvent<CollectionView, CancelEventArgs>(SourceCollectionChanging, args);
                case "sourceCollectionChanged":
                    return RaiseEvent<CollectionView>(SourceCollectionChanged);
                case "collectionChanged":
                    return RaiseEvent<CollectionView, NotifyCollectionChangedEventArgs>(CollectionChanged, args);
                case "currentChanging":
                    return RaiseEvent<CollectionView, CancelEventArgs>(CurrentChanging, args);
                case "currentChanged":
                    return RaiseEvent<CollectionView>(CurrentChanged);
                case "pageChanging":
                    return RaiseEvent<CollectionView, CancelEventArgs>(PageChanging, args);
                case "pageChanged":
                    return RaiseEvent<CollectionView>(PageChanged);
            }

            // not our event, allow base class
            return base.RaiseEvent(name, args);
        }
    }
}