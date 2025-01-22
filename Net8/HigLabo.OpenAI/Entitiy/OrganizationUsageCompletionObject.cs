using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class OrganizationUsageCompletionObject
{
    public string Object { get; set; } = "";
    public int Input_Tokens { get; set; }
    public int Input_Cached_Tokens { get; set; }
    public int Output_Tokens { get; set; }
    public int Input_Audio_Tokens { get; set; }
    public int Output_Audio_Tokens { get; set; }
    public int Num_Model_Requests { get; set; }
    public string? Project_Id { get; set; }
    public string? User_Id { get; set; }
    public string? Api_Key_Id { get; set; }
    public string? Model { get; set; }
    public bool? Batch { get; set; }
}
public class OrganizationUsageCompletionObjectResponse : RestApiResponse
{
    public int Input_Tokens { get; set; }
    public int Input_Cached_Tokens { get; set; }
    public int Output_Tokens { get; set; }
    public int Input_Audio_Tokens { get; set; }
    public int Output_Audio_Tokens { get; set; }
    public int Num_Model_Requests { get; set; }
    public string? Project_Id { get; set; }
    public string? User_Id { get; set; }
    public string? Api_Key_Id { get; set; }
    public string? Model { get; set; }
    public bool? Batch { get; set; }
}