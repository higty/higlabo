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
		private List<Record> _RecordList = new();

		[Parameter]
		public string Name { get; set; } = "";
		[Parameter]
		public string Text { get; set; } = "";
		[Parameter]
		public string Value { get; set; } = "";
		[Parameter]
		public string ClassName { get; set; } = "input-field-panel";
		[Parameter]
		public InputValidateResult ValidateResult { get; set; } = new InputValidateResult(true);

		[Parameter]
		public RenderFragment? RecordPanel { get; set; }
		[Parameter]
		public bool SelectRecordPanelVisible { get; set; } = false;
		[Parameter]
		public string SearchText { get; set; } = "";
        [Parameter]
        public EventCallback<LoadingEventArgs> Loading { get; set; }
        [Parameter]
        public EventCallback<Record> RecordSelected { get; set; }

        private async ValueTask SearchTextbox_Keydown(KeyboardEventArgs e)
		{
			if (e.Key == "Enter")
			{
				await OnLoading();
			}
		}
		private async ValueTask SearchButton_Click(MouseEventArgs e)
		{
			await OnLoading();
        }
        private async ValueTask ToggleVisible()
        {
            if (this.SelectRecordPanelVisible)
			{
				this.SelectRecordPanelVisible = false;
			}
			else
			{
				this.SearchText = "";
				this.SelectRecordPanelVisible = true;
                await this.OnLoading();
            }
        }
		private async ValueTask OnLoading()
		{
			await this.Loading.InvokeAsync(new LoadingEventArgs(_RecordList, this.SearchText));
		}
		private async ValueTask RecordPanel_Click(Record record)
		{
			this.SelectRecordPanelVisible = false;
			await this.RecordSelected.InvokeAsync(record);
		}
	}
}
