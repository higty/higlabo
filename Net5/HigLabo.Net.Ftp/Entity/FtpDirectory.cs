using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Ftp
{
    public class FtpDirectory
    {
        public String Name { get; set; }
        public DateTime? CreateTime { get; set; }
        public FtpDirectory(String name)
        {
            this.Name = name;
        }
        public FtpDirectory(String name, DateTime createTime)
        {
            this.Name = name;
            this.CreateTime = createTime;
        }
    }
}
