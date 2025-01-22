namespace HigLabo.Bing;

public class ImageCategory
{
    public string Title { get; set; } = "";
    public ImageTile[] Tiles { get; set; } = Array.Empty<ImageTile>();
}
