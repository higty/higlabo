using Microsoft.AspNetCore.Components;

namespace HigLabo.Web.RazorComponent.Input
{
    public partial class InputFieldFlexPanel : ComponentBase
    {
        [Parameter]
        public string Name { get; set; } = "";
        [Parameter]
        public string Text { get; set; } = "";
        [Parameter]
        public string ClassName { get; set; } = "input-field-flex-panel";
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public InputValidateResult ValidateResult { get; set; } = new InputValidateResult(true);
    }
}
