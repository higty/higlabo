using HigLabo.Core;

namespace HigLabo.GoogleAI;

public class ContentPart
{
    public string? Text { get; set; }
    public InlineData? InlineData { get; set; }
    public FileData? FileData { get; set; }
    public VideoMetaData? VideoMetaData { get; set; }
    public FunctionCall? FunctionCall { get; set; }

    public ContentPart() { }
    public ContentPart(string text)
    {
        Text = text;
    }
    public ContentPart(InlineData inlineData)
    {
        InlineData = inlineData;
    }

    public override string ToString()
    {
        if (this.Text != null) { return this.Text; }
        if (this.FunctionCall != null) { return this.FunctionCall.ToString()!; }
        if (this.InlineData != null) { return this.InlineData.ToString()!; }
        if (this.FileData != null) { return this.FileData.ToString()!; }
        return "";
    }
}
