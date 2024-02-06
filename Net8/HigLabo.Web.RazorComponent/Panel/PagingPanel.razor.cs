using Microsoft.AspNetCore.Components;

namespace HigLabo.Web.RazorComponent.Panel
{
    public partial class PagingPanel : ComponentBase
    {
        public int PageIndex { get; set; } = 0;
        public bool PageListPanelVisible { get; set; } = false; 
        [Parameter]
        public int PageCount { get; set; } = 1;
        [Parameter]
        public EventCallback<int> PageChanged { get; set; }

        public async ValueTask ChangePageIndex(int pageIndex)
        {
            this.PageListPanelVisible = false;
            this.StateHasChanged();

            this.PageIndex = pageIndex;
            if (this.PageIndex < 0)
            {
                this.PageIndex = 0;
            }
            else
            {
                await this.PageChanged.InvokeAsync(this.PageIndex);
            }
        }
    }
}
