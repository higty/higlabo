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
        public FineTuningCheckpointsPermissionsQueryParameter QueryParameter { get; set; } = new FineTuningCheckpointsPermissionsQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/fine_tuning/checkpoints/{Fine_Tuned_Model_Checkpoint}/permissions";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class FineTuningCheckpointsPermissionsQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Identifier for the last permission ID from the previous pagination request.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// Number of permissions to retrieve.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// The order in which to retrieve permissions.
        /// </summary>
        public string? Order { get; set; }
        /// <summary>
        /// The ID of the project to get permissions for.
        /// </summary>
        public string? Project_Id { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.After != null)
            {
                sb.Append($"after={WebUtility.UrlEncode(this.After)}&");
            }
            if (this.Limit != null)
            {
                sb.Append($"limit={this.Limit}&");
            }
            if (this.Order != null)
            {
                sb.Append($"order={WebUtility.UrlEncode(this.Order)}&");
            }
            if (this.Project_Id != null)
            {
                sb.Append($"project_id={WebUtility.UrlEncode(this.Project_Id)}&");
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class FineTuningCheckpointsPermissionsResponse : RestApiResponse
    {
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
