using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.RazorComponent.Panel
{
    public class SelectRecordPanelFilterTabData<TItem>
    {
        public string Text { get; set; } = "";
        internal List<TItem> RecordList { get; init; } = new List<TItem>();
        public Action<RecordListLoadingContext<TItem>> OnRecordListLoading { get; set; } = r => { };

        internal void OnRecordListLoading_Invoke()
        {
            this.RecordList.Clear();
            this.OnRecordListLoading(new RecordListLoadingContext<TItem>(this.RecordList));
        }
    }
    public partial class SelectRecordPanel<TItem, TFilterItem> : ComponentBase
	{
		public class StateDate
		{
			internal Action OnAllRecordSelected { get; set; } = () => { };
			internal Action<TItem> OnRecordSelected { get; set; } = r => { };
			internal Action OnClosed { get; set; } = () => { };

            internal SelectRecordPanelFilterTabData<TFilterItem>? Tab { get; set; }
            internal int RecordIndex { get; set; } = -1;
            internal List<TItem> RecordList { get; init; } = new List<TItem>();

			public bool SearchContainerPanelVisible { get; set; } = true;
			public bool SelectAllVisible { get; set; } = false;
			public List<SelectRecordPanelFilterTabData<TFilterItem>> TabList { get; init; } = new();
            public string SearchText { get; set; } = "";
            public Action<RecordListLoadingContext<TItem, TFilterItem?>> OnRecordListLoading { get; set; } = r => { };

			internal void AllRecordSelected()
			{
                foreach (var item in this.RecordList)
                {
                    this.RecordPanelSelected(item);
                }
				this.OnAllRecordSelected();
			}
			internal void RecordPanelSelected(TItem record)
			{
				this.OnRecordSelected(record);
			}
            internal void FilterTabSelected(SelectRecordPanelFilterTabData<TFilterItem> tab)
            {
                this.Tab = tab;
                this.Tab.OnRecordListLoading_Invoke();
            }
			internal void FilterRecordPanelSelected(TFilterItem record)
			{
                this.Tab = null;
                this.OnRecordListLoading_Invoke(record);
			}
			internal void OnRecordListLoading_Invoke(TFilterItem? record)
			{
				this.RecordList.Clear();
                this.OnRecordListLoading(new RecordListLoadingContext<TItem, TFilterItem?>(this.RecordList, this.SearchText, record));
            }
            internal bool SearchTextbox_Keydown(KeyboardEventArgs e)
            {
                var bl = false;
                if (e.Key == "Esc")
                {
                    this.RecordIndex = -1;
                    bl = true;
                }
                else if (e.Key == "Enter")
                {
                    if (this.RecordIndex < 0)
                    {
                        OnRecordListLoading_Invoke(default(TFilterItem));
                    }
                    else
                    {
                        this.RecordPanelSelected(this.RecordList[this.RecordIndex]);
                    }
                }
                else if (e.Key == "ArrowUp")
                {
                    this.RecordIndex = this.RecordIndex - 1;
                    if (this.RecordIndex < -1)
                    {
                        this.RecordIndex = this.RecordList.Count - 1;
                    }
                    bl = true;
                }
                else if (e.Key == "ArrowDown")
                {
                    this.RecordIndex = this.RecordIndex + 1;
                    if (this.RecordIndex >= this.RecordList.Count)
                    {
                        this.RecordIndex = -1;
                    }
                    bl = true;
                }
                return bl;
            }
        }

		[Parameter]
		public StateDate State { get; set; } = new();
        [Parameter]
        [AllowNull]
        public RenderFragment<TItem> ItemTemplate { get; set; }
		[Parameter, AllowNull]
		public RenderFragment<TFilterItem> FilterItemTemplate { get; set; }

		protected override void OnInitialized()
        {
            base.OnInitialized();
            this.OnRecordListLoading_Invoke();
		}
        private void OnRecordListLoading_Invoke()
		{
			this.State.OnRecordListLoading_Invoke(default(TFilterItem));
		}

        private void SearchTextbox_Keydown(KeyboardEventArgs e)
		{
			if (this.State.SearchTextbox_Keydown(e))
            {
                this.StateHasChanged();
            }
        }
        private void SearchButton_Click(MouseEventArgs e)
		{
			OnRecordListLoading_Invoke();
		}

        private void AllRecordSelect_Click()
        {
            this.State.AllRecordSelected();
		}
		private void RecordPanel_Click(TItem record)
		{
			this.State.RecordPanelSelected(record);
		}
		private void FilterRecordPanel_Click(TFilterItem record)
		{
            this.State.RecordIndex = -1;
			this.State.FilterRecordPanelSelected(record);
		}
	}
}
