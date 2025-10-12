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
    /// Delete a video
    /// <seealso href="https://api.openai.com/v1/videos/{video_id}">https://api.openai.com/v1/videos/{video_id}</seealso>
    /// </summary>
    public partial class VideoDeleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The identifier of the video to delete.
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
    public partial class VideoDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VideoDeleteResponse> VideoDeleteAsync(string video_Id)
        {
            var p = new VideoDeleteParameter();
            p.Video_Id = video_Id;
            return await this.SendJsonAsync<VideoDeleteParameter, VideoDeleteResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VideoDeleteResponse> VideoDeleteAsync(string video_Id, CancellationToken cancellationToken)
        {
            var p = new VideoDeleteParameter();
            p.Video_Id = video_Id;
            return await this.SendJsonAsync<VideoDeleteParameter, VideoDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<VideoDeleteResponse> VideoDeleteAsync(VideoDeleteParameter parameter)
        {
            return await this.SendJsonAsync<VideoDeleteParameter, VideoDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VideoDeleteResponse> VideoDeleteAsync(VideoDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VideoDeleteParameter, VideoDeleteResponse>(parameter, cancellationToken);
        }
    }
}
