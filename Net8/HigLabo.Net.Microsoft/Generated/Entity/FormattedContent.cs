using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-formattedcontent?view=graph-rest-1.0
    /// </summary>
    public partial class FormattedContent
    {
        public enum FormattedContentSecurityContentFormat
        {
            Text,
            Html,
            Markdown,
            UnknownFutureValue,
        }

        public string? Content { get; set; }
        public FormattedContentSecurityContentFormat Format { get; set; }
    }
}
