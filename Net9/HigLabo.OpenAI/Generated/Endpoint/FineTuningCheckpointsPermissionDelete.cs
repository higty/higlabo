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
    /// NOTE: This endpoint requires an admin API key.
    /// Organization owners can use this endpoint to delete a permission for a fine-tuned model checkpoint.
    /// <seealso href="https://api.openai.com/v1/fine_tuning/checkpoints/{fine_tuned_model_checkpoint}/permissions/{permission_id}">https://api.openai.com/v1/fine_tuning/checkpoints/{fine_tuned_model_checkpoint}/permissions/{permission_id}</seealso>
    /// </summary>
    public partial class FineTuningCheckpointsPermissionDeleteParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the fine-tuned model checkpoint to delete a permission for.
        /// </summary>
        public string Fine_Tuned_Model_Checkpoint { get; set; } = "";
        /// <summary>
        /// The ID of the fine-tuned model checkpoint permission to delete.
        /// </summary>
        public string Permission_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/fine_tuning/checkpoints/{Fine_Tuned_Model_Checkpoint}/permissions/{Permission_Id}";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class FineTuningCheckpointsPermissionDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FineTuningCheckpointsPermissionDeleteResponse> FineTuningCheckpointsPermissionDeleteAsync(string fine_Tuned_Model_Checkpoint, string permission_Id)
        {
            var p = new FineTuningCheckpointsPermissionDeleteParameter();
            p.Fine_Tuned_Model_Checkpoint = fine_Tuned_Model_Checkpoint;
            p.Permission_Id = permission_Id;
            return await this.SendJsonAsync<FineTuningCheckpointsPermissionDeleteParameter, FineTuningCheckpointsPermissionDeleteResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningCheckpointsPermissionDeleteResponse> FineTuningCheckpointsPermissionDeleteAsync(string fine_Tuned_Model_Checkpoint, string permission_Id, CancellationToken cancellationToken)
        {
            var p = new FineTuningCheckpointsPermissionDeleteParameter();
            p.Fine_Tuned_Model_Checkpoint = fine_Tuned_Model_Checkpoint;
            p.Permission_Id = permission_Id;
            return await this.SendJsonAsync<FineTuningCheckpointsPermissionDeleteParameter, FineTuningCheckpointsPermissionDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<FineTuningCheckpointsPermissionDeleteResponse> FineTuningCheckpointsPermissionDeleteAsync(FineTuningCheckpointsPermissionDeleteParameter parameter)
        {
            return await this.SendJsonAsync<FineTuningCheckpointsPermissionDeleteParameter, FineTuningCheckpointsPermissionDeleteResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningCheckpointsPermissionDeleteResponse> FineTuningCheckpointsPermissionDeleteAsync(FineTuningCheckpointsPermissionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FineTuningCheckpointsPermissionDeleteParameter, FineTuningCheckpointsPermissionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
