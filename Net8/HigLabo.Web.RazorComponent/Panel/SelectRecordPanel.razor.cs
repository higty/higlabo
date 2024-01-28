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
	public partial class SelectRecordPanel<TItem> : ComponentBase
	{
		private int _RecordIndex = -1;

		[Parameter]
		public string SearchText { get; set; } = "";
		[Parameter]
		public bool SearchContainerPanelVisible { get; set; } = true;
        [Parameter]
        public bool MultipleSelectRecord { get; set; } = false;
        
		[Parameter]
		public EventCallback<RecordListLoadingContext<TItem>> OnRecordListLoading { get; set; }
		[Parameter]
		public EventCallback<TItem> OnRecordSelected { get; set; }
        [Parameter, AllowNull]
        public RenderFragment<TItem> ItemTemplate { get; set; }

        private List<TItem> RecordList { get; set; } = new List<TItem>();
        [Parameter]
		public EventCallback OnClosed { get; set; }

		protected override async Task OnInitializedAsync()
		{
			await this.OnRecordListLoading_Invoke();
		}
		private async ValueTask OnRecordListLoading_Invoke()
		{
			this.RecordList.Clear();
			await this.OnRecordListLoading.InvokeAsync(new RecordListLoadingContext<TItem>(this.RecordList, this.SearchText));
		}

		private async ValueTask SearchTextbox_Keydown(KeyboardEventArgs e)
		{
			if (e.Key == "Esc")
			{
				_RecordIndex = -1;
				this.StateHasChanged();
			}
			else if (e.Key == "Enter")
			{
				if (_RecordIndex < 0)
				{
					await OnRecordListLoading_Invoke();
				}
				else
				{
					await this.RecordPanelSelected(this.RecordList[_RecordIndex]);
				}
			}
			else if (e.Key == "ArrowUp")
			{
				_RecordIndex = _RecordIndex - 1;
				if (_RecordIndex < -1)
				{
					_RecordIndex = this.RecordList.Count - 1;
				}
				this.StateHasChanged();
			}
			else if (e.Key == "ArrowDown")
			{
				_RecordIndex = _RecordIndex + 1;
				if (_RecordIndex >= this.RecordList.Count)
				{
					_RecordIndex = -1;
				}
				this.StateHasChanged();
			}
		}
		private async ValueTask SearchButton_Click(MouseEventArgs e)
		{
			await OnRecordListLoading_Invoke();
		}

		private async ValueTask RecordPanel_Click(TItem record)
		{
			await this.RecordPanelSelected(record);
		}
		private async ValueTask RecordPanelSelected(TItem record)
		{
			await this.OnRecordSelected.InvokeAsync(record);
			if (this.MultipleSelectRecord)
			{
                this.RecordList.Remove(record);
            }
        }
    }
}
