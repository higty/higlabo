using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Mapper.Test
{
    public class Sys_Database
    {
        public String Name { get; set; }
        public Int32 Database_ID { get; set; }
        public DateTime Create_Date { get; set; }
        public Int32 Compatibility_Level { get; set; }
        public String Collation_Name { get; set; }
    }
}
