using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-userattributeassignments?view=graph-rest-1.0
/// </summary>
public partial class B2xidentityUserflowPostUserAttributeAssignmentsParameter : IRestApiParameter
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

    public enum B2xidentityUserflowPostUserAttributeAssignmentsParameterIdentityUserFlowAttributeInputType
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
    public B2xidentityUserflowPostUserAttributeAssignmentsParameterIdentityUserFlowAttributeInputType UserInputType { get; set; }
    public IdentityUserFlowAttribute? UserAttribute { get; set; }
    public string? Id { get; set; }
}
public partial class B2xidentityUserflowPostUserAttributeAssignmentsResponse : RestApiResponse
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
/// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-userattributeassignments?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-userattributeassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<B2xidentityUserflowPostUserAttributeAssignmentsResponse> B2xidentityUserflowPostUserAttributeAssignmentsAsync()
    {
        var p = new B2xidentityUserflowPostUserAttributeAssignmentsParameter();
        return await this.SendAsync<B2xidentityUserflowPostUserAttributeAssignmentsParameter, B2xidentityUserflowPostUserAttributeAssignmentsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-userattributeassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<B2xidentityUserflowPostUserAttributeAssignmentsResponse> B2xidentityUserflowPostUserAttributeAssignmentsAsync(CancellationToken cancellationToken)
    {
        var p = new B2xidentityUserflowPostUserAttributeAssignmentsParameter();
        return await this.SendAsync<B2xidentityUserflowPostUserAttributeAssignmentsParameter, B2xidentityUserflowPostUserAttributeAssignmentsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-userattributeassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<B2xidentityUserflowPostUserAttributeAssignmentsResponse> B2xidentityUserflowPostUserAttributeAssignmentsAsync(B2xidentityUserflowPostUserAttributeAssignmentsParameter parameter)
    {
        return await this.SendAsync<B2xidentityUserflowPostUserAttributeAssignmentsParameter, B2xidentityUserflowPostUserAttributeAssignmentsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-post-userattributeassignments?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<B2xidentityUserflowPostUserAttributeAssignmentsResponse> B2xidentityUserflowPostUserAttributeAssignmentsAsync(B2xidentityUserflowPostUserAttributeAssignmentsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<B2xidentityUserflowPostUserAttributeAssignmentsParameter, B2xidentityUserflowPostUserAttributeAssignmentsResponse>(parameter, cancellationToken);
    }
}
