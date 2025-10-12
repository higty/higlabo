using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Download video content
    /// <seealso href="https://api.openai.com/v1/videos/{video_id}/content">https://api.openai.com/v1/videos/{video_id}/content</seealso>
    /// </summary>
    public partial class VideoContentGetParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The identifier of the video whose media to download.
        /// </summary>
        public string Video_Id { get; set; } = "";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public VideoContentGetQueryParameter QueryParameter { get; set; } = new VideoContentGetQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/videos/{Video_Id}/content";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class VideoContentGetQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Which downloadable asset to return. Defaults to the MP4 video.
        /// </summary>
        public string? Variant { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.Variant != null)
            {
                sb.Append($"variant={WebUtility.UrlEncode(this.Variant)}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<Stream> VideoContentGetAsync(string video_Id)
        {
            var p = new VideoContentGetParameter();
            p.Video_Id = video_Id;
            return await this.SendJsonAndGetStreamAsync<VideoContentGetParameter, Stream>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<Stream> VideoContentGetAsync(string video_Id, CancellationToken cancellationToken)
        {
            var p = new VideoContentGetParameter();
            p.Video_Id = video_Id;
            return await this.SendJsonAndGetStreamAsync<VideoContentGetParameter, Stream>(p, cancellationToken);
        }
        public async ValueTask<Stream> VideoContentGetAsync(VideoContentGetParameter parameter)
        {
            return await this.SendJsonAndGetStreamAsync<VideoContentGetParameter, Stream>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<Stream> VideoContentGetAsync(VideoContentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAndGetStreamAsync<VideoContentGetParameter, Stream>(parameter, cancellationToken);
        }
    }
}
