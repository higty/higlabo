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
    public partial class InputFieldFlexPanel_DateDuration : ComponentBase
    {
        private string _StartDateInputing = "";
        private string _EndDateInputing = "";

        [Parameter]
        public string Name { get; set; } = "";
        [Parameter]
        public string Text { get; set; } = "";
        [Parameter]
        public string StartDate { get; set; } = "";
        [Parameter]
        public string EndDate { get; set; } = "";
        [Parameter]
        public string ClassName { get; set; } = "input-field-flex-panel";
        [Parameter]
        public InputValidateResult ValidateResult { get; set; } = new InputValidateResult(true);
        [Parameter]
        public string DateTimeFormat { get; set; } = "yyyy/MM/dd";
        [Parameter]
        public TimeOnly TimeZone { get; set; } = new TimeOnly(0, 0);
        [Parameter]
        public bool SelectDateCalendarPanelVisible { get; set; } = false;
        [Parameter]
        public EventCallback<FocusEventArgs> OnBlur { get; set; }

        private void StartDate_Input(ChangeEventArgs e)
        {
            if (e.Value == null)
            {
                _StartDateInputing = "";
                return;
            }
            var v = e.Value.ToString();
            if (v == null)
            {
                _StartDateInputing = "";
                return;
            }

            var pr = new NumberToDateTimeProcessor(this.TimeZone, DateDirection.Future);
            pr.Converters.Clear();
            pr.Converters.Add(new NumberToDateTimeConverter_Mdd());
            pr.Converters.Add(new NumberToDateTimeConverter_MMdd());
            pr.Converters.Add(new NumberToDateTimeConverter_yyyyMMdd());

            var date = pr.Convert(v);
            if (date.HasValue)
            {
                this._StartDateInputing = date.Value.ToString(this.DateTimeFormat);
                Debug.WriteLine($"{v} --> {_StartDateInputing}");
            }
            else
            {
                _StartDateInputing = "";
            }
        }
        private async ValueTask StartDate_Blur(FocusEventArgs e)
        {
            if (this.StartDate.IsNullOrEmpty())
            {
                this.StartDate = this._StartDateInputing;
            }
            await this.OnBlur.InvokeAsync(e);
        }
        private void EndDate_Input(ChangeEventArgs e)
        {
            if (e.Value == null)
            {
                _EndDateInputing = "";
                return;
            }
            var v = e.Value.ToString();
            if (v == null)
            {
                _EndDateInputing = "";
                return;
            }

            var pr = new NumberToDateTimeProcessor(this.TimeZone, DateDirection.Future);
            pr.Converters.Clear();
            pr.Converters.Add(new NumberToDateTimeConverter_Mdd());
            pr.Converters.Add(new NumberToDateTimeConverter_MMdd());
            pr.Converters.Add(new NumberToDateTimeConverter_yyyyMMdd());

            var date = pr.Convert(v);
            if (date.HasValue)
            {
                this._EndDateInputing = date.Value.ToString(this.DateTimeFormat);
                Debug.WriteLine($"{v} --> {_EndDateInputing}");
            }
            else
            {
                _EndDateInputing = "";
            }
        }
        private async ValueTask EndDate_Blur(FocusEventArgs e)
        {
            if (this.EndDate.IsNullOrEmpty())
            {
                this.EndDate = this._EndDateInputing;
            }
            await this.OnBlur.InvokeAsync(e);
        }

        private void DateSelected_Callback(SelectedDateDuration value)
        {
            var v = value;
            this.SelectDateCalendarPanelVisible = false;
            if (v.StartDate.HasValue)
            {
                this.StartDate = v.StartDate.Value.ToString(this.DateTimeFormat);
            }
            if (v.EndDate.HasValue)
            {
                this.EndDate = v.EndDate.Value.ToString(this.DateTimeFormat);
            }
        }
    }
}
