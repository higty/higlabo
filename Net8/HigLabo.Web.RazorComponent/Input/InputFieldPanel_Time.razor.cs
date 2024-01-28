using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HigLabo.Web.RazorComponent.Input
{
    public partial class InputFieldPanel_Time
    {
        private TimeSpan? _ValueInputing = null;

        [Parameter]
        public InputFieldPanelLayout Layout { get; set; } = InputFieldPanelLayout.Default;
        [Parameter]
        public string Name { get; set; } = "";
        [Parameter]
        public string Text { get; set; } = "";
        [Parameter]
        public bool FieldNameVisible { get; set; } = true;
        
        [Parameter]
        public TimeSpan? Value { get; set; }
        [Parameter]
        public EventCallback<TimeSpan?> ValueChanged { get; set; }
        [Parameter]
        public InputValidateResult ValidateResult { get; set; } = new InputValidateResult(true);
        [Parameter]
        public DateDirection DateDirection { get; set; } = DateDirection.Future;
        [Parameter]
        public Func<TimeSpan?, string> TimeFormat { get; set; } = timeSpan => timeSpan.HasValue ? $"{timeSpan.Value.Hours.ToString("00")}:{timeSpan.Value.Minutes.ToString("00")}" : "";
        [Parameter]
        public TimeOnly TimeZone { get; set; } = new TimeOnly(0, 0);
        [Parameter]
        public bool SelectTimePanelVisible { get; set; } = false;
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
            pr.Converters.Add(new NumberToDateTimeConverter_HH());
            pr.Converters.Add(new NumberToDateTimeConverter_Hmm());
            pr.Converters.Add(new NumberToDateTimeConverter_HHmm());

            var date = pr.Convert(v);
            if (date.HasValue)
            {
                this._ValueInputing = date.Value.TimeOfDay;
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
                this.SelectTimePanelVisible = false;
                _ValueInputing = null;
            }
            await this.OnTextboxBlur.InvokeAsync(e);
        }

        private async ValueTask TimeSelected_Callback(SelectedTimeDuration time)
        {
            this.SelectTimePanelVisible = false;
            if (time.StartTime.HasValue)
            {
                await this.OnValueChanged(time.StartTime.Value);
            }
        }
        private async Task OnValueChanged(TimeSpan? value)
        {
            this.Value = value;
            await this.ValueChanged.InvokeAsync(value);
        }

    }
}
