using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class InferenceclassificationoverrideDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_InferenceClassification_Overrides_Id,
            Users_Id_InferenceClassification_Overrides_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_InferenceClassification_Overrides_Id: return $"/me/inferenceClassification/overrides/{Id}";
                    case ApiPath.Users_Id_InferenceClassification_Overrides_Id: return $"/users/{UsersId}/inferenceClassification/overrides/{OverridesId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
        public string UsersId { get; set; }
        public string OverridesId { get; set; }
    }
    public partial class InferenceclassificationoverrideDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/inferenceclassificationoverride-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<InferenceclassificationoverrideDeleteResponse> InferenceclassificationoverrideDeleteAsync()
        {
            var p = new InferenceclassificationoverrideDeleteParameter();
            return await this.SendAsync<InferenceclassificationoverrideDeleteParameter, InferenceclassificationoverrideDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/inferenceclassificationoverride-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<InferenceclassificationoverrideDeleteResponse> InferenceclassificationoverrideDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new InferenceclassificationoverrideDeleteParameter();
            return await this.SendAsync<InferenceclassificationoverrideDeleteParameter, InferenceclassificationoverrideDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/inferenceclassificationoverride-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<InferenceclassificationoverrideDeleteResponse> InferenceclassificationoverrideDeleteAsync(InferenceclassificationoverrideDeleteParameter parameter)
        {
            return await this.SendAsync<InferenceclassificationoverrideDeleteParameter, InferenceclassificationoverrideDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/inferenceclassificationoverride-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<InferenceclassificationoverrideDeleteResponse> InferenceclassificationoverrideDeleteAsync(InferenceclassificationoverrideDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InferenceclassificationoverrideDeleteParameter, InferenceclassificationoverrideDeleteResponse>(parameter, cancellationToken);
        }
    }
}
