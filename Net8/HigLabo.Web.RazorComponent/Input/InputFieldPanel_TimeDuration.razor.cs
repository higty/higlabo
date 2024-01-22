using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.RazorComponent.Input
{
    public partial class InputFieldPanel_TimeDuration
    {
        private TimeSpan? _StartTimeInputing = null;
        private TimeSpan? _EndTimeInputing = null;
        
        [Parameter]
        public InputFieldPanelLayout Layout { get; set; } = InputFieldPanelLayout.Default;
        [Parameter]
        public string Name { get; set; } = "";
        [Parameter]
        public string Text { get; set; } = "";
        [Parameter]
        public bool FieldNameVisible { get; set; } = true;

        [Parameter]
        public TimeSpan? StartTime { get; set; } = null;
        [Parameter]
        public EventCallback<TimeSpan?> StartTimeChanged { get; set; }
        [Parameter]
        public TimeSpan? EndTime { get; set; } = null;
        [Parameter]
        public EventCallback<TimeSpan?> EndTimeChanged { get; set; }

        [Parameter]
        public InputValidateResult ValidateResult { get; set; } = new InputValidateResult(true);
     
        [Parameter]
        public SelectEndTimeMode SelectEndTimeMode { get; set; } = SelectEndTimeMode.StartTime;
        [Parameter]
        public Func<TimeSpan?, string> TimeFormat { get; set; } = timeSpan => timeSpan.HasValue ? $"{timeSpan.Value.Hours.ToString("00")}:{timeSpan.Value.Minutes.ToString("00")}" : "";
        [Parameter]
        public bool SelectTimePanelVisible { get; set; } = false;
        [Parameter]
        public EventCallback<FocusEventArgs> OnTextboxBlur { get; set; }

        private void StartTime_Input(ChangeEventArgs e)
        {
            if (e.Value == null)
            {
                _StartTimeInputing = null;
                return;
            }
            var v = e.Value.ToString();
            if (v == null)
            {
                _StartTimeInputing = null;
                return;
            }

            var pr = new NumberToDateTimeProcessor();
            pr.Converters.Clear();
            pr.Converters.Add(new NumberToDateTimeConverter_Hmm());
            pr.Converters.Add(new NumberToDateTimeConverter_HHmm());

            var date = pr.Convert(v);
            if (date.HasValue)
            {
                this._StartTimeInputing = date.Value.TimeOfDay;
            }
            else
            {
                _StartTimeInputing = null;
            }
        }
        private async ValueTask StartTime_Blur(FocusEventArgs e)
        {
            if (_StartTimeInputing.HasValue)
            {
                await this.OnStartTimeChanged(_StartTimeInputing);
                this.SelectTimePanelVisible = false;
            }
            await this.OnTextboxBlur.InvokeAsync(e);
        }
        private void EndTime_Input(ChangeEventArgs e)
        {
            if (e.Value == null)
            {
                _EndTimeInputing = null;
                return;
            }
            var v = e.Value.ToString();
            if (v == null)
            {
                _EndTimeInputing = null;
                return;
            }

            var pr = new NumberToDateTimeProcessor();
            pr.Converters.Clear();
            pr.Converters.Add(new NumberToDateTimeConverter_Hmm());
            pr.Converters.Add(new NumberToDateTimeConverter_HHmm());

            var date = pr.Convert(v);
            if (date.HasValue)
            {
                this._EndTimeInputing = date.Value.TimeOfDay;
            }
            else
            {
                _EndTimeInputing = null;
            }
        }
        private async ValueTask EndTime_Blur(FocusEventArgs e)
        {
            if (_EndTimeInputing.HasValue)
            {
                await this.OnEndTimeChanged(_EndTimeInputing);
                this.SelectTimePanelVisible = false;
            }
            await this.OnTextboxBlur.InvokeAsync(e);
        }

        private async ValueTask StartTimeSelected_Callback(SelectedTimeDuration time)
        {
            if (time.StartTime.HasValue)
            {
                await this.OnStartTimeChanged(time.StartTime);
            }
        }
        private async ValueTask EndTimeSelected_Callback(SelectedTimeDuration time)
        {
            if (time.EndTime.HasValue)
            {
                await this.OnEndTimeChanged(time.EndTime);
                if (this.StartTime.HasValue)
                {
                    this.SelectTimePanelVisible = false;
                }
            }
        }

        private async Task OnStartTimeChanged(TimeSpan? value)
        {
            this.StartTime = value;
            await this.StartTimeChanged.InvokeAsync(value);
        }
        private async Task OnEndTimeChanged(TimeSpan? value)
        {
            this.EndTime = value;
            await this.EndTimeChanged.InvokeAsync(value);
        }
    }
}
