using HigLabo.RestApi;
using System.Text;

namespace HigLabo.Bing
{
    public class VideosDetailsParameter : BingRestApiParameter
    {
        public override string HttpMethod => "GET";
        public string Id { get; set; } = "";
        public string Modules { get; set; } = "All";
        public override string GetApiPath()
        {
            return $"/videos/details";
        }
        public override string GetQueryString()
        {
            var sb = new StringBuilder(128);
            sb.Append($"id={this.Id}&mkt={this.Market.GetMarketCode()}&modules={this.Modules}");
            return sb.ToString();
        }
    }
    public partial class BingClient
    {
        public async ValueTask<VideoDetails> VideosDetails(string id)
        {
            var p = new VideosDetailsParameter();
            p.Id = id;
            return await this.VideosDetails(p);
        }
        public async ValueTask<VideoDetails> VideosDetails(VideosDetailsParameter parameter)
        {
            return await this.SendJsonAsync<VideosDetailsParameter, VideoDetails>(parameter);
        }
    }
}
