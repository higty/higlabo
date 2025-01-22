using HigLabo.Converter;
using System.Text;

namespace HigLabo.Net.Microsoft;
public partial class AttachmentGetResponse
{
    public string? ContentType { get; set; }
    public string ContentLocation { get; set; } = "";
    public string ContentBytes { get; set; } = "";
    public string ContentId { get; set; } = "";
    public string? Id { get; set; }
    public bool? IsInline { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public string? Name { get; set; }
    public Int32? Size { get; set; }

    public byte[] GetBytes()
    {
        var cv = new Base64Converter(1024 * 8);
        return cv.DecodeFromText(this.ContentBytes, Encoding.UTF8);
    }
}
