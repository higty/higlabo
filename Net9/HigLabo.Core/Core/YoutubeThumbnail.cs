public enum YoutubeThumbnailSize
{
    MaxRes,
    SD,
    MQ,
    HQ,
    Default
}

public static class YouTubeThumbnail
{
    public static string BuildThumbnailUrl(string videoId, YoutubeThumbnailSize size)
    {
        string fileName = size switch
        {
            YoutubeThumbnailSize.MaxRes => "maxresdefault.jpg",
            YoutubeThumbnailSize.SD => "sddefault.jpg",
            YoutubeThumbnailSize.MQ => "mqdefault.jpg",
            YoutubeThumbnailSize.HQ => "hqdefault.jpg",
            YoutubeThumbnailSize.Default => "default.jpg",
            _ => "hqdefault.jpg"
        };

        return $"https://img.youtube.com/vi/{videoId}/{fileName}";
    }
}