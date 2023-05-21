using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-update?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityUserflowattributeAssignmentUpdateParameter : IRestApiParameter
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

        public enum IdentityUserflowattributeAssignmentUpdateParameterIdentityUserFlowAttributeInputType
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? DisplayName { get; set; }
        public bool? IsOptional { get; set; }
        public bool? RequiresVerification { get; set; }
        public UserAttributeValuesItem[]? UserAttributeValues { get; set; }
        public IdentityUserflowattributeAssignmentUpdateParameterIdentityUserFlowAttributeInputType UserInputType { get; set; }
    }
    public partial class IdentityUserflowattributeAssignmentUpdateResponse : RestApiResponse
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

        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsOptional { get; set; }
        public bool? RequiresVerification { get; set; }
        public UserAttributeValuesItem[]? UserAttributeValues { get; set; }
        public IdentityUserFlowAttributeAssignmentIdentityUserFlowAttributeInputType UserInputType { get; set; }
        public IdentityUserFlowAttribute? UserAttribute { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeAssignmentUpdateResponse> IdentityUserflowattributeAssignmentUpdateAsync()
        {
            var p = new IdentityUserflowattributeAssignmentUpdateParameter();
            return await this.SendAsync<IdentityUserflowattributeAssignmentUpdateParameter, IdentityUserflowattributeAssignmentUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeAssignmentUpdateResponse> IdentityUserflowattributeAssignmentUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityUserflowattributeAssignmentUpdateParameter();
            return await this.SendAsync<IdentityUserflowattributeAssignmentUpdateParameter, IdentityUserflowattributeAssignmentUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeAssignmentUpdateResponse> IdentityUserflowattributeAssignmentUpdateAsync(IdentityUserflowattributeAssignmentUpdateParameter parameter)
        {
            return await this.SendAsync<IdentityUserflowattributeAssignmentUpdateParameter, IdentityUserflowattributeAssignmentUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityUserflowattributeAssignmentUpdateResponse> IdentityUserflowattributeAssignmentUpdateAsync(IdentityUserflowattributeAssignmentUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityUserflowattributeAssignmentUpdateParameter, IdentityUserflowattributeAssignmentUpdateResponse>(parameter, cancellationToken);
        }
    }
}
