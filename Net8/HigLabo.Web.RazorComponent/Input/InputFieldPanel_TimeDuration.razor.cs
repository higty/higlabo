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
        private TimeOnly? _StartTimeInputing = null;
        private TimeOnly? _EndTimeInputing = null;
        
        [Parameter]
        public InputFieldPanelLayout Layout { get; set; } = InputFieldPanelLayout.Default;
        [Parameter]
        public string Name { get; set; } = "";
        [Parameter]
        public string Text { get; set; } = "";
        [Parameter]
        public TimeOnly? StartTime { get; set; } = null;
        [Parameter]
        public EventCallback<TimeOnly?> StartTimeChanged { get; set; }
        [Parameter]
        public TimeOnly? EndTime { get; set; } = null;
        [Parameter]
        public EventCallback<TimeOnly?> EndTimeChanged { get; set; }

        [Parameter]
        public InputValidateResult ValidateResult { get; set; } = new InputValidateResult(true);
     
        [Parameter]
        public SelectEndTimeMode SelectEndTimeMode { get; set; } = SelectEndTimeMode.StartTime;
        [Parameter]
        public Func<TimeOnly?, string> TimeFormat { get; set; } = timeSpan => timeSpan.HasValue ? $"{timeSpan.Value.Hour.ToString("00")}:{timeSpan.Value.Minute.ToString("00")}" : "";
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
                this._StartTimeInputing = TimeOnly.FromDateTime(date.Value);
                Debug.WriteLine($"{v} --> {_StartTimeInputing}");
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
                this.StartTime = this._StartTimeInputing;
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
                this._EndTimeInputing = TimeOnly.FromDateTime(date.Value);
                Debug.WriteLine($"{v} --> {_EndTimeInputing}");
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
                this.EndTime = this._EndTimeInputing;
            }
            await this.OnTextboxBlur.InvokeAsync(e);
        }

        private async ValueTask TimeSelected_Callback(SelectedTimeDuration time)
        {
            if (time.StartTime.HasValue)
            {
                await this.OnStartTimeChanged(time.StartTime);
            }
            if (time.EndTime.HasValue)
            {
                await this.OnEndTimeChanged(time.EndTime);
                this.SelectTimePanelVisible = false;
            }
        }

        private async Task OnStartTimeChanged(TimeOnly? value)
        {
            this.StartTime = value;
            await this.StartTimeChanged.InvokeAsync(value);
        }
        private async Task OnEndTimeChanged(TimeOnly? value)
        {
            this.EndTime = value;
            await this.EndTimeChanged.InvokeAsync(value);
        }
    }
}
