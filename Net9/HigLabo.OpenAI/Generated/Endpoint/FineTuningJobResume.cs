using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Resume a fine-tune job.
    /// <seealso href="https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}/resume">https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}/resume</seealso>
    /// </summary>
    public partial class FineTuningJobResumeParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the fine-tuning job to resume.
        /// </summary>
        public string Fine_Tuning_Job_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/fine_tuning/jobs/{Fine_Tuning_Job_Id}/resume";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class FineTuningJobResumeResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FineTuningJobResumeResponse> FineTuningJobResumeAsync(string fine_Tuning_Job_Id)
        {
            var p = new FineTuningJobResumeParameter();
            p.Fine_Tuning_Job_Id = fine_Tuning_Job_Id;
            return await this.SendJsonAsync<FineTuningJobResumeParameter, FineTuningJobResumeResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningJobResumeResponse> FineTuningJobResumeAsync(string fine_Tuning_Job_Id, CancellationToken cancellationToken)
        {
            var p = new FineTuningJobResumeParameter();
            p.Fine_Tuning_Job_Id = fine_Tuning_Job_Id;
            return await this.SendJsonAsync<FineTuningJobResumeParameter, FineTuningJobResumeResponse>(p, cancellationToken);
        }
        public async ValueTask<FineTuningJobResumeResponse> FineTuningJobResumeAsync(FineTuningJobResumeParameter parameter)
        {
            return await this.SendJsonAsync<FineTuningJobResumeParameter, FineTuningJobResumeResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningJobResumeResponse> FineTuningJobResumeAsync(FineTuningJobResumeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FineTuningJobResumeParameter, FineTuningJobResumeResponse>(parameter, cancellationToken);
        }
    }
}
