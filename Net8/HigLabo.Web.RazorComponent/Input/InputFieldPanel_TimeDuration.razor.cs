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
        private string _StartTimeInputing = "";
        private string _EndTimeInputing = "";
        
        [Parameter]
        public InputFieldPanelLayout Layout { get; set; } = InputFieldPanelLayout.Default;
        [Parameter]
        public string Name { get; set; } = "";
        [Parameter]
        public string Text { get; set; } = "";
        [Parameter]
        public string StartTime { get; set; } = "";
        [Parameter]
        public string EndTime { get; set; } = "";
        [Parameter]
        public InputValidateResult ValidateResult { get; set; } = new InputValidateResult(true);
     
        [Parameter]
        public SelectEndTimeMode SelectEndTimeMode { get; set; } = SelectEndTimeMode.StartTime;
        [Parameter]
        public Func<TimeSpan, string> TimeFormat { get; set; } = timeSpan => $"{((int)timeSpan.TotalHours).ToString("00")}:{timeSpan.Minutes.ToString("00")}";
        [Parameter]
        public bool SelectTimePanelVisible { get; set; } = false;
        [Parameter]
        public EventCallback<FocusEventArgs> OnTextboxBlur { get; set; }

        private void StartTime_Input(ChangeEventArgs e)
        {
            if (e.Value == null)
            {
                _StartTimeInputing = "";
                return;
            }
            var v = e.Value.ToString();
            if (v == null)
            {
                _StartTimeInputing = "";
                return;
            }

            var pr = new NumberToDateTimeProcessor();
            pr.Converters.Clear();
            pr.Converters.Add(new NumberToDateTimeConverter_Hmm());
            pr.Converters.Add(new NumberToDateTimeConverter_HHmm());

            var date = pr.Convert(v);
            if (date.HasValue)
            {
                this._StartTimeInputing = this.TimeFormat(date.Value.TimeOfDay);
                Debug.WriteLine($"{v} --> {_StartTimeInputing}");
            }
            else
            {
                _StartTimeInputing = "";
            }
        }
        private async ValueTask StartTime_Blur(FocusEventArgs e)
        {
            if (_StartTimeInputing.IsNullOrEmpty() == false)
            {
                this.StartTime = this._StartTimeInputing;
            }
            await this.OnTextboxBlur.InvokeAsync(e);
        }
        private void EndTime_Input(ChangeEventArgs e)
        {
            if (e.Value == null)
            {
                _EndTimeInputing = "";
                return;
            }
            var v = e.Value.ToString();
            if (v == null)
            {
                _EndTimeInputing = "";
                return;
            }

            var pr = new NumberToDateTimeProcessor();
            pr.Converters.Clear();
            pr.Converters.Add(new NumberToDateTimeConverter_Hmm());
            pr.Converters.Add(new NumberToDateTimeConverter_HHmm());

            var date = pr.Convert(v);
            if (date.HasValue)
            {
                this._EndTimeInputing = this.TimeFormat(date.Value.TimeOfDay);
                Debug.WriteLine($"{v} --> {_EndTimeInputing}");
            }
            else
            {
                _EndTimeInputing = "";
            }
        }
        private async ValueTask EndTime_Blur(FocusEventArgs e)
        {
            if (_EndTimeInputing.IsNullOrEmpty() == false)
            {
                this.EndTime = this._EndTimeInputing;
            }
            await this.OnTextboxBlur.InvokeAsync(e);
        }

        private void TimeSelected_Callback(SelectedTimeDuration time)
        {
            if (time.StartTime.HasValue)
            {
                this.StartTime = this.TimeFormat(time.StartTime.Value);
            }
            if (time.EndTime.HasValue)
            {
                this.EndTime = this.TimeFormat(time.EndTime.Value);
                this.SelectTimePanelVisible = false;
            }
        }
    }
}
