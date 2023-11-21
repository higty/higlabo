using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// List your organization's fine-tuning jobs
    /// <seealso href="https://api.openai.com/v1/fine_tuning/jobs">https://api.openai.com/v1/fine_tuning/jobs</seealso>
    /// </summary>
    public partial class FineTuningJobsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly FineTuningJobsParameter Empty = new FineTuningJobsParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public FineTuningQueryParameter QueryParameter { get; set; } = new FineTuningQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/fine_tuning/jobs";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class FineTuningJobsResponse : RestApiDataResponse<List<FineTuningJob>>
    {
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FineTuningJobsResponse> FineTuningJobsAsync()
        {
            return await this.SendJsonAsync<FineTuningJobsParameter, FineTuningJobsResponse>(FineTuningJobsParameter.Empty, CancellationToken.None);
        }
        public async ValueTask<FineTuningJobsResponse> FineTuningJobsAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FineTuningJobsParameter, FineTuningJobsResponse>(FineTuningJobsParameter.Empty, cancellationToken);
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
