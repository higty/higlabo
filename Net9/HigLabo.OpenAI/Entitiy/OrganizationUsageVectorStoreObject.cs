using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class OrganizationUsageVectorStoreObject
{
    public string Object { get; set; } = "";
    public int Usage_Bytes { get; set; }
    public string? Project_Id { get; set; }
}
public class OrganizationUsageVectorStoreObjectResponse : RestApiResponse
{
    public int Usage_Bytes { get; set; }
    public string? Project_Id { get; set; }
}
