using HigLabo.Core;
using HigLabo.RestApi;
using System.Text;

namespace HigLabo.Bing;

public class ImagesSearchParameter : BingRestApiParameter
{
    public override string HttpMethod => "GET";

    public string Color { get; set; } = "";
    public ushort? Width { get; set; }
    public ushort? Height { get; set; }
    public ImageType? ImageType { get; set; }
    public ImageContent? ImageContent { get; set; }
    public ImageLicense? License { get; set; }
    public int? MaxFileSize { get; set; }
    public int? MaxWidth { get; set; }
    public int? MaxHeight { get; set; }
    public int? MinFileSize { get; set; }
    public int? MinWidth { get; set; }
    public int? MinHeight { get; set; }
    public ImageSize? Size { get; set; }

    public override string GetApiPath()
    {
        return $"/images/search";
    }
    public override string GetQueryString()
    {
        var sb = new StringBuilder(128);
        if (this.Color.HasValue())
        {
            sb.Append($"&color={this.Color}");
        }
        if (this.Width.HasValue)
        {
            sb.Append($"&width={this.Width}");
        }
        if (this.Height.HasValue)
        {
            sb.Append($"&height={this.Height}");
        }
        if (this.ImageType.HasValue)
        {
            sb.Append($"&imageType={this.ImageType.ToStringFromEnum()}");
        }
        if (this.ImageContent.HasValue)
        {
            sb.Append($"&imageContent={this.ImageContent.ToStringFromEnum()}");
        }
        if (this.License.HasValue)
        {
            sb.Append($"&license={this.License.ToStringFromEnum()}");
        }
        if (this.MaxFileSize.HasValue)
        {
            sb.Append($"&maxFileSize={this.MaxFileSize}");
        }
        if (this.MaxWidth.HasValue)
        {
            sb.Append($"&maxWidth={this.MaxWidth}");
        }
        if (this.MaxHeight.HasValue)
        {
            sb.Append($"&maxHeight={this.MaxHeight}");
        }
        if (this.MinFileSize.HasValue)
        {
            sb.Append($"&minFileSize={this.MinFileSize}");
        }
        if (this.MinWidth.HasValue)
        {
            sb.Append($"&minWidth={this.MinWidth}");
        }
        if (this.MinHeight.HasValue)
        {
            sb.Append($"&minHeight={this.MinHeight}");
        }
        if (this.Size.HasValue)
        {
            sb.Append($"&size={this.Size.ToStringFromEnum()}");
        }
        return base.GetQueryString() + sb.ToString();
    }
}
public partial class BingClient
{
    public async ValueTask<ImageAnswer> SearchImages(ImagesSearchParameter parameter)
    {
        return await this.SendJsonAsync<ImagesSearchParameter, ImageAnswer>(parameter);
    }
}
