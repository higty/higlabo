using Microsoft.AspNetCore.Components;

namespace HigLabo.Web.RazorComponent.Panel;

public partial class LoadingPanel : ComponentBase
{
    [Parameter]
    public List<string> ClassNameList { get; set; } = new() { "loading-panel" };
    [Parameter]
    public string Text { get; set; } = "Loading...";
}
