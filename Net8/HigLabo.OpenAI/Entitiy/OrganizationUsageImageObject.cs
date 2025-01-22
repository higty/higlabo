using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class OrganizationUsageImageObject
{
    public string Object { get; set; } = "";
    public int Images { get; set; }
    public int Num_Model_Requests { get; set; }
    public string? Source { get; set; }
    public string? Size { get; set; }
    public string? Project_Id { get; set; }
    public string? User_Id { get; set; }
    public string? Api_Key_Id { get; set; }
    public string? Model { get; set; }
}
public class OrganizationUsageImageObjectResponse: RestApiResponse
{
    public int Images { get; set; }
    public int Num_Model_Requests { get; set; }
    public string? Source { get; set; }
    public string? Size { get; set; }
    public string? Project_Id { get; set; }
    public string? User_Id { get; set; }
    public string? Api_Key_Id { get; set; }
    public string? Model { get; set; }
}
