using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityuserflowattributeDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Identity_UserFlowAttributes_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_UserFlowAttributes_Id: return $"/identity/userFlowAttributes/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class IdentityuserflowattributeDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeDeleteResponse> IdentityuserflowattributeDeleteAsync()
        {
            var p = new IdentityuserflowattributeDeleteParameter();
            return await this.SendAsync<IdentityuserflowattributeDeleteParameter, IdentityuserflowattributeDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeDeleteResponse> IdentityuserflowattributeDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityuserflowattributeDeleteParameter();
            return await this.SendAsync<IdentityuserflowattributeDeleteParameter, IdentityuserflowattributeDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeDeleteResponse> IdentityuserflowattributeDeleteAsync(IdentityuserflowattributeDeleteParameter parameter)
        {
            return await this.SendAsync<IdentityuserflowattributeDeleteParameter, IdentityuserflowattributeDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattribute-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeDeleteResponse> IdentityuserflowattributeDeleteAsync(IdentityuserflowattributeDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityuserflowattributeDeleteParameter, IdentityuserflowattributeDeleteResponse>(parameter, cancellationToken);
        }
    }
}
