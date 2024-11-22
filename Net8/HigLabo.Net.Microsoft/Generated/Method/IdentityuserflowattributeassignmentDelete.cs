using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-delete?view=graph-rest-1.0
/// </summary>
public partial class IdentityUserflowAttributeAssignmentDeleteParameter : IRestApiParameter
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
public partial class IdentityUserflowAttributeAssignmentDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityUserflowAttributeAssignmentDeleteResponse> IdentityUserflowAttributeAssignmentDeleteAsync()
    {
        var p = new IdentityUserflowAttributeAssignmentDeleteParameter();
        return await this.SendAsync<IdentityUserflowAttributeAssignmentDeleteParameter, IdentityUserflowAttributeAssignmentDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityUserflowAttributeAssignmentDeleteResponse> IdentityUserflowAttributeAssignmentDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new IdentityUserflowAttributeAssignmentDeleteParameter();
        return await this.SendAsync<IdentityUserflowAttributeAssignmentDeleteParameter, IdentityUserflowAttributeAssignmentDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityUserflowAttributeAssignmentDeleteResponse> IdentityUserflowAttributeAssignmentDeleteAsync(IdentityUserflowAttributeAssignmentDeleteParameter parameter)
    {
        return await this.SendAsync<IdentityUserflowAttributeAssignmentDeleteParameter, IdentityUserflowAttributeAssignmentDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattributeassignment-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityUserflowAttributeAssignmentDeleteResponse> IdentityUserflowAttributeAssignmentDeleteAsync(IdentityUserflowAttributeAssignmentDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<IdentityUserflowAttributeAssignmentDeleteParameter, IdentityUserflowAttributeAssignmentDeleteResponse>(parameter, cancellationToken);
    }
}
