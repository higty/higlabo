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
    /// Create a video
    /// <seealso href="https://api.openai.com/v1/videos">https://api.openai.com/v1/videos</seealso>
    /// </summary>
    public partial class VideoCreateParameter : RestApiParameter, IRestApiParameter, IFileParameter, IFormDataParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// Text prompt that describes the video to generate.
        /// </summary>
        public string Prompt { get; set; } = "";
        /// <summary>
        /// Optional image or video reference that guides generation.
        /// </summary>
        public FileParameter Input_Reference { get; private set; } = new FileParameter("input_reference");
        /// <summary>
        /// The video generation model to use. Defaults to sora-2.
        /// </summary>
        public string? Model { get; set; }
        /// <summary>
        /// Clip duration in seconds. Defaults to 4 seconds.
        /// </summary>
        public string? Seconds { get; set; }
        /// <summary>
        /// Output resolution formatted as width x height. Defaults to 720x1280.
        /// </summary>
        public string? Size { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/videos";
        }
        public override object GetRequestBody()
        {
            return new {
            	prompt = this.Prompt,
            	input_reference = this.Input_Reference,
            	model = this.Model,
            	seconds = this.Seconds,
            	size = this.Size,
            };
        }
        IEnumerable<FileParameter> IFileParameter.GetFileParameters()
        {
            yield return this.Input_Reference;
        }
        Dictionary<string, string> IFormDataParameter.CreateFormDataParameter()
        {
            var d = new Dictionary<string, string>();
            d["prompt"] = this.Prompt;
            if (this.Model != null) d["model"] = this.Model;
            if (this.Seconds != null) d["seconds"] = this.Seconds;
            if (this.Size != null) d["size"] = this.Size;
            return d;
        }
    }
    public partial class VideoCreateResponse : VideoJobObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<VideoCreateResponse> VideoCreateAsync(string prompt)
        {
            var p = new VideoCreateParameter();
            p.Prompt = prompt;
            return await this.SendFormDataAsync<VideoCreateParameter, VideoCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VideoCreateResponse> VideoCreateAsync(string prompt, CancellationToken cancellationToken)
        {
            var p = new VideoCreateParameter();
            p.Prompt = prompt;
            return await this.SendFormDataAsync<VideoCreateParameter, VideoCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<VideoCreateResponse> VideoCreateAsync(VideoCreateParameter parameter)
        {
            return await this.SendFormDataAsync<VideoCreateParameter, VideoCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<VideoCreateResponse> VideoCreateAsync(VideoCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendFormDataAsync<VideoCreateParameter, VideoCreateResponse>(parameter, cancellationToken);
        }
    }
}
