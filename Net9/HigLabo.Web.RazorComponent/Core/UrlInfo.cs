namespace HigLabo.Web.Internal;

public class UrlInfo
{
    public static string ImageWebSite { get; set; } = "https://localhost:7014/img";

    public static string GetIconUrl(Higlabo__icon fileName)
    {
        return $"{ImageWebSite}/{fileName.GetBlobName()}";
    }
}
