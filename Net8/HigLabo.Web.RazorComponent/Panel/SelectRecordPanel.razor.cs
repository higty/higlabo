using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.RazorComponent.Panel
{
	public partial class SelectRecordPanel
	{
		private int _RecordIndex = -1;
		private List<InputFieldPanelRecord> _RecordList = new();

		[Parameter]
		public string SearchText { get; set; } = "";
		[Parameter]
		public EventCallback<InputFieldPanelLoadingEventArgs> OnLoading { get; set; }
		[Parameter]
		public EventCallback<InputFieldPanelRecord> OnRecordSelected { get; set; }
		[Parameter]
		public EventCallback Closed { get; set; }

		protected override async Task OnInitializedAsync()
		{
			await this.OnLoading_Invoke();
		}
		private async ValueTask OnLoading_Invoke()
		{
			await this.OnLoading.InvokeAsync(new InputFieldPanelLoadingEventArgs(_RecordList, this.SearchText));
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
					await OnLoading_Invoke();
				}
				else
				{
					await this.RecordPanelSelected(_RecordList[_RecordIndex]);
				}
			}
			else if (e.Key == "ArrowUp")
			{
				_RecordIndex = _RecordIndex - 1;
				if (_RecordIndex < -1)
				{
					_RecordIndex = this._RecordList.Count - 1;
				}
				this.StateHasChanged();
			}
			else if (e.Key == "ArrowDown")
			{
				_RecordIndex = _RecordIndex + 1;
				if (_RecordIndex >= _RecordList.Count)
				{
					_RecordIndex = -1;
				}
				this.StateHasChanged();
			}
		}
		private async ValueTask SearchButton_Click(MouseEventArgs e)
		{
			await OnLoading_Invoke();
		}
		private async ValueTask RecordPanel_Click(InputFieldPanelRecord record)
		{
			await this.RecordPanelSelected(record);
		}
		private async ValueTask RecordPanelSelected(InputFieldPanelRecord record)
		{
			await this.OnRecordSelected.InvokeAsync(record);
		}
	}
}
