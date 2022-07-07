using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityuserflowattributeassignmentDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_UserAttributeAssignments_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_UserAttributeAssignments_Id: return $"/identity/b2xUserFlows/{B2xUserFlowsId}/userAttributeAssignments/{UserAttributeAssignmentsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string B2xUserFlowsId { get; set; }
        public string UserAttributeAssignmentsId { get; set; }
    }
    public partial class IdentityuserflowattributeassignmentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeassignmentDeleteResponse> IdentityuserflowattributeassignmentDeleteAsync()
        {
            var p = new IdentityuserflowattributeassignmentDeleteParameter();
            return await this.SendAsync<IdentityuserflowattributeassignmentDeleteParameter, IdentityuserflowattributeassignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeassignmentDeleteResponse> IdentityuserflowattributeassignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityuserflowattributeassignmentDeleteParameter();
            return await this.SendAsync<IdentityuserflowattributeassignmentDeleteParameter, IdentityuserflowattributeassignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeassignmentDeleteResponse> IdentityuserflowattributeassignmentDeleteAsync(IdentityuserflowattributeassignmentDeleteParameter parameter)
        {
            return await this.SendAsync<IdentityuserflowattributeassignmentDeleteParameter, IdentityuserflowattributeassignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeassignmentDeleteResponse> IdentityuserflowattributeassignmentDeleteAsync(IdentityuserflowattributeassignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityuserflowattributeassignmentDeleteParameter, IdentityuserflowattributeassignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
