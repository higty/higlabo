using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class B2xidentityuserflowListUserattributeassignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_UserAttributeAssignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_UserAttributeAssignments: return $"/identity/b2xUserFlows/{Id}/userAttributeAssignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string Id { get; set; }
    }
    public partial class B2xidentityuserflowListUserattributeassignmentsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/identityuserflowattributeassignment?view=graph-rest-1.0
        /// </summary>
        public partial class IdentityUserFlowAttributeAssignment
        {
            public enum IdentityUserFlowAttributeAssignmentIdentityUserFlowAttributeInputType
            {
                TextBox,
                DateTimeDropdown,
                RadioSingleSelect,
                DropdownSingleSelect,
                EmailBox,
                CheckboxMultiSelect,
            }

            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public bool? IsOptional { get; set; }
            public bool? RequiresVerification { get; set; }
            public UserAttributeValuesItem[]? UserAttributeValues { get; set; }
            public IdentityUserFlowAttributeAssignmentIdentityUserFlowAttributeInputType UserInputType { get; set; }
        }

        public IdentityUserFlowAttributeAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowListUserattributeassignmentsResponse> B2xidentityuserflowListUserattributeassignmentsAsync()
        {
            var p = new B2xidentityuserflowListUserattributeassignmentsParameter();
            return await this.SendAsync<B2xidentityuserflowListUserattributeassignmentsParameter, B2xidentityuserflowListUserattributeassignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowListUserattributeassignmentsResponse> B2xidentityuserflowListUserattributeassignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityuserflowListUserattributeassignmentsParameter();
            return await this.SendAsync<B2xidentityuserflowListUserattributeassignmentsParameter, B2xidentityuserflowListUserattributeassignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowListUserattributeassignmentsResponse> B2xidentityuserflowListUserattributeassignmentsAsync(B2xidentityuserflowListUserattributeassignmentsParameter parameter)
        {
            return await this.SendAsync<B2xidentityuserflowListUserattributeassignmentsParameter, B2xidentityuserflowListUserattributeassignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowListUserattributeassignmentsResponse> B2xidentityuserflowListUserattributeassignmentsAsync(B2xidentityuserflowListUserattributeassignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityuserflowListUserattributeassignmentsParameter, B2xidentityuserflowListUserattributeassignmentsResponse>(parameter, cancellationToken);
        }
    }
}
