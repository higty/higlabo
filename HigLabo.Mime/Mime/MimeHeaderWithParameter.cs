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
            var p = this.Parameters.Find(el => String.Equals(el.Key, key, StringComparison.OrdinalIgnoreCase));
            if (p != null)
            {
                return p.Value;
            }
            return "";
        }
    }
}
