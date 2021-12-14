using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HigLabo.Web.UI
{
    public class VueAttribute
    {
        public String Name { get; private set; } = "";
        public String Value { get; private set; } = "";
        public Boolean IsVueAttribute { get; private set; } = false;
        public String v_if { get; set; } = "";

        public VueAttribute(String name)
        {
            this.Name = name;
        }
        public void SetValue(String value)
        {
            this.Value = value;
            this.IsVueAttribute = false;
        }
        public void SetVueValue(String value)
        {
            this.Value = value;
            this.IsVueAttribute = true;
        }
        public HtmlString GetHtmlString()
        {
            return new HtmlString(this.ToString());
        }
        public override string ToString()
        {
            var v = "";
            if (this.IsVueAttribute)
            {
                v = ":";
            }
            return String.Format("{0}{1}=\"{2}\""
                , v, this.Name
                , HttpUtility.HtmlAttributeEncode(this.Value));
        }
    }
}
