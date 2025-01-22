using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack;

public class Bookmark
{
    public string? Id { get; set; }
    public string? Channel_Id { get; set; }
    public string? Title { get; set; }
    public string? Link { get; set; }
    public string? Emoji { get; set; }
    public string? Icon_Url { get; set; }
    public string? Type { get; set; }
    public object? Entity_Id { get; set; }
    public int Date_Created { get; set; }
    public int Date_Updated { get; set; }
    public string? Rank { get; set; }
    public string? Last_Updated_By_User_Id { get; set; }
    public string? Last_Updated_By_Team_Id { get; set; }
    public object? Shortcut_Id { get; set; }
    public object? App_Id { get; set; }
}
