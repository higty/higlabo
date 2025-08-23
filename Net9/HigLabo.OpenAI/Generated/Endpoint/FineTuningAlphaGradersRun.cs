using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Run a grader.
    /// <seealso href="https://api.openai.com/v1/fine_tuning/alpha/graders/run">https://api.openai.com/v1/fine_tuning/alpha/graders/run</seealso>
    /// </summary>
    public partial class FineTuningAlphaGradersRunParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The grader used for the fine-tuning job.
        /// </summary>
        public FineTuningGrader Grader { get; set; } = new();
        /// <summary>
        /// The model sample to be evaluated. This value will be used to populate the sample namespace. See the guide for more details. The output_json variable will be populated if the model sample is a valid JSON string.
        /// </summary>
        public string Model_Sample { get; set; } = "";
        /// <summary>
        /// The dataset item provided to the grader. This will be used to populate the item namespace. See the guide for more details.
        /// </summary>
        public object? Item { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/fine_tuning/alpha/graders/run";
        }
        public override object GetRequestBody()
        {
            return new {
            	grader = this.Grader,
            	model_sample = this.Model_Sample,
            	item = this.Item,
            };
        }
    }
    public partial class FineTuningAlphaGradersRunResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FineTuningAlphaGradersRunResponse> FineTuningAlphaGradersRunAsync(FineTuningGrader grader, string model_Sample)
        {
            var p = new FineTuningAlphaGradersRunParameter();
            p.Grader = grader;
            p.Model_Sample = model_Sample;
            return await this.SendJsonAsync<FineTuningAlphaGradersRunParameter, FineTuningAlphaGradersRunResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningAlphaGradersRunResponse> FineTuningAlphaGradersRunAsync(FineTuningGrader grader, string model_Sample, CancellationToken cancellationToken)
        {
            var p = new FineTuningAlphaGradersRunParameter();
            p.Grader = grader;
            p.Model_Sample = model_Sample;
            return await this.SendJsonAsync<FineTuningAlphaGradersRunParameter, FineTuningAlphaGradersRunResponse>(p, cancellationToken);
        }
        public async ValueTask<FineTuningAlphaGradersRunResponse> FineTuningAlphaGradersRunAsync(FineTuningAlphaGradersRunParameter parameter)
        {
            return await this.SendJsonAsync<FineTuningAlphaGradersRunParameter, FineTuningAlphaGradersRunResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningAlphaGradersRunResponse> FineTuningAlphaGradersRunAsync(FineTuningAlphaGradersRunParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FineTuningAlphaGradersRunParameter, FineTuningAlphaGradersRunResponse>(parameter, cancellationToken);
        }
    }
}
