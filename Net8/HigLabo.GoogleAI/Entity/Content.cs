using HigLabo.Core;
using System.Text;

namespace HigLabo.GoogleAI
{
    public class Content
    {
        public ChatMessageRole Role { get; set; }
        public List<ContentPart> Parts { get; init; } = new();

        public Content() { }
        public Content(ChatMessageRole role, string text)
        {
            this.Role = role;
            this.Parts.Add(new ContentPart(text));
        }

        public void AddMessage(string text)
        {
            this.Parts.Add(new ContentPart(text));
        }

        public override string ToString()
        {
            if (this.Parts.Count == 0) { return ""; }
            if (this.Parts.Count == 1) { return this.Parts[0].Text ?? ""; }
            var sb = new StringBuilder(256);
            foreach (var part in this.Parts)
            {
                sb.Append(part.Text);
            }
            return sb.ToString();
        }
    }
}
