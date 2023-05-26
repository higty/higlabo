using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public partial class TeamProfileGetResponse
    {
        public class Field
        {
            public string Id { get; set; }
            public int Ordering { get; set; }
            public string Label { get; set; }
            public string Hint { get; set; }
            public string Type { get; set; }
            public string[] Possible_Values { get; set; }
            public Options Options { get; set; }
            public bool Is_Hidden { get; set; }
            public string Section_Id { get; set; }
        }
        public class Options
        {
            public bool is_scim { get; set; }
            public bool is_protected { get; set; }
        }
        public class Section
        {
            public string Id { get; set; }
            public string Team_Id { get; set; }
            public string Section_Type { get; set; }
            public string Label { get; set; }
            public int Order { get; set; }
            public bool Is_Hidden { get; set; }
        }
        public Field[] Fields { get; set; }
        public Section[] Sections { get; set; }
    }
}
