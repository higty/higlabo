using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.RazorComponent.Input
{
    public partial class InputFieldPanel_DateTime
    {
        private DateOnly? _DateInputing = null;
        private TimeSpan? _TimeInputing = null;

        [Parameter]
        public InputFieldPanelLayout Layout { get; set; } = InputFieldPanelLayout.Default;
        [Parameter]
        public string Name { get; set; } = "";
        [Parameter]
        public string Text { get; set; } = "";
        [Parameter]
        public bool FieldNameVisible { get; set; } = true;

        [Parameter]
        [DisallowNull]
        public ElementReference Textbox { get; set; }
        [Parameter]
        public DateOnly? Date { get; set; }
        [Parameter]
        public EventCallback<DateOnly?> DateChanged { get; set; }
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
        public EventCallback<FocusEventArgs> OnDateTextboxBlur { get; set; }

        [Parameter]
        public TimeSpan? Time { get; set; }
        [Parameter]
        public EventCallback<TimeSpan?> TimeChanged { get; set; }
        [Parameter]
        public Func<TimeSpan?, string> TimeFormat { get; set; } = timeSpan => timeSpan.HasValue ? $"{timeSpan.Value.Hours.ToString("00")}:{timeSpan.Value.Minutes.ToString("00")}" : "";
        [Parameter]
        public bool SelectTimePanelVisible { get; set; } = false;
        [Parameter]
        public EventCallback<FocusEventArgs> OnTimeTextboxBlur { get; set; }

        private void InputText_Input(ChangeEventArgs e)
        {
            if (e.Value == null)
            {
                _DateInputing = null;
                return;
            }
            var v = e.Value.ToString();
            if (v == null)
            {
                _DateInputing = null;
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
                this._DateInputing = date.Value.ToDateOnly();
                this.StateHasChanged();
            }
            else
            {
                _DateInputing = null;
            }
        }
        private async ValueTask Textbox_Blur(FocusEventArgs e)
        {
            if (_DateInputing.HasValue)
            {
                await this.OnDateChanged(_DateInputing);
                _DateInputing = null;
            }
            await this.OnDateTextboxBlur.InvokeAsync(e);
        }

        private async ValueTask DateSelected_Callback(DateOnly? date)
        {
            this.SelectDateCalendarPanelVisible = false;
            await this.OnDateChanged(date);
        }

        private async Task OnDateChanged(DateOnly? value)
        {
            this.Date = value;
            await this.DateChanged.InvokeAsync(value);
        }

        private void TimeTexbox_Input(ChangeEventArgs e)
        {
            if (e.Value == null)
            {
                _TimeInputing = null;
                return;
            }
            var v = e.Value.ToString();
            if (v == null)
            {
                _TimeInputing = null;
                return;
            }

            var pr = new NumberToDateTimeProcessor(this.TimeZone, this.DateDirection);
            pr.Converters.Clear();
            pr.Converters.Add(new NumberToDateTimeConverter_HH());
            pr.Converters.Add(new NumberToDateTimeConverter_Hmm());
            pr.Converters.Add(new NumberToDateTimeConverter_HHmm());

            var date = pr.Convert(v);
            if (date.HasValue)
            {
                this._TimeInputing = date.Value.TimeOfDay;
            }
            else
            {
                _TimeInputing = null;
            }
        }
        private async ValueTask TimeTextbox_Blur(FocusEventArgs e)
        {
            if (_TimeInputing.HasValue)
            {
                await this.OnTimeChanged(_TimeInputing);
                this.SelectTimePanelVisible = false;
                _TimeInputing = null;
            }
            await this.OnTimeTextboxBlur.InvokeAsync(e);
        }

        private async ValueTask TimeSelected_Callback(SelectedTimeDuration time)
        {
            this.SelectTimePanelVisible = false;
            if (time.StartTime.HasValue)
            {
                await this.OnTimeChanged(time.StartTime.Value);
            }
        }
        private async Task OnTimeChanged(TimeSpan? value)
        {
            this.Time = value;
            await this.TimeChanged.InvokeAsync(value);
        }
    }
}
