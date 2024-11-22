using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack;

public class SearchFile
{
    public string[]? Channels { get; set; }
    public int Comments_Count { get; set; }
    public int Created { get; set; }
    public string? Deanimate_gif { get; set; }
    public bool display_As_Bot { get; set; }
    public bool Editable { get; set; }
    public string? External_Type { get; set; }
    public string? FileType { get; set; }
    public List<object> Groups { get; set; } = new();
    public string? Id { get; set; }
    public int Image_Exif_Rotation { get; set; }
    public List<object>? Ims { get; set; }
    public bool Is_External { get; set; }
    public bool Is_Public { get; set; }
    public string? MimeType { get; set; }
    public string? Mode { get; set; }
    public string? Name { get; set; }
    public int Original_h { get; set; }
    public int Original_w { get; set; }
    public string? Permalink { get; set; }
    public string? Permalink_Public { get; set; }
    public string? Pretty_Type { get; set; }
    public object? Preview { get; set; }
    public bool Public_Url_Shared { get; set; }
    public List<Reaction> Reactions { get; set; } = new();
    public string? Score { get; set; }
    public int Size { get; set; }
    public string? Thumb_160 { get; set; }
    public string? Thumb_360 { get; set; }
    public string? Thumb_360_gif { get; set; }
    public int Thumb_360_h { get; set; }
    public int Thumb_360_w { get; set; }
    public string? Thumb_480 { get; set; }
    public string? Thumb_480_gif { get; set; }
    public int Thumb_480_h { get; set; }
    public int Thumb_480_w { get; set; }
    public string? Thumb_64 { get; set; }
    public string? Thumb_80 { get; set; }
    public int Timestamp { get; set; }
    public string? Title { get; set; }
    public bool Top_File { get; set; }
    public string? Url_Private { get; set; }
    public string? Url_Private_Download { get; set; }
    public string? User { get; set; }
    public string? UserName { get; set; }
}
