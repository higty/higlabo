using Microsoft.AspNetCore.Components;

namespace HigLabo.Web.RazorComponent.Input
{
    public partial class CheckboxPanel 
    {
        [Parameter]
        public string ClassName { get; set; } = "checkbox-panel";
        [Parameter]
        public bool Value { get; set; } = false;
        [Parameter]
        public EventCallback<bool> ValueChanged { get; set; }
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        private Task ValueChanged_Invoke(ChangeEventArgs e)
        {
            if (e.Value == null) { return Task.CompletedTask; }
            var bl = (bool)e.Value;
            this.Value = bl;
            return ValueChanged.InvokeAsync(bl);
        }
    }
}
