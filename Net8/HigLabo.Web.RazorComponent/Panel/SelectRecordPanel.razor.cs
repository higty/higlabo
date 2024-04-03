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
    public class FilterItem
    {
        public string Text { get; set; } = "";
    }
    public class SelectRecordPanelState<TItem> : SelectRecordPanelState<TItem, FilterItem>
    {
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
        private string _PreviousInputKey { get; set; } = "";
		[Parameter]
		public SelectRecordPanelState<TItem, TFilterItem> State { get; set; } = new();
		[Parameter]
		public ElementReference SearchTextboxElementReference { get; set; }
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
		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                if (this.State.SearchContainerPanelVisible)
                {
                    await this.SearchTextboxElementReference.FocusAsync();
                }
            }
        }
		private async ValueTask OnRecordListLoadingAsync_Invoke()
		{
			await this.State.OnRecordListLoadingAsync();
            this.StateHasChanged();
		}
		private async ValueTask FilterTabSelected()
        {
			this.State.Tab = null;
            this.State.Filter = default(TFilterItem);
            await this.OnRecordListLoadingAsync_Invoke();
		}
		private async ValueTask FilterTabSelected(SelectRecordPanelFilterTab<TFilterItem> tab)
        {
            this.State.Tab = tab;
            await this.State.Tab.OnRecordListLoadingAsync();
            this.StateHasChanged();
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

            if (e.Key == "Escape")
            {
                if (state.RecordIndex == -1)
                {
                    await this.OnClosed.InvokeAsync();
                    return;
				}
                else
                {
					state.RecordIndex = -1;
				}
			}
            else if (e.Key == "Enter")
            {
                //上下キーを押した後はレコードを選択しようとしているはず
                if (_PreviousInputKey == "ArrowDown" || _PreviousInputKey == "ArrowUp")
                {
                    await this.OnRecordSelected.InvokeAsync(state.RecordList[state.RecordIndex]);
                }
                else
                {
                    await state.OnRecordListLoadingAsync();
                    //検索後は選択状態を解除
                    state.RecordIndex = -1;
                }
            }
            else if (e.Key == "ArrowUp")
            {
                state.RecordIndex = state.RecordIndex - 1;
                if (state.RecordIndex < -1)
                {
                    state.RecordIndex = state.RecordList.Count - 1;
                }
            }
            else if (e.Key == "ArrowDown")
            {
                state.RecordIndex = state.RecordIndex + 1;
                if (state.RecordIndex >= state.RecordList.Count)
                {
                    state.RecordIndex = -1;
                }
            }
            _PreviousInputKey = e.Key;
            this.StateHasChanged();
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
