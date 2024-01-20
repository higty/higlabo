using Microsoft.AspNetCore.Components;

namespace HigLabo.Web.RazorComponent.Input
{
    public partial class InputFieldPanel : ComponentBase
    {
        [Parameter]
        public InputFieldPanelLayout Layout { get; set; } = InputFieldPanelLayout.Default;
        [Parameter]
        public string Name { get; set; } = "";
        [Parameter]
        public string Text { get; set; } = "";
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public InputValidateResult ValidateResult { get; set; } = new InputValidateResult(true);

    }
}
