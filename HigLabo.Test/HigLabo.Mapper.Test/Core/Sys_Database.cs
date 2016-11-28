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
        public Int32 DatabaseID { get; set; }
        public DateTime CreateDate { get; set; }
        public Int32 CompatibilityLevel { get; set; }
        public String CollationName { get; set; }
    }
}
