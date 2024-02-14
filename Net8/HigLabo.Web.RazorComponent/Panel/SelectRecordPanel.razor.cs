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
		[Parameter]
		public EventCallback<TItem> OnRecordSelected { get; set; }
		[Parameter]
		public EventCallback OnAllRecordSelected { get; set; }
		[Parameter]
        public EventCallback OnClosed { get; set; }

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

        private async ValueTask FilterTabSelected(SelectRecordPanelFilterTab<TFilterItem> tab)
        {
            this.State.Tab = tab;
            await this.State.Tab.OnRecordListLoadingAsync();
        }
        private async ValueTask FilterRecordPanelSelected(TFilterItem record)
        {
            this.State.Filter = record;
            await this.State.OnRecordListLoadingAsync();
            this.State.Tab = null;
        }

        private async void SearchTextbox_Keydown(KeyboardEventArgs e)
        {
            var state = this.State;

            if (e.Key == "Esc")
            {
                state.RecordIndex = -1;
                this.StateHasChanged();
            }
            else if (e.Key == "Enter")
            {
                if (state.RecordIndex < 0)
                {
                    await state.OnRecordListLoadingAsync();
                }
                else
                {
                    await this.OnRecordSelected.InvokeAsync(state.RecordList[state.RecordIndex]);
                }
            }
            else if (e.Key == "ArrowUp")
            {
                state.RecordIndex = state.RecordIndex - 1;
                if (state.RecordIndex < -1)
                {
                    state.RecordIndex = state.RecordList.Count - 1;
                }
                this.StateHasChanged();
            }
            else if (e.Key == "ArrowDown")
            {
                state.RecordIndex = state.RecordIndex + 1;
                if (state.RecordIndex >= state.RecordList.Count)
                {
                    state.RecordIndex = -1;
                }
                this.StateHasChanged();
            }
        }
        private async ValueTask SearchButton_Click(MouseEventArgs e)
		{
			await OnRecordListLoadingAsync_Invoke();
		}

        private async ValueTask AllRecordSelected()
        {
            foreach (var item in this.State.RecordList)
            {
                await this.OnRecordSelected.InvokeAsync(item);
            }
            await this.OnAllRecordSelected.InvokeAsync();
        }
        private async ValueTask RecordPanel_Click(TItem record)
		{
		 	await this.OnRecordSelected.InvokeAsync(record);
		}
		private async ValueTask FilterRecordPanel_Click(TFilterItem record)
		{
            this.State.RecordIndex = -1;
		 	await this.FilterRecordPanelSelected(record);
		}
	}
}
