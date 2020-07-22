using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Security
{
    public class AesManagedExtensionsSettings
    {
        public Encoding Encoding { get; set; }
        public Encoding KeyEncoding { get; set; }
        public AesManagedExtensionsSettings()
        {
            this.Encoding = Encoding.UTF8;
            this.KeyEncoding = Encoding.UTF8;
        }
    }
}
