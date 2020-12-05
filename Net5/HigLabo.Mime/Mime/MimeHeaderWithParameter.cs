using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Mime.Internal;

namespace HigLabo.Mime
{
    public class MimeHeaderWithParameter: MimeHeader
    {
        public List<MimeHeaderParameter> Parameters { get; private set; }
        public override Boolean HasParameter
        {
            get { return true; }
        }

        public MimeHeaderWithParameter()
        {
            this.Parameters = new List<MimeHeaderParameter>();
        }
        public String GetParameterValue(String key)
        {
            var s = "";
            var keyFound = false;
            foreach (var p in this.Parameters)
            {
                if (keyFound)
                {
                    if (p.Key != "")
                    {
                        keyFound = false;
                        continue;
                    }
                    s += p.RawText;
                }
                else
                {
                    if (String.Equals(p.Key, key, StringComparison.OrdinalIgnoreCase) == false) { continue; }
                    s += p.Value;
                }
                keyFound = true;
            }
            return s;
        }
    }
}
