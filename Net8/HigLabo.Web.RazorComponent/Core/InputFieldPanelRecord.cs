using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web
{
    public class InputFieldPanelRecord
    {
        public string Text { get; set; } = "";
        public object Value { get; set; }

        public InputFieldPanelRecord(string text, object value)
        {
            Text = text;
            Value = value;
        }
    }
}
