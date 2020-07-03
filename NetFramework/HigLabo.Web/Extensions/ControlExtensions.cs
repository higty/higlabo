using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Text;
using System.IO;

namespace HigLabo.Web.UI
{
    public static class ControlExtensions
    {
        public static String ToHtml(this Control control)
        {
            if (control == null) { throw new ArgumentNullException(); }

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            control.RenderControl(hw);
            return sb.ToString();
        }
    }
}
