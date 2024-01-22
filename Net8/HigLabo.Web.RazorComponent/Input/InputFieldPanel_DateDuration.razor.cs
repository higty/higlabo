using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HigLabo.Web.RazorComponent.Input
{
    public partial class InputFieldPanel_DateDuration 
    {
        private DateOnly? _StartDateInputing = null;
        private DateOnly? _EndDateInputing = null;

        [Parameter]
        public InputFieldPanelLayout Layout { get; set; } = InputFieldPanelLayout.Default;
        [Parameter]
        public string Name { get; set; } = "";
        [Parameter]
        public string Text { get; set; } = "";
        [Parameter]
        public bool FieldNameVisible { get; set; } = true;

        [Parameter]
        public DateOnly? StartDate { get; set; } 
        [Parameter]
        public EventCallback<DateOnly?> StartDateChanged { get; set; }
        [Parameter]
        public DateOnly? EndDate { get; set; } 
        [Parameter]
        public EventCallback<DateOnly?> EndDateChanged { get; set; }

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
        public EventCallback<FocusEventArgs> OnStartDateBlur { get; set; }
        [Parameter]
        public EventCallback<FocusEventArgs> OnEndDateBlur { get; set; }

        private void StartDate_Input(ChangeEventArgs e)
        {
            if (e.Value == null)
            {
                _StartDateInputing = null;
                return;
            }
            var v = e.Value.ToString();
            if (v == null)
            {
                _StartDateInputing = null;
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
                this._StartDateInputing = date.ToDateOnly();
            }
            else
            {
                _StartDateInputing = null;
            }
        }
        private async ValueTask StartDate_Blur(FocusEventArgs e)
        {
            if (_StartDateInputing.HasValue)
            {
                await this.OnStartDateChanged(_StartDateInputing);
                this.SelectDateCalendarPanelVisible = false;
            }
            await this.OnStartDateBlur.InvokeAsync(e);
        }
        private void EndDate_Input(ChangeEventArgs e)
        {
            if (e.Value == null)
            {
                _EndDateInputing = null;
                return;
            }
            var v = e.Value.ToString();
            if (v == null)
            {
                _EndDateInputing = null;
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
                this._EndDateInputing = date.ToDateOnly();
            }
            else
            {
                _EndDateInputing = null;
            }
        }
        private async ValueTask EndDate_Blur(FocusEventArgs e)
        {
            if (_EndDateInputing.HasValue)
            {
                await this.OnEndDateChanged(_EndDateInputing);
                this.SelectDateCalendarPanelVisible = false;
            }
            await this.OnEndDateBlur.InvokeAsync(e);
        }

        private async ValueTask DateSelected_Callback(SelectedDateDuration value)
        {
            var v = value;
            this.SelectDateCalendarPanelVisible = false;
            if (v.StartDate.HasValue)
            {
                await this.OnStartDateChanged(v.StartDate.Value);
            }
            if (v.EndDate.HasValue)
            {
                await this.OnEndDateChanged(v.EndDate.Value);
            }
        }

        private async Task OnStartDateChanged(DateOnly? value)
        {
            this.StartDate = value;
            await this.StartDateChanged.InvokeAsync(value);
        }
        private async Task OnEndDateChanged(DateOnly? value)
        {
            this.EndDate = value;
            await this.EndDateChanged.InvokeAsync(value);
        }
    }
}
