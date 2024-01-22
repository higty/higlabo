using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HigLabo.Web.RazorComponent.Input
{
    public partial class InputFieldPanel_SelectButton 
    {
        public class Record
        {
            public string Value { get; set; } = "";
            public string Text { get; set; } = "";

            public Record()
            {
            }
            public Record(string value)
            {
                this.Value = value;
                this.Text = value;
            }
            public Record(string value, string text)
            {
                this.Value = value;
                this.Text = text;
            }
            public static Record SelectFunc<T>(T value)
                where T: struct, Enum
            {
                var r = new Record();
                r.Value = value.ToStringFromEnum();
                r.Text = value.ToStringFromEnum();
                return r;
            }
        }

        [Parameter]
        public InputFieldPanelLayout Layout { get; set; } = InputFieldPanelLayout.Default;
        [Parameter]
        public string Name { get; set; } = "";
        [Parameter]
        public string Text { get; set; } = "";
        [Parameter]
        public bool FieldNameVisible { get; set; } = true;

        [Parameter]
        public string SelectedValue { get; set; } = "";
        [Parameter]
        public List<Record> RecordList { get; init; } = new();
        [Parameter]
        public EventCallback<string> ValueChanged { get; set; } = new();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var l = this.RecordList.ToArray();
            this.RecordList.Clear();
            this.RecordList.AddRange(l);

            this.StateHasChanged();
        }
        private async ValueTask RecordValuePanel_Click(string value)
        {
            this.SelectedValue = value;
            await this.ValueChanged.InvokeAsync(value);
        }
        private async ValueTask RecordValuePanel_Keydown(KeyboardEventArgs e, string value)
        {
            if (e.Key == " " || 
                e.Key == "Enter")
            {
                this.SelectedValue = value;
                await this.ValueChanged.InvokeAsync(value);
                this.StateHasChanged();
            }
        }

        public static List<Record> CreateRecordList<TEnum>()
            where TEnum : struct, Enum
        {
            var l = Enum.GetValues<TEnum>().Select(el => new Record(el.ToStringFromEnum(), T.Text.Get(el))).ToList();
            return l;
        }
        public static List<Record> CreateRecordList<TEnum>(IEnumerable<TEnum> recordList)
            where TEnum : struct, Enum
        {
            var l = recordList.Select(el => new Record(el.ToStringFromEnum(), T.Text.Get(el))).ToList();
            return l;
        }
        public static List<Record> CreateRecordList<TEnum>(params TEnum[] recordList)
            where TEnum : struct, Enum
        {
            var l = recordList.Select(el => new Record(el.ToStringFromEnum(), T.Text.Get(el))).ToList();
            return l;
        }
    }
}
