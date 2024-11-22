using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Core;

namespace HigLabo.Net.Slack;

public enum RecurrenceFrequency
{
    Daily,
    Weekly,
    Monthly,
    Yearly
}
public class Recurrence
{
    public RecurrenceFrequency Frequency { get; set; } = RecurrenceFrequency.Daily;
    public List<DayOfWeek> DayOfWeeks { get; init; } = new();

    public override string ToString()
    {
        switch (this.Frequency)
        {
            case RecurrenceFrequency.Weekly:
                var dayOfWeekList = String.Join(',', this.DayOfWeeks.Select(el => "\"" + el.ToStringFromEnum().ToLower() + "\""));
                return "{\"frequency\": \"" + this.Frequency.ToStringFromEnum().ToLower() + "\", \"weekdays\": [" + dayOfWeekList + "] }";
            case RecurrenceFrequency.Daily:
            case RecurrenceFrequency.Monthly:
            case RecurrenceFrequency.Yearly:
                return "{\"frequency\": \"" + this.Frequency.ToStringFromEnum().ToLower() + "\" }";
            default: throw new SwitchStatementNotImplementException<RecurrenceFrequency>(this.Frequency);
        }
    }
}
