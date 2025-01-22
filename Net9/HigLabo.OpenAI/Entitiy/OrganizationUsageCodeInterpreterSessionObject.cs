using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class OrganizationUsageCodeInterpreterSessionObject
{
    public string Object { get; set; } = "";
    public int Sessions { get; set; }
    public string? Project_Id { get; set; }
}
public class OrganizationUsageCodeInterpreterSessionObjectResponse: RestApiResponse
{
    public int Sessions { get; set; }
    public string? Project_Id { get; set; }
}
