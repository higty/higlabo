using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// NOTE: Calling this endpoint requires an admin API key.
    /// This enables organization owners to share fine-tuned models with other projects in their organization.
    /// <seealso href="https://api.openai.com/v1/fine_tuning/checkpoints/{fine_tuned_model_checkpoint}/permissions">https://api.openai.com/v1/fine_tuning/checkpoints/{fine_tuned_model_checkpoint}/permissions</seealso>
    /// </summary>
    public partial class FineTuningCheckpointsPermissionsCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the fine-tuned model checkpoint to create a permission for.
        /// </summary>
        public string Fine_Tuned_Model_Checkpoint { get; set; } = "";
        /// <summary>
        /// The project identifiers to grant access to.
        /// </summary>
        public List<string>? Project_Ids { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/fine_tuning/checkpoints/{Fine_Tuned_Model_Checkpoint}/permissions";
        }
        public override object GetRequestBody()
        {
            return new {
            	project_ids = this.Project_Ids,
            };
        }
    }
    public partial class FineTuningCheckpointsPermissionsCreateResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FineTuningCheckpointsPermissionsCreateResponse> FineTuningCheckpointsPermissionsCreateAsync(string fine_Tuned_Model_Checkpoint, List<string>? project_Ids)
        {
            var p = new FineTuningCheckpointsPermissionsCreateParameter();
            p.Fine_Tuned_Model_Checkpoint = fine_Tuned_Model_Checkpoint;
            p.Project_Ids = project_Ids;
            return await this.SendJsonAsync<FineTuningCheckpointsPermissionsCreateParameter, FineTuningCheckpointsPermissionsCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningCheckpointsPermissionsCreateResponse> FineTuningCheckpointsPermissionsCreateAsync(string fine_Tuned_Model_Checkpoint, List<string>? project_Ids, CancellationToken cancellationToken)
        {
            var p = new FineTuningCheckpointsPermissionsCreateParameter();
            p.Fine_Tuned_Model_Checkpoint = fine_Tuned_Model_Checkpoint;
            p.Project_Ids = project_Ids;
            return await this.SendJsonAsync<FineTuningCheckpointsPermissionsCreateParameter, FineTuningCheckpointsPermissionsCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<FineTuningCheckpointsPermissionsCreateResponse> FineTuningCheckpointsPermissionsCreateAsync(FineTuningCheckpointsPermissionsCreateParameter parameter)
        {
            return await this.SendJsonAsync<FineTuningCheckpointsPermissionsCreateParameter, FineTuningCheckpointsPermissionsCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningCheckpointsPermissionsCreateResponse> FineTuningCheckpointsPermissionsCreateAsync(FineTuningCheckpointsPermissionsCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FineTuningCheckpointsPermissionsCreateParameter, FineTuningCheckpointsPermissionsCreateResponse>(parameter, cancellationToken);
        }
    }
}
