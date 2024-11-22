using Microsoft.AspNetCore.Components;

namespace HigLabo.Web.RazorComponent.Input;

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

    private async ValueTask ValueChanged_Invoke(ChangeEventArgs e)
    {
        if (e.Value is bool bl)
        {
            this.Value = bl;
            await ValueChanged.InvokeAsync(bl);
        }
    }
}
