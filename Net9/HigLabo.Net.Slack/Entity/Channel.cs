using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack;

public class Channel
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public Boolean Is_Channel { get; set; }
    public Int32 Created { get; set; }
    public string? Creator { get; set; }
    public Boolean Is_Archived { get; set; }
    public Boolean Is_General { get; set; }
    public Int32 UnLinked { get; set; }
    public string? Name_Normalized { get; set; }
    public Boolean Is_Shared { get; set; }
    public Boolean Is_Org_Shared { get; set; }
    public Boolean Is_Member { get; set; }
    public Boolean Is_Private { get; set; }
    public Boolean Is_Mpim { get; set; }
    public Boolean Is_Im { get; set; }
    public Boolean? Is_User_Deleted { get; set; }
    public string? Last_Read { get; set; }

    public (
        string? Text, 
        string? UserName,
        string? Bot_Id,
        (string? Text, Int32 Id, string? Fallback)[] Attachments,
        string? Type,
        string? SubType,
        string? Ts
        ) Latest { get; set; }

    public Int32 Unread_Count { get; set; }
    public Int32 Unread_Count_Display { get; set; }
    public String[]? Members { get; set; }
    public (string? Value, string? Creator, Int32 Last_Set) Topic { get; set; }
    public (string? Value, string? Creator, Int32 Last_Set) Purpose { get; set; }

    public String[]? Previous_Names { get; set; }
    public Int32 Num_Members { get; set; }

    public string? User { get; set; }
}
