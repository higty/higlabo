using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.RazorComponent.Input
{
    public partial class InputFieldPanel_Time
    {
        private string _ValueInputing = "";

        [Parameter]
        public InputFieldPanelLayout Layout { get; set; } = InputFieldPanelLayout.Default;
        [Parameter]
        public string Name { get; set; } = "";
        [Parameter]
        public string Text { get; set; } = "";
        [Parameter]
        public string Value { get; set; } = "";
        [Parameter]
        public InputValidateResult ValidateResult { get; set; } = new InputValidateResult(true);
        [Parameter]
        public DateDirection DateDirection { get; set; } = DateDirection.Future;
        [Parameter]
        public Func<TimeSpan, string> TimeFormat { get; set; } = timeSpan => $"{timeSpan.TotalHours.ToString("00")}:{timeSpan.Minutes.ToString("00")}";
        [Parameter]
        public bool SelectTimePanelVisible { get; set; } = false;
        [Parameter]
        public EventCallback<FocusEventArgs> OnTextboxBlur { get; set; }

        private void InputText_Input(ChangeEventArgs e)
        {
            if (e.Value == null)
            {
                _ValueInputing = "";
                return;
            }
            var v = e.Value.ToString();
            if (v == null)
            {
                _ValueInputing = "";
                return;
            }

            var pr = new NumberToDateTimeProcessor();
            pr.Converters.Clear();
            pr.Converters.Add(new NumberToDateTimeConverter_Hmm());
            pr.Converters.Add(new NumberToDateTimeConverter_HHmm());

            var date = pr.Convert(v);
            if (date.HasValue)
            {
                this._ValueInputing = this.TimeFormat(date.Value.TimeOfDay);
                Debug.WriteLine($"{v} --> {_ValueInputing}");
            }
            else
            {
                _ValueInputing = "";
            }
        }
        private async ValueTask Textbox_Blur(FocusEventArgs e)
        {
            if (_ValueInputing.IsNullOrEmpty() == false)
            {
                this.Value = this._ValueInputing;
            }
            await this.OnTextboxBlur.InvokeAsync(e);
        }

        private void TimeSelected_Callback(SelectedTimeDuration time)
        {
            this.SelectTimePanelVisible = false;
            if (time.StartTime.HasValue)
            {
                this.Value = this.TimeFormat(time.StartTime.Value);
            }
        }

    }
}
