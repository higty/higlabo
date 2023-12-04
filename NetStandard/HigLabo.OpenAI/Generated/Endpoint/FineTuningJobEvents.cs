using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Get status updates for a fine-tuning job.
    /// <seealso href="https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}/events">https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}/events</seealso>
    /// </summary>
    public partial class FineTuningJobEventsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the fine-tuning job to get events for.
        /// </summary>
        public string Fine_Tuning_Job_Id { get; set; } = "";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public QueryParameter QueryParameter { get; set; } = new QueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/fine_tuning/jobs/{Fine_Tuning_Job_Id}/events";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class FineTuningJobEventsResponse : RestApiDataResponse<List<FineTuningJob>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FineTuningJobEventsResponse> FineTuningJobEventsAsync(string fine_Tuning_Job_Id)
        {
            var p = new FineTuningJobEventsParameter();
            p.Fine_Tuning_Job_Id = fine_Tuning_Job_Id;
            return await this.SendJsonAsync<FineTuningJobEventsParameter, FineTuningJobEventsResponse>(p, CancellationToken.None);
        }
        public async ValueTask<FineTuningJobEventsResponse> FineTuningJobEventsAsync(string fine_Tuning_Job_Id, CancellationToken cancellationToken)
        {
            var p = new FineTuningJobEventsParameter();
            p.Fine_Tuning_Job_Id = fine_Tuning_Job_Id;
            return await this.SendJsonAsync<FineTuningJobEventsParameter, FineTuningJobEventsResponse>(p, cancellationToken);
        }
        public async ValueTask<FineTuningJobEventsResponse> FineTuningJobEventsAsync(FineTuningJobEventsParameter parameter)
        {
            return await this.SendJsonAsync<FineTuningJobEventsParameter, FineTuningJobEventsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<FineTuningJobEventsResponse> FineTuningJobEventsAsync(FineTuningJobEventsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FineTuningJobEventsParameter, FineTuningJobEventsResponse>(parameter, cancellationToken);
        }
    }
}
