using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Bot.Line.Send
{
    public abstract class TemplateMessage : ISendMessage
    {
        public String AltText { get; set; }

        public abstract String CreateJson();
    }
}
