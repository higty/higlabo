using Microsoft.AspNetCore.Components;

namespace HigLabo.Web.RazorComponent.Input
{
    public partial class CheckboxPanel : ComponentBase
    {
        [Parameter]
        public List<string> ClassNameList { get; set; } = new() { "checkbox-panel" };
        [Parameter]
        public EventCallback<bool> ValueChanged { get; set; }
        [Parameter]
        public bool Value { get; set; } = false;
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        private Task OnValueChanged(ChangeEventArgs e)
        {
            if (e.Value == null) { return Task.CompletedTask; }
            var bl = (bool)e.Value;
            this.Value = bl;
            return ValueChanged.InvokeAsync(bl);
        }
    }
}
