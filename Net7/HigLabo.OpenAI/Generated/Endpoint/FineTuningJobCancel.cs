using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Immediately cancel a fine-tune job.
    /// <seealso href="https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}/cancel">https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}/cancel</seealso>
    /// </summary>
    public partial class FineTuningJobCancelParameter : RestApiParameter, IRestApiParameter
    {
        internal static readonly FineTuningJobCancelParameter Empty = new FineTuningJobCancelParameter();

        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the fine-tuning job to cancel.
        /// </summary>
        public string Fine_Tuning_Job_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/fine_tuning/jobs/{Fine_Tuning_Job_Id}/cancel";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class FineTuningJobCancelResponse : FineTuningJobResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FineTuningJobCancelResponse> FineTuningJobCancelAsync(string fine_Tuning_Job_Id)
        {
            var p = new FineTuningJobCancelParameter();
            p.Fine_Tuning_Job_Id = fine_Tuning_Job_Id;
            return await this.SendJsonAsync<FineTuningJobCancelParameter, FineTuningJobCancelResponse>(p, CancellationToken.None);
        }
        public async ValueTask<FineTuningJobCancelResponse> FineTuningJobCancelAsync(string fine_Tuning_Job_Id, CancellationToken cancellationToken)
        {
            var p = new FineTuningJobCancelParameter();
            p.Fine_Tuning_Job_Id = fine_Tuning_Job_Id;
            return await this.SendJsonAsync<FineTuningJobCancelParameter, FineTuningJobCancelResponse>(p, cancellationToken);
        }
        public async ValueTask<FineTuningJobCancelResponse> FineTuningJobCancelAsync(FineTuningJobCancelParameter parameter)
        {
            return await this.SendJsonAsync<FineTuningJobCancelParameter, FineTuningJobCancelResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<FineTuningJobCancelResponse> FineTuningJobCancelAsync(FineTuningJobCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FineTuningJobCancelParameter, FineTuningJobCancelResponse>(parameter, cancellationToken);
        }
    }
}
