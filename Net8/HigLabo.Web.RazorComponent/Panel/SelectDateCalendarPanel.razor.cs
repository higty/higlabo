using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace HigLabo.Web.RazorComponent.Panel
{
    public partial class SelectDateCalendarPanel : ComponentBase
    {
        public class WeekTableRow
        {
            public List<DateTableCell> DateList { get; init; } = new();
        }
        public class DateTableCell
        {
            public DateOnly Date { get; set; }
            public DateTableCell(DateOnly date)
            {
                Date = date;
            }
        }

        [Parameter]
        public DateTimeFormatInfo DateTimeFormat { get; set; } = CultureInfo.CurrentCulture.DateTimeFormat;
        public DayOfWeek StartDayOfWeek { get; set; } = DayOfWeek.Monday;
        public DateOnly Date { get; set; } = DateTime.Now.ToDateOnly();
        public List<WeekTableRow> WeekList { get; init; } = new();

        [Parameter]
        public EventCallback<DateOnly?> DateSelected { get; set; }
        [Parameter]
        public EventCallback OnClosed { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            LoadData();
        }

		public DateTime GetFirstDate()
        {
            var date = new DateTime(Date.Year, Date.Month, 1);
            return date.GetPreviouseDate(StartDayOfWeek);
        }
        public void LoadData()
        {
            var date = GetFirstDate();

            WeekList.Clear();
            for (int wIndex = 0; wIndex < 6; wIndex++)
            {
                var rWeek = new WeekTableRow();
                WeekList.Add(rWeek);
                for (int dIndex = 0; dIndex < 7; dIndex++)
                {
                    var rDate = new DateTableCell(date.AddDays(wIndex * 7 + dIndex).ToDateOnly());
                    rWeek.DateList.Add(rDate);
                }
            }
        }

        private void ChangeMonth(int value)
        {
            Date = Date.AddMonths(value);
            LoadData();
        }
        private async ValueTask Date_Click(DateOnly date)
        {
            await this.DateSelected.InvokeAsync(date);
        }
        private async ValueTask CloseButton_Click()
        {
            await this.OnClosed.InvokeAsync();
        }
    }
}
