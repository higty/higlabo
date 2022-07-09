using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class B2xidentityUserflowPostUserattributeAssignmentsParameter : IRestApiParameter
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

        public enum B2xidentityUserflowPostUserattributeAssignmentsParameterIdentityUserFlowAttributeInputType
        {
            TextBox,
            DateTimeDropdown,
            RadioSingleSelect,
            DropdownSingleSelect,
            EmailBox,
            CheckboxMultiSelect,
        }
        public enum IdentityUserFlowAttributeAssignmentIdentityUserFlowAttributeInputType
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

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public bool? IsOptional { get; set; }
        public bool? RequiresVerification { get; set; }
        public UserAttributeValuesItem[]? UserAttributeValues { get; set; }
        public B2xidentityUserflowPostUserattributeAssignmentsParameterIdentityUserFlowAttributeInputType UserInputType { get; set; }
        public IdentityUserFlowAttribute? UserAttribute { get; set; }
        public string? Id { get; set; }
    }
    public partial class B2xidentityUserflowPostUserattributeAssignmentsResponse : RestApiResponse
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
        public IdentityUserFlowAttribute? UserAttribute { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowPostUserattributeAssignmentsResponse> B2xidentityUserflowPostUserattributeAssignmentsAsync()
        {
            var p = new B2xidentityUserflowPostUserattributeAssignmentsParameter();
            return await this.SendAsync<B2xidentityUserflowPostUserattributeAssignmentsParameter, B2xidentityUserflowPostUserattributeAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowPostUserattributeAssignmentsResponse> B2xidentityUserflowPostUserattributeAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityUserflowPostUserattributeAssignmentsParameter();
            return await this.SendAsync<B2xidentityUserflowPostUserattributeAssignmentsParameter, B2xidentityUserflowPostUserattributeAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowPostUserattributeAssignmentsResponse> B2xidentityUserflowPostUserattributeAssignmentsAsync(B2xidentityUserflowPostUserattributeAssignmentsParameter parameter)
        {
            return await this.SendAsync<B2xidentityUserflowPostUserattributeAssignmentsParameter, B2xidentityUserflowPostUserattributeAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowPostUserattributeAssignmentsResponse> B2xidentityUserflowPostUserattributeAssignmentsAsync(B2xidentityUserflowPostUserattributeAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityUserflowPostUserattributeAssignmentsParameter, B2xidentityUserflowPostUserattributeAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
