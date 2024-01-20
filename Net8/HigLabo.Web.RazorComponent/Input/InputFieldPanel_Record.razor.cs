using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.RazorComponent.Input
{
    public partial class InputFieldPanel_Record
    {
		public class LoadingEventArgs
		{
			public string SearchText { get; set; } = "";
			public List<Record> RecordList { get; init; }

            public LoadingEventArgs(List<Record> recordList)
				: this(recordList, "")
			{
			}
            public LoadingEventArgs(List<Record> recordList, string searchText)
			{
				this.RecordList = recordList;
				this.SearchText = searchText;
			}
        }
		public class Record
		{
			public string Text { get; set; } = "";
			public object Value { get; set; }

			public Record(string text, object value)
			{
				Text = text;
				Value = value;
			}
		}
		private int _RecordIndex = -1;
		private List<Record> _RecordList = new();

		[Parameter]
		public string Name { get; set; } = "";
		[Parameter]
		public string Text { get; set; } = "";
		[Parameter]
		public string ClassName { get; set; } = "input-field-panel";
		[Parameter]
		public InputValidateResult ValidateResult { get; set; } = new InputValidateResult(true);

		[Parameter]
		public ElementReference RecordPanelElementReference { get; set; }
		[Parameter]
		public RenderFragment? RecordPanel { get; set; }
		[Parameter]
		public bool SelectRecordPanelVisible { get; set; } = false;
		[Parameter]
		public string SearchText { get; set; } = "";
        [Parameter]
        public EventCallback<LoadingEventArgs> Loading { get; set; }
        [Parameter]
        public EventCallback<Record> OnRecordSelected { get; set; }

		private async ValueTask RecordPanel_Keydown(KeyboardEventArgs e)
		{
			if (e.Key == "Enter")
			{
				await this.ToggleVisible();
			}
        }
		private async ValueTask ToggleVisible()
		{
			if (this.SelectRecordPanelVisible)
			{
				this.SelectRecordPanelVisible = false;
				await this.RecordPanelElementReference.FocusAsync();
			}
			else
			{
				_RecordIndex = -1;
				this.SearchText = "";
				this.SelectRecordPanelVisible = true;
				await this.OnLoading();
				this.StateHasChanged();
			}
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
					await OnLoading();
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
			await OnLoading();
        }
		private async ValueTask OnLoading()
		{
			await this.Loading.InvokeAsync(new LoadingEventArgs(_RecordList, this.SearchText));
		}
		private async ValueTask RecordPanel_Click(Record record)
		{
			await this.RecordPanelSelected(record);
		}
		private async ValueTask RecordPanelSelected(Record record)
		{
			this.SelectRecordPanelVisible = false;
			await this.OnRecordSelected.InvokeAsync(record);
			await this.RecordPanelElementReference.FocusAsync();
		}
	}
}
