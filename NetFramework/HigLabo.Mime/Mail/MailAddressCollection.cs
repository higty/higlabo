using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Mime
{
    public class MailAddressCollection
    {
        private List<MailAddress> _MailAddresses = new List<MailAddress>();
        public String Value { get; set; }
        public List<MailAddress> MailAddresses
        {
            get { return _MailAddresses; }
        }
        public MailAddressCollection(String value)
        {
            this.Value = value;
            this.ParseMailAddresses();
        }
        private void ParseMailAddresses()
        {
            String value = this.Value;
            Int32 index = 0;

            //Split and parse
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == ',' || value[i] == ';')
                {
                    if (index < i)
                    {
                        var m = MailAddress.TryCreate(value.Substring(index, i - index));
                        if (m != null)
                        {
                            this.MailAddresses.Add(m);
                        }
                    }
                    index = i + 1;
                }
            }
            //Add last part of value
            if (index < value.Length)
            {
                var m = MailAddress.TryCreate(value.Substring(index, value.Length - index));
                if (m != null)
                {
                    this.MailAddresses.Add(m);
                }
            }
        }
    }
}
