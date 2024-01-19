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
    public partial class InputFieldPanel_Color
    {
        private string _ValueInputing = "";

        [Parameter]
        public string Name { get; set; } = "";
        [Parameter]
        public string Text { get; set; } = "";
        [Parameter]
        public string Value { get; set; } = "";
        [Parameter]
        public string ClassName { get; set; } = "input-field-panel";
        [Parameter]
        public InputValidateResult ValidateResult { get; set; } = new InputValidateResult(true);
        [Parameter]
        public bool SelectColorCalendarPanelVisible { get; set; } = false;
        [Parameter]
        public EventCallback<FocusEventArgs> OnBlur { get; set; }

        private async ValueTask InputText_Blur(FocusEventArgs e)
        {
            await this.OnBlur.InvokeAsync(e);
        }

        private void ColorSelected_Callback(string color)
        {
            this.SelectColorCalendarPanelVisible = false;
            this.Value = color;
        }
    }
}
