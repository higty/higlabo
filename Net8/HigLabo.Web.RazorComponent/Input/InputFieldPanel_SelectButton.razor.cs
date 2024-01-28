using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using HigLabo.Core;

namespace HigLabo.Web.RazorComponent.Input
{
    public partial class InputFieldPanel_SelectButton 
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
        public object? Value { get; set; } 
        [Parameter]
        public EventCallback<object?> ValueChanged { get; set; }
        [Parameter]
        public List<SelectButtonRecord> RecordList { get; init; } = new();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var l = this.RecordList.ToArray();
            this.RecordList.Clear();
            this.RecordList.AddRange(l);

            this.StateHasChanged();
        }
        private async ValueTask RecordValuePanel_Click(object? value)
        {
            this.Value = value;
            this.StateHasChanged();
            await this.ValueChanged.InvokeAsync(value);
        }
        private async ValueTask RecordValuePanel_Keydown(KeyboardEventArgs e, object? value)
        {
            if (e.Key == " " || e.Key == "Enter")
            {
                this.Value = value;
                this.StateHasChanged();
                await this.ValueChanged.InvokeAsync(value);
            }
        }

    }
}
