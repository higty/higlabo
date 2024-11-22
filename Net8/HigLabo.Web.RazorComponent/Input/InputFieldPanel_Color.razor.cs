using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HigLabo.Web.RazorComponent.Input;

public partial class InputFieldPanel_Color
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
    public string Value { get; set; } = "";
    [Parameter]
    public EventCallback<string> ValueChanged { get; set; }
    [Parameter]
    public InputValidateResult ValidateResult { get; set; } = new InputValidateResult(true);
    [Parameter]
    public bool SelectColorCalendarPanelVisible { get; set; } = false;
    [Parameter]
    public EventCallback<FocusEventArgs> OnTextboxBlur { get; set; }

    private async ValueTask Textbox_Blur(FocusEventArgs e)
    {
        await this.OnTextboxBlur.InvokeAsync(e);
    }

    private async ValueTask ColorSelected_Callback(string color)
    {
        this.SelectColorCalendarPanelVisible = false;
        if (color.IsNullOrEmpty() == false)
        {
            await this.OnValueChanged(color);
        }
    }
    private async Task OnValueChanged(string? value)
    {
        this.Value = value ?? "";
        await this.ValueChanged.InvokeAsync(value);
    }
}
