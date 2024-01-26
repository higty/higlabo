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

        private Dictionary<string, object> GetAttributes()
        {
            var d = new Dictionary<string, object>();

            d["class"] = this.Layout switch
            {
                InputFieldPanelLayout.Default => "input-field-panel",
                InputFieldPanelLayout.Flex => "input-field-flex-panel",
                _ => throw SwitchStatementNotImplementException.Create(this.Layout),
            };
            if (this.Name.IsNullOrEmpty() == false) { d["name"] = this.Name; }
            if (this.PanelType.IsNullOrEmpty() == false) { d["panel-type"] = this.PanelType; }

            return d;
        }

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
