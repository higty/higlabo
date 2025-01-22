using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-get?view=graph-rest-1.0
/// </summary>
public partial class IdentityUserflowAttributeAssignmentGetParameter : IRestApiParameter, IQueryParameterProperty
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

    public enum Field
    {
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
public partial class IdentityUserflowAttributeAssignmentGetResponse : RestApiResponse
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
/// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityUserflowAttributeAssignmentGetResponse> IdentityUserflowAttributeAssignmentGetAsync()
    {
        var p = new IdentityUserflowAttributeAssignmentGetParameter();
        return await this.SendAsync<IdentityUserflowAttributeAssignmentGetParameter, IdentityUserflowAttributeAssignmentGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityUserflowAttributeAssignmentGetResponse> IdentityUserflowAttributeAssignmentGetAsync(CancellationToken cancellationToken)
    {
        var p = new IdentityUserflowAttributeAssignmentGetParameter();
        return await this.SendAsync<IdentityUserflowAttributeAssignmentGetParameter, IdentityUserflowAttributeAssignmentGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityUserflowAttributeAssignmentGetResponse> IdentityUserflowAttributeAssignmentGetAsync(IdentityUserflowAttributeAssignmentGetParameter parameter)
    {
        return await this.SendAsync<IdentityUserflowAttributeAssignmentGetParameter, IdentityUserflowAttributeAssignmentGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityUserflowAttributeAssignmentGetResponse> IdentityUserflowAttributeAssignmentGetAsync(IdentityUserflowAttributeAssignmentGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<IdentityUserflowAttributeAssignmentGetParameter, IdentityUserflowAttributeAssignmentGetResponse>(parameter, cancellationToken);
    }
}
