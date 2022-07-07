using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class B2xidentityuserflowPostUserattributeassignmentsParameter : IRestApiParameter
    {
        public enum B2xidentityuserflowPostUserattributeassignmentsParameterIdentityUserFlowAttributeInputType
        {
            TextBox,
            DateTimeDropdown,
            RadioSingleSelect,
            DropdownSingleSelect,
            EmailBox,
            CheckboxMultiSelect,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public bool? IsOptional { get; set; }
        public bool? RequiresVerification { get; set; }
        public UserAttributeValuesItem[]? UserAttributeValues { get; set; }
        public B2xidentityuserflowPostUserattributeassignmentsParameterIdentityUserFlowAttributeInputType UserInputType { get; set; }
        public IdentityUserFlowAttribute? UserAttribute { get; set; }
        public string Id { get; set; }
    }
    public partial class B2xidentityuserflowPostUserattributeassignmentsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowPostUserattributeassignmentsResponse> B2xidentityuserflowPostUserattributeassignmentsAsync()
        {
            var p = new B2xidentityuserflowPostUserattributeassignmentsParameter();
            return await this.SendAsync<B2xidentityuserflowPostUserattributeassignmentsParameter, B2xidentityuserflowPostUserattributeassignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowPostUserattributeassignmentsResponse> B2xidentityuserflowPostUserattributeassignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityuserflowPostUserattributeassignmentsParameter();
            return await this.SendAsync<B2xidentityuserflowPostUserattributeassignmentsParameter, B2xidentityuserflowPostUserattributeassignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowPostUserattributeassignmentsResponse> B2xidentityuserflowPostUserattributeassignmentsAsync(B2xidentityuserflowPostUserattributeassignmentsParameter parameter)
        {
            return await this.SendAsync<B2xidentityuserflowPostUserattributeassignmentsParameter, B2xidentityuserflowPostUserattributeassignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowPostUserattributeassignmentsResponse> B2xidentityuserflowPostUserattributeassignmentsAsync(B2xidentityuserflowPostUserattributeassignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityuserflowPostUserattributeassignmentsParameter, B2xidentityuserflowPostUserattributeassignmentsResponse>(parameter, cancellationToken);
        }
    }
}
