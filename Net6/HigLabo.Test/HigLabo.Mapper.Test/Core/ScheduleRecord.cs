using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Mapper.Test
{
    public class ScheduleRecord 
    {
        public String Title { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
    }

    public class ScheduleRecordChild : ScheduleRecord
    {
        public new Date_HourMinute_Record StartTime { get; set; } = new Date_HourMinute_Record();
        public new Date_HourMinute_Record EndTime { get; set; } = new Date_HourMinute_Record();
    }
    public class Date_HourMinute_Record
    {
        public String Date { get; set; }
        public String HourMinute { get; set; }
        public String TimeZone { get; set; }
    }
}
