using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class OrganizationUsageAudioSpeechObject
{
    public string Object { get; set; } = "";
    public int Characters { get; set; }
    public int Num_Model_Requests { get; set; }
    public string? Project_Id { get; set; }
    public string? User_Id { get; set; }
    public string? Api_Key_Id { get; set; }
    public string? Model { get; set; }
}
public class OrganizationUsageAudioSpeechObjectResponse: RestApiResponse
{
    public int Characters { get; set; }
    public int Num_Model_Requests { get; set; }
    public string? Project_Id { get; set; }
    public string? User_Id { get; set; }
    public string? Api_Key_Id { get; set; }
    public string? Model { get; set; }
}
