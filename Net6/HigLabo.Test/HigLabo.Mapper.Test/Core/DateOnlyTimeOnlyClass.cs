using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Mapper.Test
{
    public class DateOnlyTimeOnlyClass
    {
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
    }
    public class DateOnlyTimeOnlyNullableClass
    {
        public DateOnly? Date { get; set; }
        public TimeOnly? Time { get; set; }
    }
    public class DateTimeClass
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
    public class DateTimeOffsetClass
    {
        public DateTimeOffset Date { get; set; }
    }
}
