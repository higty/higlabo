using HigLabo.Core;
using HigLabo.Html;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HigLaboApp.Core;

public class BlobFileHtmlConverter : RegexHtmlConverter
{
    public static class RegexList
    {
        public static Regex P_BlobFileUrl = new Regex("<p>(?<Url>[^<]*)</p>", RegexOptions.IgnoreCase);
        public static Regex P_BlobFileUrlLink = new Regex("<a href=\"(?<Url>[^\"]*)\"[^>]*>(?<InnerText>[^<]*)</a>", RegexOptions.IgnoreCase);
        public static Regex P_BlobFileUrlLink1 = new Regex("<a target=\"_blank\" href=\"(?<Url>[^\"]*)\"[^>]*>(?<InnerText>[^<]*)</a>", RegexOptions.IgnoreCase);
    }
    private static readonly HashSet<string> VideoExtensionSet = new(StringComparer.OrdinalIgnoreCase)
    {
        ".mp4", ".webm"
    };

    public FileExtensionProcessor FileExtensionProcessor { get; init; } 

    public BlobFileHtmlConverter(FileExtensionProcessor fileExtensionProcessor)
    {
        this.FileExtensionProcessor = fileExtensionProcessor;
    }
    protected override IEnumerable<Regex> GetRegexList()
    {
        //yield return RegexList.P_BlobFileUrl;
        yield return RegexList.P_BlobFileUrlLink;
        yield return RegexList.P_BlobFileUrlLink1;
    }
    protected override async ValueTask<String> ReplaceAsync(Match match)
    {
        var m = match;
        var url = m.Groups["Url"].Value;

        var extension = Path.GetExtension(url.ExtractString(null, '?'));
        if (string.Equals(extension, ".gif", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase))
        {
            return m.Value;
        }
        if (IsVideoUrl(url))
        {
            return $"""
                        <span class="video-container">
                            <video controls>
                              <source src="{url}" type="video/mp4">
                              <source src="{url}" type="video/webm">
                            </video>
                        </div>
                        """;
        }
        return m.Value;
    }
    private static bool IsVideoUrl(string url)
    {
        if (Uri.TryCreate(url, UriKind.Absolute, out var uri) == false) { return false; }
        var extension = Path.GetExtension(uri.AbsolutePath);
        if (extension.IsNullOrEmpty()) { return false; }

        return VideoExtensionSet.Contains(extension);
    }

}
