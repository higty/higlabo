using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.UI
{
    public class InputPropertyDateDropDownListPanel : InputPropertyPanel
    {
        public class RootFlexPanel
        {
            public HtmlAttributes Attributes { get; private set; } = new HtmlAttributes();
            public HtmlElement Year { get; init; } = new HtmlElement();
            public HtmlElement Month { get; init; } = new HtmlElement();
            public HtmlElement Day { get; init; } = new HtmlElement();
        }
        private static CultureInfo _JapaneseCalendarCulture = new CultureInfo("ja-JP", true);
        private Func<Int32, String> _GetYearText = (year) => year.ToString("0000");

        public override InputElementType ElementType => InputElementType.DateDropDownList;
        public RootFlexPanel FlexPanel { get; init; } = new RootFlexPanel();

        public Int32 StartYear { get; set; } = 1900;
        public Int32 EndYear { get; set; } = DateTime.Now.Year;
        public Int32? SelectedYear { get; set; } = null;
        public Int32 SelectedMonth { get; set; } = 1;
        public Int32 SelectedDay { get; set; } = 1;

        public Func<Int32, String> GetYearText
        {
            get { return _GetYearText; }
            set
            {
                if (value == null) { return; }
                _GetYearText = value;
            }
        }

        static InputPropertyDateDropDownListPanel()
        {
            _JapaneseCalendarCulture.DateTimeFormat.Calendar = new JapaneseCalendar();
        }

        public DateOnly? GetSelectedDate()
        {
            if (this.SelectedYear.HasValue)
            {
                return new DateOnly(this.SelectedYear.Value, this.SelectedMonth, this.SelectedDay);
            }
            return null;
        }
        public void SetJapaneseCalendar()
        {
            this.GetYearText = this.GetJapaneseYearText;
        }
        private String GetJapaneseYearText(Int32 year)
        {
            var date = new DateTime(year, 1, 1);
            return date.ToString("ggyy", _JapaneseCalendarCulture) + "年";
        }
    }
}
