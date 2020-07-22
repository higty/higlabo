using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Bot.Facebook.Send
{
    public interface IPayload
    {
        String Payload { get; set; }
    }
}
