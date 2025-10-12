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
    /// Classifies if text and/or image inputs are potentially harmful. Learn more in the moderation guide.
    /// <seealso href="https://api.openai.com/v1/moderations">https://api.openai.com/v1/moderations</seealso>
    /// </summary>
    public partial class ModerationCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// Input (or inputs) to classify. Can be a single string, an array of strings, or an array of multi-modal input objects similar to other models.
        /// </summary>
        public string Input { get; set; } = "";
        /// <summary>
        /// The content moderation model you would like to use. Learn more in the moderation guide, and learn about available models here.
        /// </summary>
        public string? Model { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/moderations";
        }
        public override object GetRequestBody()
        {
            return new {
            	input = this.Input,
            	model = this.Model,
            };
        }
    }
    public partial class ModerationCreateResponse : ModerationObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ModerationCreateResponse> ModerationCreateAsync(string input)
        {
            var p = new ModerationCreateParameter();
            p.Input = input;
            return await this.SendJsonAsync<ModerationCreateParameter, ModerationCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ModerationCreateResponse> ModerationCreateAsync(string input, CancellationToken cancellationToken)
        {
            var p = new ModerationCreateParameter();
            p.Input = input;
            return await this.SendJsonAsync<ModerationCreateParameter, ModerationCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<ModerationCreateResponse> ModerationCreateAsync(ModerationCreateParameter parameter)
        {
            return await this.SendJsonAsync<ModerationCreateParameter, ModerationCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ModerationCreateResponse> ModerationCreateAsync(ModerationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ModerationCreateParameter, ModerationCreateResponse>(parameter, cancellationToken);
        }
    }
}
