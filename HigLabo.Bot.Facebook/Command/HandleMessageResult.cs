using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hignull.Facebook
{
    public class HandleMessageResult
    {
        public Boolean Handled { get; set; }

        public HandleMessageResult(Boolean handled)
        {
            this.Handled = handled;
        }
    }
}
