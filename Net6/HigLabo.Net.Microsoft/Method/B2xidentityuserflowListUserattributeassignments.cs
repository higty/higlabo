using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-userattributeassignments?view=graph-rest-1.0
    /// </summary>
    public partial class B2xidentityUserflowListUserattributeAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_UserAttributeAssignments: return $"/identity/b2xUserFlows/{Id}/userAttributeAssignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DisplayName,
            Id,
            IsOptional,
            RequiresVerification,
            UserAttributeValues,
            UserInputType,
            UserAttribute,
        }
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_UserAttributeAssignments,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class B2xidentityUserflowListUserattributeAssignmentsResponse : RestApiResponse
    {
        public IdentityUserFlowAttributeAssignment[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-userattributeassignments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowListUserattributeAssignmentsResponse> B2xidentityUserflowListUserattributeAssignmentsAsync()
        {
            var p = new B2xidentityUserflowListUserattributeAssignmentsParameter();
            return await this.SendAsync<B2xidentityUserflowListUserattributeAssignmentsParameter, B2xidentityUserflowListUserattributeAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowListUserattributeAssignmentsResponse> B2xidentityUserflowListUserattributeAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityUserflowListUserattributeAssignmentsParameter();
            return await this.SendAsync<B2xidentityUserflowListUserattributeAssignmentsParameter, B2xidentityUserflowListUserattributeAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowListUserattributeAssignmentsResponse> B2xidentityUserflowListUserattributeAssignmentsAsync(B2xidentityUserflowListUserattributeAssignmentsParameter parameter)
        {
            return await this.SendAsync<B2xidentityUserflowListUserattributeAssignmentsParameter, B2xidentityUserflowListUserattributeAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowListUserattributeAssignmentsResponse> B2xidentityUserflowListUserattributeAssignmentsAsync(B2xidentityUserflowListUserattributeAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityUserflowListUserattributeAssignmentsParameter, B2xidentityUserflowListUserattributeAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
