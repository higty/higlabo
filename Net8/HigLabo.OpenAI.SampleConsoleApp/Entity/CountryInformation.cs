using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    public class CountryInformation
    {
        public int Population { get; set; }
        public int Area { get; set; }
        public string Currency { get; set; } = "";
        public string Language { get; set; } = "";
    }
}
