using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Mapper.Test
{
    public class User
    {
        public String Value { get; set; }
        public String Name { get; set; }
        public MapPoint MapPoint { get; set; }
        
        public Int32 Int32 { get; set; }
        public Int32? Int32Nullable { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime? DateTimeNullable { get; set; }
        public Decimal Decimal { get; set; }
        public Decimal? DecimalNullable { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DayOfWeek? DayOfWeekNullable { get; set; }

        public User ParentUser { get; set; }
        public List<User> Users { get; set; }

        public User()
        {
            this.Users = new List<User>();
            this.MapPoint = new MapPoint();

            this.Name = "TestUser1";
            this.Int32 = 3;
            this.DateTime = new DateTime(2014, 12, 16);
            this.Decimal = 20.4m;
            this.DayOfWeek = DayOfWeek.Monday; 
        }
    }
}
