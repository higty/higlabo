using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HigLabo.Web.RazorComponent.Input
{
    public partial class InputFieldPanel 
    {
        [Parameter]
        public InputFieldPanelLayout Layout { get; set; } = InputFieldPanelLayout.Default;
        [Parameter]
        public string PanelType { get; set; } = "";
        [Parameter]
        public string Name { get; set; } = "";
        [Parameter]
        public string Text { get; set; } = "";
		[Parameter]
		public bool FieldNameVisible { get; set; } = true;
		[Parameter]
		public bool AddIconVisible { get; set; } = false;
		[Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public InputValidateResult ValidateResult { get; set; } = new InputValidateResult(true);
        [Parameter]
        public EventCallback OnAddIconClicked { get; set; }

        private async ValueTask AddIcon_Click()
        {
            await this.OnAddIconClicked.InvokeAsync();
        }
        private async ValueTask AddIcon_Keydown(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                await this.OnAddIconClicked.InvokeAsync();
            }
        }
    }
}
