using Microsoft.AspNetCore.Components;

namespace HigLabo.Web.RazorComponent.Panel
{
    public enum ActionConfirmPopupPanelPosition
    {
        Left,
        Right,
    }
    public partial class ActionConfirmPanel
    {
        [Parameter]
        public string Name { get; set; } = "";
        [Parameter]
        public string Message { get; set; } = "";
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public string ButtonText { get; set; } = "";
        [Parameter]
        public bool PopupPanelVisible { get; set; } = false;
        [Parameter]
        public ActionConfirmPopupPanelPosition PopupPanelPosition { get; set; }
        [Parameter]
        public EventCallback OnExecute { get; set; }

        private async ValueTask ExecuteButton_Click()
        {
            this.PopupPanelVisible = false;
            await this.OnExecute.InvokeAsync();
        }
    }
}
