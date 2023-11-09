using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// List your organization's fine-tuning jobs
    /// <seealso href="https://api.openai.com/v1/fine_tuning/jobs">https://api.openai.com/v1/fine_tuning/jobs</seealso>
    /// </summary>
    public partial class FineTuningJobsParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";

        string IRestApiParameter.GetApiPath()
        {
            return $"/fine_tuning/jobs";
        }
    }
    public partial class FineTuningJobsResponse : RestApiDataResponse<List<FineTuningJob>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FineTuningJobsResponse> FineTuningJobsAsync()
        {
            var p = new FineTuningJobsParameter();
            return await this.SendJsonAsync<FineTuningJobsParameter, FineTuningJobsResponse>(p, CancellationToken.None);
        }
        public async ValueTask<FineTuningJobsResponse> FineTuningJobsAsync(CancellationToken cancellationToken)
        {
            var p = new FineTuningJobsParameter();
            return await this.SendJsonAsync<FineTuningJobsParameter, FineTuningJobsResponse>(p, cancellationToken);
        }
        public async ValueTask<FineTuningJobsResponse> FineTuningJobsAsync(FineTuningJobsParameter parameter)
        {
            return await this.SendJsonAsync<FineTuningJobsParameter, FineTuningJobsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<FineTuningJobsResponse> FineTuningJobsAsync(FineTuningJobsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FineTuningJobsParameter, FineTuningJobsResponse>(parameter, cancellationToken);
        }
    }
}
