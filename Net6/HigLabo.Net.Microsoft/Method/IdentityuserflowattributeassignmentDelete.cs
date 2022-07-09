using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityUserflowattributeAssignmentDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? B2xUserFlowsId { get; set; }
            public string? UserAttributeAssignmentsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_UserAttributeAssignments_Id: return $"/identity/b2xUserFlows/{B2xUserFlowsId}/userAttributeAssignments/{UserAttributeAssignmentsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_UserAttributeAssignments_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class IdentityUserflowattributeAssignmentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeAssignmentDeleteResponse> IdentityUserflowattributeAssignmentDeleteAsync()
        {
            var p = new IdentityUserflowattributeAssignmentDeleteParameter();
            return await this.SendAsync<IdentityUserflowattributeAssignmentDeleteParameter, IdentityUserflowattributeAssignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeAssignmentDeleteResponse> IdentityUserflowattributeAssignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityUserflowattributeAssignmentDeleteParameter();
            return await this.SendAsync<IdentityUserflowattributeAssignmentDeleteParameter, IdentityUserflowattributeAssignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeAssignmentDeleteResponse> IdentityUserflowattributeAssignmentDeleteAsync(IdentityUserflowattributeAssignmentDeleteParameter parameter)
        {
            return await this.SendAsync<IdentityUserflowattributeAssignmentDeleteParameter, IdentityUserflowattributeAssignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeAssignmentDeleteResponse> IdentityUserflowattributeAssignmentDeleteAsync(IdentityUserflowattributeAssignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityUserflowattributeAssignmentDeleteParameter, IdentityUserflowattributeAssignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
