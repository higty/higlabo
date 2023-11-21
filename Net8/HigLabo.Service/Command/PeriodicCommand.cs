using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Service
{
    public abstract class PeriodicCommand : ServiceCommand
    {
        public BackgroundService Service { get; init; }

        public PeriodicCommand(BackgroundService service)
        {
            this.Service = service;
        }
        public abstract Boolean IsExecute(DateTime utcNow);
    }
}
