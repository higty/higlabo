using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.UI
{
    public class InputPropertyPanelMessagePanel
    {
        public String PropertyName { get; set; } = "";
        public String Text { get; set; } = "";

        public InputPropertyPanelMessagePanel(String text)
        {
            this.Text = text;
        }
    }
}
