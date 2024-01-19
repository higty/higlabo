using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web
{
    public class SelectedDateDuration
    {
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        public SelectedDateDuration() { }
        public SelectedDateDuration(DateOnly? startDate, DateOnly? endDate)
        {
            this.StartDate = startDate; 
            this.EndDate = endDate;
        }
    }
}
