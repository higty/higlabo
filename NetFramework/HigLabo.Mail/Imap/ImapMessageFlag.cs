using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Core;

namespace HigLabo.Net.Imap
{
    public class ImapMessageFlag
    {
        private List<string> _Values = new List<string>();

        public Boolean Seen { get; set; }
        public Boolean Answered { get; set; }
        public Boolean Flagged { get; set; }
        public Boolean Deleted { get; set; }
        public Boolean Draft { get; set; }
        public Boolean Recent { get; set; }

        public IEnumerable<String> Values
        {
            get { return _Values; }
        }

        public void Add(String value)
        {
            if (_Values.Contains(value) == true) { return; }

            this._Values.Add(value);
            switch (value.ToLower())
            {
                case "seen": this.Seen = true; break;
                case "answered": this.Answered = true; break;
                case "flagged": this.Flagged = true; break;
                case "deleted": this.Deleted = true; break;
                case "draft": this.Draft = true; break;
                case "recent": this.Recent = true; break;
                default: break;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _Values.Count; i++)
            {
                sb.Append(_Values[i]);
                if (i < _Values.Count - 1)
                {
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }
    }
}
