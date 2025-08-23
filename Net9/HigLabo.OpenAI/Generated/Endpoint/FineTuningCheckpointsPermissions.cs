using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// NOTE: This endpoint requires an admin API key.
    /// Organization owners can use this endpoint to view all permissions for a fine-tuned model checkpoint.
    /// <seealso href="https://api.openai.com/v1/fine_tuning/checkpoints/{fine_tuned_model_checkpoint}/permissions">https://api.openai.com/v1/fine_tuning/checkpoints/{fine_tuned_model_checkpoint}/permissions</seealso>
    /// </summary>
    public partial class FineTuningCheckpointsPermissionsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the fine-tuned model checkpoint to get permissions for.
        /// </summary>
        public string Fine_Tuned_Model_Checkpoint { get; set; } = "";
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
            return $"/fine_tuning/checkpoints/{Fine_Tuned_Model_Checkpoint}/permissions";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class FineTuningCheckpointsPermissionsResponse : RestApiResponse
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FineTuningCheckpointsPermissionsResponse> FineTuningCheckpointsPermissionsAsync(string fine_Tuned_Model_Checkpoint)
        {
            var p = new FineTuningCheckpointsPermissionsParameter();
            p.Fine_Tuned_Model_Checkpoint = fine_Tuned_Model_Checkpoint;
            return await this.SendJsonAsync<FineTuningCheckpointsPermissionsParameter, FineTuningCheckpointsPermissionsResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningCheckpointsPermissionsResponse> FineTuningCheckpointsPermissionsAsync(string fine_Tuned_Model_Checkpoint, CancellationToken cancellationToken)
        {
            var p = new FineTuningCheckpointsPermissionsParameter();
            p.Fine_Tuned_Model_Checkpoint = fine_Tuned_Model_Checkpoint;
            return await this.SendJsonAsync<FineTuningCheckpointsPermissionsParameter, FineTuningCheckpointsPermissionsResponse>(p, cancellationToken);
        }
        public async ValueTask<FineTuningCheckpointsPermissionsResponse> FineTuningCheckpointsPermissionsAsync(FineTuningCheckpointsPermissionsParameter parameter)
        {
            return await this.SendJsonAsync<FineTuningCheckpointsPermissionsParameter, FineTuningCheckpointsPermissionsResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<FineTuningCheckpointsPermissionsResponse> FineTuningCheckpointsPermissionsAsync(FineTuningCheckpointsPermissionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FineTuningCheckpointsPermissionsParameter, FineTuningCheckpointsPermissionsResponse>(parameter, cancellationToken);
        }
    }
}
