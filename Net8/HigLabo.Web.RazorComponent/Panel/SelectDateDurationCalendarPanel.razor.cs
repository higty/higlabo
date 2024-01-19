using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace HigLabo.Web.RazorComponent.Panel
{
    public partial class SelectDateDurationCalendarPanel : ComponentBase
    {
        public enum DateSelectMode
        {
            Start,
            End,
        }
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
        [Parameter]
        public TimeOnly TimeZone { get; set; } = new TimeOnly(0, 0);

        public DateSelectMode SelectMode { get; set; } = DateSelectMode.Start;
        public DayOfWeek StartDayOfWeek { get; set; } = DayOfWeek.Monday;
        public DateOnly Date { get; set; } = DateTime.Now.ToDateOnly();
        [Parameter]
        public DateOnly? StartDate { get; set; } = DateTime.Now.ToDateOnly();
        public DateOnly? StartDateInput { get; set; } = DateTime.Now.ToDateOnly();
        [Parameter]
        public DateOnly? EndDate { get; set; } = DateTime.Now.ToDateOnly();
        public DateOnly? EndDateInput { get; set; } = DateTime.Now.ToDateOnly();
        public List<WeekTableRow> WeekList { get; init; } = new();
        [Parameter]
        public EventCallback<(DateOnly? StartDate, DateOnly? EndDate)> DateSelected { get; set; }

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

        private void StartDate_Focus()
        {
            StartDateInput = StartDate;
        }
        private void StartDate_Input(ChangeEventArgs e)
        {
            var pr = new NumberToDateTimeProcessor(this.TimeZone, DateDirection.Future);
            pr.Converters.Clear();
            pr.Converters.Add(new NumberToDateTimeConverter_Mdd());
            pr.Converters.Add(new NumberToDateTimeConverter_MMdd());
            StartDateInput = pr.Convert(e.Value!.ToString()).ToDateOnly();
        }
        private void StartDate_Blur()
        {
            StartDate = StartDateInput;
            StateHasChanged();
        }
        private void EndDate_Focus()
        {
            EndDateInput = EndDate;
        }
        private void EndDate_Input(ChangeEventArgs e)
        {
            var pr = new NumberToDateTimeProcessor(this.TimeZone, DateDirection.Future);
            pr.Converters.Clear();
            pr.Converters.Add(new NumberToDateTimeConverter_Mdd());
            pr.Converters.Add(new NumberToDateTimeConverter_MMdd());
            EndDateInput = pr.Convert(e.Value!.ToString()).ToDateOnly();
        }
        private void EndDate_Blur()
        {
            EndDate = EndDateInput;
            StateHasChanged();
        }

        private void Date_Click(DateOnly date)
        {
            switch (SelectMode)
            {
                case DateSelectMode.Start:
                    StartDate = date;
                    SelectMode = DateSelectMode.End;
                    break;
                case DateSelectMode.End:
                    EndDate = date;
                    SelectMode = DateSelectMode.Start;
                    break;
                default: throw SwitchStatementNotImplementException.Create(SelectMode);
            }
        }

        private async ValueTask SelectButton_Click()
        {
            await Callback_Invoke(StartDate, EndDate);
        }
        private async ValueTask ClsoeButton_Click()
        {
            await Callback_Invoke(null, null);
        }
        private async ValueTask Callback_Invoke(DateOnly? startDate, DateOnly? endDate)
        {
            await this.DateSelected.InvokeAsync((startDate, endDate));
        }
    }
}
