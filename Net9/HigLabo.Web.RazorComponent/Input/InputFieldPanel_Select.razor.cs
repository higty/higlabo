using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;

namespace HigLabo.Web.RazorComponent.Input;

public partial class InputFieldPanel_Select<TItem>
    where TItem: class
{
    [Parameter]
    public InputFieldPanelLayout Layout { get; set; } = InputFieldPanelLayout.Default;
    [Parameter]
    public string Name { get; set; } = "";
    [Parameter]
    public string Text { get; set; } = "";
    [Parameter]
    public bool FieldNameVisible { get; set; } = true;

    [Parameter]
    public TItem? Value { get; set; }
    [Parameter]
    public EventCallback<TItem?> ValueChanged { get; set; }

    [Parameter]
    public ElementReference RecordPanelElementReference { get; set; }
    [Parameter]
    public bool SelectRecordPanelVisible { get; set; } = false;
    [Parameter]
    public List<TItem> RecordList { get; init; } = new();
    public int RecordIndex { get; set; } = -1;
    [Parameter]
    [AllowNull]
    public RenderFragment<TItem> ItemTemplate { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        var l = this.RecordList.ToArray();
        this.RecordList.Clear();
        this.RecordList.AddRange(l);

        this.StateHasChanged();
    }
    private async ValueTask RecordPanel_Keydown(KeyboardEventArgs e)
    {
        if (e.Key == "Escape")
        {
            if (this.RecordIndex == -1)
            {
                this.SelectRecordPanelVisible = false;
                this.StateHasChanged();
                try
                {
                    await this.RecordPanelElementReference.FocusAsync();
                }
                catch { }
                return;
            }
            else
            {
                this.RecordIndex = -1;
            }
        }
        else if (e.Key == "Enter")
        {
            if (this.SelectRecordPanelVisible)
            {
                if (e.Key == " " || e.Key == "Enter")
                {
                    if (this.RecordIndex == -1)
                    {
                        await this.ToggleVisible();
                        return;
                    }
                    this.Value = this.RecordList[this.RecordIndex];
                    this.SelectRecordPanelVisible = false;
                    this.StateHasChanged();
                    await this.ValueChanged.InvokeAsync(this.Value);
                    try
                    {
                        await this.RecordPanelElementReference.FocusAsync();
                    }
                    catch { }
                }
            }
            else
            {
                await this.ToggleVisible();
            }
        }
        else if (e.CtrlKey && e.Key == "ArrowUp")
        {
            if (this.SelectRecordPanelVisible)
            {
                this.RecordIndex = this.RecordIndex - 1;
                if (this.RecordIndex < -1)
                {
                    this.RecordIndex = this.RecordList.Count - 1;
                }
            }
        }
        else if (e.CtrlKey && e.Key == "ArrowDown")
        {
            if (this.SelectRecordPanelVisible)
            {
                this.RecordIndex = this.RecordIndex + 1;
                if (this.RecordIndex >= this.RecordList.Count)
                {
                    this.RecordIndex = -1;
                }
            }
        }
    }
    private async ValueTask ToggleVisible()
    {
        if (this.SelectRecordPanelVisible)
        {
            this.SelectRecordPanelVisible = false;
            await this.RecordPanelElementReference.FocusAsync();
        }
        else
        {
            this.SelectRecordPanelVisible = true;
        }
        this.StateHasChanged();
    }

    private async ValueTask RecordPanel_Click(TItem? value)
    {
        this.Value = value;
        this.SelectRecordPanelVisible = false;
        this.StateHasChanged();
        await this.ValueChanged.InvokeAsync(value);
        try
        {
            await this.RecordPanelElementReference.FocusAsync();
        }
        catch { }
    }

}
