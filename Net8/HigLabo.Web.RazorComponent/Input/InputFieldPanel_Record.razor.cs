using HigLabo.Web.RazorComponent.Panel;
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

        [Parameter]
        public InputFieldPanelLayout Layout { get; set; } = InputFieldPanelLayout.Default;
        [Parameter]
		public string Name { get; set; } = "";
		[Parameter]
		public string Text { get; set; } = "";
        [Parameter]
        public bool FieldNameVisible { get; set; } = true;
        
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
        public EventCallback<RecordListLoadingContext> OnRecordListLoading { get; set; }
        [Parameter]
        public EventCallback<InputFieldPanelRecord> OnRecordSelected { get; set; }

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
				this.SelectRecordPanelVisible = true;
				this.StateHasChanged();
			}
		}
		private async ValueTask Record_Selected(InputFieldPanelRecord record)
		{
			this.SelectRecordPanelVisible = false;
			await this.OnRecordSelected.InvokeAsync(record);
			await this.RecordPanelElementReference.FocusAsync();
		}
	}
}
