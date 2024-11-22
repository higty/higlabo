using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace HigLabo.Web.RazorComponent.Panel;

public class SortGroup
{
    public ToggleRecordPanel? DragItem { get; set; }

    public void Sort<T>(List<T> list, ItemDroppedEventArgs e)
    {
        var item = list[e.DragIndex];
        if (e.DragIndex < e.DropIndex)
        {
            list.Remove(item);
            list.Insert(e.DropIndex, item);
        }
        else if (e.DragIndex > e.DropIndex)
        {
            list.Remove(item);
            list.Insert(e.DropIndex + 1, item);
        }
    }
}
public class ItemDroppedEventArgs
{
    public int DragIndex { get; set; }
    public int DropIndex { get; set; }

    public ItemDroppedEventArgs(int dragIndex, int dropIndex)
    {
        DragIndex = dragIndex;
        DropIndex = dropIndex;
    }
}
public partial class ToggleRecordPanel
{       
    [Parameter]
    public ToggleState ToggleState { get; set; } = ToggleState.Hidden;
    [Parameter]
    public EventCallback<ToggleState> ToggleStateChanged { get; set; }
    [Parameter]
    public bool AllowSort { get; set; } = false;
    [Parameter]
    public int SortIndex { get; set; } = -1;
    [Parameter]
    public bool AllowHeaderEdit { get; set; } = false;
    [Parameter]
    public bool AllowDelete { get; set; } = false;
    [Parameter]
    public string HeaderText { get; set; } = "";
    [Parameter]
    public string HeaderTextboxPlaceHolder { get; set; } = "";
    [Parameter]
    public RenderFragment? HeaderPanel { get; set; }
    [Parameter]
    public RenderFragment? ContentPanel { get; set; }

    [Parameter]
    public SortGroup SortGroup { get; set; } = new();
    [Parameter]
    public string DropPanelClassName { get; set; } = "drop-panel";
    [Parameter]
    public EventCallback<ItemDroppedEventArgs> OnItemDropped { get; set; }

    [Parameter]
    public EventCallback<ChangeEventArgs> HeaderTextbox_Input { get; set; }
    [Parameter]
    public EventCallback Deleted { get; set; }

    private Dictionary<string, object> GetAttributes()
    {
        var d = new Dictionary<string, object>();

        if (this.AllowSort)
        {
            d["draggable"] = "true";
            d["ondragover"] = "event.preventDefault();";
        }
        return d;
    }

    private async ValueTask HeaderPanel_Click()
    {
        this.ToggleState = this.ToggleState.GetOpositeToggleState();
        await this.ToggleStateChanged.InvokeAsync(this.ToggleState);
    }

    private async ValueTask HeaderPanel_Keydown(KeyboardEventArgs e)
    {
        if (e.Key == "Enter")
        {
            this.ToggleState = this.ToggleState.GetOpositeToggleState();
            await this.ToggleStateChanged.InvokeAsync(this.ToggleState);
        }
        if (e.Key == "Delete")
        {
            await this.Deleted.InvokeAsync();
        }
    }
    private async ValueTask DeleteIcon_Click()
    {
        await this.Deleted.InvokeAsync();
    }
    private async ValueTask DeleteIcon_Keydown(KeyboardEventArgs e)
    {
        if (e.Key == "Enter")
        {
            await this.Deleted.InvokeAsync();
        }
    }

    private void Drag_Start(DragEventArgs e)
    {
        e.DataTransfer.EffectAllowed = "copyMove";
        this.SortGroup.DragItem = this;
    }
    private void Drag_Enter()
    {
        this.DropPanelClassName = "drop-panel dragging";
        this.StateHasChanged();
    }
    private void Drag_Leave()
    {
        this.DropPanelClassName = "drop-panel";
    }
    private async ValueTask Drag_End(DragEventArgs e)
    {
        this.DropPanelClassName = "drop-panel";

        if (this.SortGroup.DragItem == null) { return; }
        await this.OnItemDropped.InvokeAsync(new ItemDroppedEventArgs(this.SortGroup.DragItem.SortIndex, this.SortIndex));
        this.SortGroup.DragItem = null;
    }
}
