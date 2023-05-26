using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public class Team
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Email_Domain { get; set; }
        public Icon Icon { get; set; }
        public string Enterprise_Id { get; set; }
        public string Enterprise_Name { get; set; }
    }
}
