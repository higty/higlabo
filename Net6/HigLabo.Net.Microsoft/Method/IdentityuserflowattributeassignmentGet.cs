using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityuserflowattributeassignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string B2xUserFlowsId { get; set; }
        public string UserAttributeAssignmentsId { get; set; }
    }
    public partial class IdentityuserflowattributeassignmentGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeassignmentGetResponse> IdentityuserflowattributeassignmentGetAsync()
        {
            var p = new IdentityuserflowattributeassignmentGetParameter();
            return await this.SendAsync<IdentityuserflowattributeassignmentGetParameter, IdentityuserflowattributeassignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeassignmentGetResponse> IdentityuserflowattributeassignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityuserflowattributeassignmentGetParameter();
            return await this.SendAsync<IdentityuserflowattributeassignmentGetParameter, IdentityuserflowattributeassignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeassignmentGetResponse> IdentityuserflowattributeassignmentGetAsync(IdentityuserflowattributeassignmentGetParameter parameter)
        {
            return await this.SendAsync<IdentityuserflowattributeassignmentGetParameter, IdentityuserflowattributeassignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityuserflowattributeassignmentGetResponse> IdentityuserflowattributeassignmentGetAsync(IdentityuserflowattributeassignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityuserflowattributeassignmentGetParameter, IdentityuserflowattributeassignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
