using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using HigLabo.Core;

namespace HigLabo.Web.RazorComponent.Input
{
    public partial class InputFieldPanel_RecordList<TItem>
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
        public AddRecordMode AddRecordMode { get; set; } = AddRecordMode.Add;
        [Parameter]
        public bool MultipleSelectRecord { get; set; } = true;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public InputValidateResult ValidateResult { get; set; } = new InputValidateResult(true);

        [Parameter, AllowNull]
        public List<TItem> RecordList { get; set; }
        [Parameter]
        public bool SelectRecordPanelVisible { get; set; } = false;
        [Parameter]
        public bool SearchContainerPanelVisible { get; set; } = true;
        [Parameter, AllowNull]
        public RenderFragment<TItem> SelectItemTemplate { get; set; }

        [Parameter]
        public EventCallback<RecordListLoadingContext<TItem>> OnRecordListLoading { get; set; }
        [Parameter]
        public EventCallback OnRecordAdded { get; set; }
        [Parameter]
        public Func<TItem, TItem, bool>? EqualityFunc { get; set; } 
        [Parameter]
        public EventCallback OnRecordDropped { get; set; }

        private async ValueTask OnAddIconClicked()
        {
            switch (this.AddRecordMode)
            {
                case AddRecordMode.Add:
                    await this.OnRecordAdded.InvokeAsync();
                    break;
                case AddRecordMode.Select:
                    this.SelectRecordPanelVisible = !this.SelectRecordPanelVisible;
                    break;
                default:throw SwitchStatementNotImplementException.Create(this.AddRecordMode);
            }
        }
        private void Record_Selected(TItem record)
        {
            if (this.MultipleSelectRecord == false)
            {
                this.SelectRecordPanelVisible = false;
            }
            if (this.EqualityFunc == null)
            {
                this.RecordList.AddIfNotExist(record);
            }
            else
            {
                this.RecordList.AddIfNotExist(record, this.EqualityFunc);
            }
            this.StateHasChanged();
        }
    }
}
