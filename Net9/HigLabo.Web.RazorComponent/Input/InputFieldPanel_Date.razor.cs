using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;

namespace HigLabo.Web.RazorComponent.Input;

public partial class InputFieldPanel_Date : ComponentBase
{
    private DateOnly? _ValueInputing = null;

    [Parameter]
    public InputFieldPanelLayout Layout { get; set; } = InputFieldPanelLayout.Default;
    [Parameter]
    public string Name { get; set; } = "";
    [Parameter]
    public string Text { get; set; } = "";
    [Parameter]
    public bool FieldNameVisible { get; set; } = true;

    [Parameter][DisallowNull]
    public ElementReference Textbox { get; set; }
    [Parameter]
    public DateOnly? Value { get; set; } 
    [Parameter]
    public EventCallback<DateOnly?> ValueChanged { get; set; }
    [Parameter]
    public InputValidateResult ValidateResult { get; set; } = new InputValidateResult(true);
    [Parameter]
    public DateDirection DateDirection { get; set; } = DateDirection.Future;
    [Parameter]
    public string DateTimeFormat { get; set; } = "yyyy/MM/dd";
    [Parameter]
    public TimeOnly TimeZone { get; set; } = new TimeOnly(0, 0);
    [Parameter]
    public bool SelectDateCalendarPanelVisible { get; set; } = false;
    [Parameter]
    public EventCallback<FocusEventArgs> OnTextboxBlur { get; set; }

    private void InputText_Input(ChangeEventArgs e)
    {
        if (e.Value == null)
        {
            _ValueInputing = null;
            return;
        }
        var v = e.Value.ToString();
        if (v == null)
        {
            _ValueInputing = null;
            return;
        }

        var pr = new NumberToDateTimeProcessor(this.TimeZone, this.DateDirection);
        pr.Converters.Clear();
        pr.Converters.Add(new NumberToDateTimeConverter_Mdd());
        pr.Converters.Add(new NumberToDateTimeConverter_MMdd());
        pr.Converters.Add(new NumberToDateTimeConverter_yyyyMMdd());

        var date = pr.Convert(v);
        if (date.HasValue)
        {
            this._ValueInputing = date.Value.ToDateOnly();
            this.StateHasChanged();
        }
        else
        {
            _ValueInputing = null;
        }
    }
    private async ValueTask Textbox_Blur(FocusEventArgs e)
    {
        if (_ValueInputing.HasValue)
        {
            await this.OnValueChanged(_ValueInputing);
            _ValueInputing = null;
        }
        await this.OnTextboxBlur.InvokeAsync(e);
    }

    private async ValueTask DateSelected_Callback(DateOnly? date)
    {
        this.SelectDateCalendarPanelVisible = false;
        await this.OnValueChanged(date);
    }

    private async Task OnValueChanged(DateOnly? value)
    {
        this.Value = value;
        await this.ValueChanged.InvokeAsync(value);
    }
}
