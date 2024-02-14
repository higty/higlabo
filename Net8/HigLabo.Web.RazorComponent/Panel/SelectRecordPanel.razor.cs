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
    public class SelectRecordPanelFilterTab<TItem>
    {
        public string Text { get; set; } = "";
        public List<TItem> RecordList { get; init; } = new List<TItem>();

        public SelectRecordPanelFilterTab() { }
        public virtual async ValueTask OnRecordListLoadingAsync()
        {
            await ValueTask.CompletedTask;
        }
    }
    public class SelectRecordPanelState<TItem, TFilterItem>
    {
        internal Action OnAllRecordSelected { get; set; } = () => { };
        internal Action<TItem> OnRecordSelected { get; set; } = r => { };
        internal Action OnClosed { get; set; } = () => { };

        internal int RecordIndex { get; set; } = -1;

        public bool SearchContainerPanelVisible { get; set; } = true;
        public bool SelectAllVisible { get; set; } = false;
        public SelectRecordPanelFilterTab<TFilterItem>? Tab { get; set; }
        public TFilterItem? Filter { get; set; }
        public List<SelectRecordPanelFilterTab<TFilterItem>> TabList { get; init; } = new();
        public string SearchText { get; set; } = "";
        public List<TItem> RecordList { get; init; } = new List<TItem>();

        public virtual async ValueTask OnRecordListLoadingAsync()
        {
            await ValueTask.CompletedTask;
        }

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
        internal async ValueTask FilterTabSelected(SelectRecordPanelFilterTab<TFilterItem> tab)
        {
            this.Tab = tab;
            await this.Tab.OnRecordListLoadingAsync();
        }
        internal async ValueTask FilterRecordPanelSelected(TFilterItem record)
        {
            this.Filter = record;
            await this.OnRecordListLoadingAsync();
            this.Tab = null;
        }
        internal async ValueTask<bool> SearchTextbox_Keydown(KeyboardEventArgs e)
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
                    await OnRecordListLoadingAsync();
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
    public partial class SelectRecordPanel<TItem, TFilterItem> : ComponentBase
	{
		[Parameter]
		public SelectRecordPanelState<TItem, TFilterItem> State { get; set; } = new();
        [Parameter]
        [AllowNull]
        public RenderFragment<TItem> ItemTemplate { get; set; }
		[Parameter, AllowNull]
		public RenderFragment<TFilterItem> FilterItemTemplate { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await this.OnRecordListLoadingAsync_Invoke();
		}
        private async ValueTask OnRecordListLoadingAsync_Invoke()
		{
			await this.State.OnRecordListLoadingAsync();
            this.StateHasChanged();
		}

        private async ValueTask SearchTextbox_Keydown(KeyboardEventArgs e)
		{
			if (await this.State.SearchTextbox_Keydown(e))
            {
                this.StateHasChanged();
            }
        }
        private async ValueTask SearchButton_Click(MouseEventArgs e)
		{
			await OnRecordListLoadingAsync_Invoke();
		}

        private void AllRecordSelect_Click()
        {
            this.State.AllRecordSelected();
		}
		private void RecordPanel_Click(TItem record)
		{
			this.State.RecordPanelSelected(record);
		}
		private async ValueTask FilterRecordPanel_Click(TFilterItem record)
		{
            this.State.RecordIndex = -1;
		 	await this.State.FilterRecordPanelSelected(record);
		}
	}
}
