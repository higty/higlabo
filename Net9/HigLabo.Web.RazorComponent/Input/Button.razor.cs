using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HigLabo.Web.RazorComponent.Input;

public partial class Button : ComponentBase
{
    [Parameter]
    public string ClassName { get; set; } ="button radius-button";
    [Parameter]
    public string Text { get; set; } = "";
    [Parameter]
    public bool Executing { get; set; } = false;

    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }

    private async Task Button_Click(MouseEventArgs e)
    {
        if (this.Executing) { return; }

        try
        {
            this.Executing = true;
            this.StateHasChanged();
            await this.OnClick.InvokeAsync(e);
        }
        catch { }
        finally
        {
            this.Executing = false;
            this.StateHasChanged();
        }
    }
}
