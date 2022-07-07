using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class InferenceclassificationPostOverridesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_InferenceClassification_Overrides,
            Users_Id_InferenceClassification_Overrides,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_InferenceClassification_Overrides: return $"/me/inferenceClassification/overrides";
                    case ApiPath.Users_Id_InferenceClassification_Overrides: return $"/users/{Id}/inferenceClassification/overrides";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class InferenceclassificationPostOverridesResponse : RestApiResponse
    {
        public enum InferenceClassificationOverrideInferenceClassificationType
        {
            Focused,
            Other,
        }

        public InferenceClassificationOverrideInferenceClassificationType ClassifyAs { get; set; }
        public string? Id { get; set; }
        public EmailAddress? SenderEmailAddress { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/inferenceclassification-post-overrides?view=graph-rest-1.0
        /// </summary>
        public async Task<InferenceclassificationPostOverridesResponse> InferenceclassificationPostOverridesAsync()
        {
            var p = new InferenceclassificationPostOverridesParameter();
            return await this.SendAsync<InferenceclassificationPostOverridesParameter, InferenceclassificationPostOverridesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/inferenceclassification-post-overrides?view=graph-rest-1.0
        /// </summary>
        public async Task<InferenceclassificationPostOverridesResponse> InferenceclassificationPostOverridesAsync(CancellationToken cancellationToken)
        {
            var p = new InferenceclassificationPostOverridesParameter();
            return await this.SendAsync<InferenceclassificationPostOverridesParameter, InferenceclassificationPostOverridesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/inferenceclassification-post-overrides?view=graph-rest-1.0
        /// </summary>
        public async Task<InferenceclassificationPostOverridesResponse> InferenceclassificationPostOverridesAsync(InferenceclassificationPostOverridesParameter parameter)
        {
            return await this.SendAsync<InferenceclassificationPostOverridesParameter, InferenceclassificationPostOverridesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/inferenceclassification-post-overrides?view=graph-rest-1.0
        /// </summary>
        public async Task<InferenceclassificationPostOverridesResponse> InferenceclassificationPostOverridesAsync(InferenceclassificationPostOverridesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InferenceclassificationPostOverridesParameter, InferenceclassificationPostOverridesResponse>(parameter, cancellationToken);
        }
    }
}
