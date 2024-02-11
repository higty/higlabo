using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Classifies if text violates OpenAI's Content Policy
    /// <seealso href="https://api.openai.com/v1/moderations">https://api.openai.com/v1/moderations</seealso>
    /// </summary>
    public partial class ModerationCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The input text to classify
        /// </summary>
        public string Input { get; set; } = "";
        /// <summary>
        /// Two content moderations models are available: text-moderation-stable and text-moderation-latest.The default is text-moderation-latest which will be automatically upgraded over time. This ensures you are always using our most accurate model. If you use text-moderation-stable, we will provide advanced notice before updating the model. Accuracy of text-moderation-stable may be slightly lower than for text-moderation-latest.
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
            return await this.SendJsonAsync<ModerationCreateParameter, ModerationCreateResponse>(p, CancellationToken.None);
        }
        public async ValueTask<ModerationCreateResponse> ModerationCreateAsync(string input, CancellationToken cancellationToken)
        {
            var p = new ModerationCreateParameter();
            p.Input = input;
            return await this.SendJsonAsync<ModerationCreateParameter, ModerationCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<ModerationCreateResponse> ModerationCreateAsync(ModerationCreateParameter parameter)
        {
            return await this.SendJsonAsync<ModerationCreateParameter, ModerationCreateResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<ModerationCreateResponse> ModerationCreateAsync(ModerationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ModerationCreateParameter, ModerationCreateResponse>(parameter, cancellationToken);
        }
    }
}
