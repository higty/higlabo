using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class OrganizationUsageAudioTranscriptionObject
{
    public string Object { get; set; } = "";
    public int Seconds { get; set; }
    public int Num_Model_Requests { get; set; }
    public string? Project_Id { get; set; }
    public string? User_Id { get; set; }
    public string? Api_Key_Id { get; set; }
    public string? Model { get; set; }
}
public class OrganizationUsageAudioTranscriptionObjectResponse: RestApiResponse
{
    public int Seconds { get; set; }
    public int Num_Model_Requests { get; set; }
    public string? Project_Id { get; set; }
    public string? User_Id { get; set; }
    public string? Api_Key_Id { get; set; }
    public string? Model { get; set; }
}
