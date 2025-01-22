using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Get info about a fine-tuning job.
    /// Learn more about fine-tuning
    /// <seealso href="https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}">https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}</seealso>
    /// </summary>
    public partial class FineTuningJobRetrieveParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the fine-tuning job.
        /// </summary>
        public string Fine_Tuning_Job_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/fine_tuning/jobs/{Fine_Tuning_Job_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class FineTuningJobRetrieveResponse : FineTuningJobResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FineTuningJobRetrieveResponse> FineTuningJobRetrieveAsync(string fine_Tuning_Job_Id)
        {
            var p = new FineTuningJobRetrieveParameter();
            p.Fine_Tuning_Job_Id = fine_Tuning_Job_Id;
            return await this.SendJsonAsync<FineTuningJobRetrieveParameter, FineTuningJobRetrieveResponse>(p, CancellationToken.None);
        }
        public async ValueTask<FineTuningJobRetrieveResponse> FineTuningJobRetrieveAsync(string fine_Tuning_Job_Id, CancellationToken cancellationToken)
        {
            var p = new FineTuningJobRetrieveParameter();
            p.Fine_Tuning_Job_Id = fine_Tuning_Job_Id;
            return await this.SendJsonAsync<FineTuningJobRetrieveParameter, FineTuningJobRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<FineTuningJobRetrieveResponse> FineTuningJobRetrieveAsync(FineTuningJobRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<FineTuningJobRetrieveParameter, FineTuningJobRetrieveResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<FineTuningJobRetrieveResponse> FineTuningJobRetrieveAsync(FineTuningJobRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FineTuningJobRetrieveParameter, FineTuningJobRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
