using HigLabo.RestApi;

namespace HigLabo.Bing
{
    public class ImagesTrendingParameter : BingRestApiParameter
    {
        public override string HttpMethod => "GET";

        public override string GetApiPath()
        {
            return $"/images/trending";
        }
        public override string GetQueryString()
        {
            return $"mkt={this.Market.GetMarketCode()}";
        }
    }
    public partial class BingClient
    {
        public async ValueTask<TrendingImages> TrendingImages(ImagesTrendingParameter parameter)
        {
            return await this.SendJsonAsync<ImagesTrendingParameter, TrendingImages>(parameter);
        }
    }
}
