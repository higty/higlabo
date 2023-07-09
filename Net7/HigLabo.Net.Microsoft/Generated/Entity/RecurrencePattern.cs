using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/recurrencepattern?view=graph-rest-1.0
    /// </summary>
    public partial class RecurrencePattern
    {
        public enum RecurrencePatternDayOfWeek
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            RelativeMonthly,
            RelativeYearly,
            Weekly,
        }
        public enum RecurrencePatternWeekIndex
        {
            First,
            Second,
            Third,
            Fourth,
            Last,
            RelativeMonthly,
            RelativeYearly,
        }
        public enum RecurrencePatternRecurrencePatternType
        {
            Daily,
            Weekly,
            AbsoluteMonthly,
            RelativeMonthly,
            AbsoluteYearly,
            RelativeYearly,
        }

        public Int32? DayOfMonth { get; set; }
        public RecurrencePatternDayOfWeek DaysOfWeek { get; set; }
        public RecurrencePatternDayOfWeek FirstDayOfWeek { get; set; }
        public RecurrencePatternWeekIndex Index { get; set; }
        public Int32? Interval { get; set; }
        public Int32? Month { get; set; }
        public RecurrencePatternRecurrencePatternType Type { get; set; }
    }
}
