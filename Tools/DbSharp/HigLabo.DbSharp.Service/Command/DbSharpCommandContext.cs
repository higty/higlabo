using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.Service
{
    public class CommandServiceContext
    {
        public CommandService Service { get; private set; }
        public DbSharpCommand PreviousCommand { get; set; }

        public CommandServiceContext(CommandService service)
        {
            this.Service = service;
        }
    }
}
