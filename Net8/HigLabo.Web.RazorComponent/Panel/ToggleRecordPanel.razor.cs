using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace HigLabo.Web.RazorComponent.Panel
{
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
        private Dictionary<string, object> _Attributes { get; set; } = new();
        
        [Parameter]
        public ToggleState ToggleState { get; set; } = ToggleState.Hidden;
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
        public RenderFragment? ContentPanel { get; set; }

        [Parameter]
        public SortGroup SortGroup { get; set; } = new();
        [Parameter]
        public string DragBarPanelClassName { get; set; } = "drag-bar-panel";
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
            if (this.AllowSort)
            {
                _Attributes["draggable"] = "true";
            }
            return _Attributes;
        }

        private void HeaderPanel_Click()
        {
            this.ToggleState = this.ToggleState.GetOpositeToggleState();
        }

        private async ValueTask HeaderPanel_Keydown(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
            {
                this.ToggleState = this.ToggleState.GetOpositeToggleState();
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
            e.DataTransfer.EffectAllowed = "copymove";
            this.SortGroup.DragItem = this;
        }
        private void Drag_Enter()
        {
            this.DragBarPanelClassName = "drag-bar-panel dragging";
            this.DropPanelClassName = "drop-panel dragging";
        }
        private void Drag_Leave()
        {
            this.DragBarPanelClassName = "drag-bar-panel";
            this.DropPanelClassName = "drop-panel";
        }
        private async void Drag_End(DragEventArgs e)
        {
            this.DragBarPanelClassName = "drag-bar-panel";
            this.DropPanelClassName = "drop-panel";
 
            if (this.SortGroup.DragItem == null) { return; }
            await this.OnItemDropped.InvokeAsync(new ItemDroppedEventArgs(this.SortGroup.DragItem.SortIndex, this.SortIndex));
            this.SortGroup.DragItem = null;
        }
    }
}
