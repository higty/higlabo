using HigLabo.Web.RazorComponent.Panel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.RazorComponent.Input
{
    public partial class InputFieldPanel_Record<TItem>
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
		public bool SelectRecordPanelVisible { get; set; } = false;
        [Parameter]
        public bool SearchContainerPanelVisible { get; set; } = true;

        [Parameter]
        public TItem? Record { get; set; }
        [Parameter]
        public EventCallback<TItem?> RecordChanged { get; set; }
        [Parameter]
        public ElementReference RecordPanelElementReference { get; set; }
		[Parameter, AllowNull]
		public RenderFragment<TItem?> ItemTemplate { get; set; }
        [Parameter, AllowNull]
        public RenderFragment<TItem> SelectItemTemplate { get; set; }

        [Parameter]
        public EventCallback<RecordListLoadingContext<TItem>> OnRecordListLoading { get; set; }

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
			}
            this.StateHasChanged();
        }
        private async ValueTask Record_Selected(TItem record)
		{
			this.Record = record;
			this.SelectRecordPanelVisible = false;
			await this.RecordChanged.InvokeAsync(record);
			await this.RecordPanelElementReference.FocusAsync();
			this.StateHasChanged();
		}
	}
}
