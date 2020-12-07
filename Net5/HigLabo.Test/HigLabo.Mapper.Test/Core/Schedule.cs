using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Mapper.Test
{
    public class Schedule
    {
        public String Title { get; set; }
        public User CreateUser { get; set; }
        public List<User> UserList { get; private set; } = new List<User>();
    }
    public class AllDaySchedule : Schedule
    {
    }
}
