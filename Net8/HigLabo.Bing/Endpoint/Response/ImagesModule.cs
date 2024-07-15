namespace HigLabo.Bing
{
    public class ImagesModule : BingRestApiResponse
    {
        public Image[] Value { get; set; }  = Array.Empty<Image>();
    }
}
