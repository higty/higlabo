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
    /// Validate a grader.
    /// <seealso href="https://api.openai.com/v1/fine_tuning/alpha/graders/validate">https://api.openai.com/v1/fine_tuning/alpha/graders/validate</seealso>
    /// </summary>
    public partial class FineTuningAlphaGradersValidateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The grader used for the fine-tuning job.
        /// </summary>
        public FineTuningGrader Grader { get; set; } = new();

        string IRestApiParameter.GetApiPath()
        {
            return $"/fine_tuning/alpha/graders/validate";
        }
        public override object GetRequestBody()
        {
            return new {
            	grader = this.Grader,
            };
        }
    }
    public partial class FineTuningAlphaGradersValidateResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FineTuningAlphaGradersValidateResponse> FineTuningAlphaGradersValidateAsync(FineTuningGrader grader)
        {
            var p = new FineTuningAlphaGradersValidateParameter();
            p.Grader = grader;
            return await this.SendJsonAsync<FineTuningAlphaGradersValidateParameter, FineTuningAlphaGradersValidateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningAlphaGradersValidateResponse> FineTuningAlphaGradersValidateAsync(FineTuningGrader grader, CancellationToken cancellationToken)
        {
            var p = new FineTuningAlphaGradersValidateParameter();
            p.Grader = grader;
            return await this.SendJsonAsync<FineTuningAlphaGradersValidateParameter, FineTuningAlphaGradersValidateResponse>(p, cancellationToken);
        }
        public async ValueTask<FineTuningAlphaGradersValidateResponse> FineTuningAlphaGradersValidateAsync(FineTuningAlphaGradersValidateParameter parameter)
        {
            return await this.SendJsonAsync<FineTuningAlphaGradersValidateParameter, FineTuningAlphaGradersValidateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningAlphaGradersValidateResponse> FineTuningAlphaGradersValidateAsync(FineTuningAlphaGradersValidateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FineTuningAlphaGradersValidateParameter, FineTuningAlphaGradersValidateResponse>(parameter, cancellationToken);
        }
    }
}
