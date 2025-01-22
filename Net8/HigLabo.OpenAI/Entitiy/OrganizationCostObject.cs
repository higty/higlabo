using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class OrganizationCostObject
{
    public string Object { get; set; } = "";
    public CostAmount? Amount { get; set; }
    public string? Line_Item { get; set; }
    public string? Project_Id { get; set; }

    public class CostAmount
    {
        public decimal Value { get; set; }
        public string Currency { get; set; } = "";
    }
}
