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
    /// Retrieve a video
    /// <seealso href="https://api.openai.com/v1/videos/{video_id}">https://api.openai.com/v1/videos/{video_id}</seealso>
    /// </summary>
    public partial class VideoRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The identifier of the video to retrieve.
        /// </summary>
        public string Video_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/videos/{Video_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class VideoRetrieveResponse : VideoJobObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VideoRetrieveResponse> VideoRetrieveAsync(string video_Id)
        {
            var p = new VideoRetrieveParameter();
            p.Video_Id = video_Id;
            return await this.SendJsonAsync<VideoRetrieveParameter, VideoRetrieveResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VideoRetrieveResponse> VideoRetrieveAsync(string video_Id, CancellationToken cancellationToken)
        {
            var p = new VideoRetrieveParameter();
            p.Video_Id = video_Id;
            return await this.SendJsonAsync<VideoRetrieveParameter, VideoRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<VideoRetrieveResponse> VideoRetrieveAsync(VideoRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<VideoRetrieveParameter, VideoRetrieveResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VideoRetrieveResponse> VideoRetrieveAsync(VideoRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VideoRetrieveParameter, VideoRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
