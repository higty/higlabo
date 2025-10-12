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
    /// Create a video remix
    /// <seealso href="https://api.openai.com/v1/videos/{video_id}/remix">https://api.openai.com/v1/videos/{video_id}/remix</seealso>
    /// </summary>
    public partial class VideoRemixParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The identifier of the completed video to remix.
        /// </summary>
        public string Video_Id { get; set; } = "";
        /// <summary>
        /// Updated text prompt that directs the remix generation.
        /// </summary>
        public string Prompt { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/videos/{Video_Id}/remix";
        }
        public override object GetRequestBody()
        {
            return new {
            	prompt = this.Prompt,
            };
        }
    }
    public partial class VideoRemixResponse : VideoJobObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VideoRemixResponse> VideoRemixAsync(string video_Id, string prompt)
        {
            var p = new VideoRemixParameter();
            p.Video_Id = video_Id;
            p.Prompt = prompt;
            return await this.SendJsonAsync<VideoRemixParameter, VideoRemixResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VideoRemixResponse> VideoRemixAsync(string video_Id, string prompt, CancellationToken cancellationToken)
        {
            var p = new VideoRemixParameter();
            p.Video_Id = video_Id;
            p.Prompt = prompt;
            return await this.SendJsonAsync<VideoRemixParameter, VideoRemixResponse>(p, cancellationToken);
        }
        public async ValueTask<VideoRemixResponse> VideoRemixAsync(VideoRemixParameter parameter)
        {
            return await this.SendJsonAsync<VideoRemixParameter, VideoRemixResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VideoRemixResponse> VideoRemixAsync(VideoRemixParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<VideoRemixParameter, VideoRemixResponse>(parameter, cancellationToken);
        }
    }
}
