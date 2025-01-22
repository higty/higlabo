using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-cancel?view=graph-rest-1.0
/// </summary>
public partial class AccessPackageAssignmentRequestCancelParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? AccessPackageAssignmentRequestId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentRequests_AccessPackageAssignmentRequestId_Cancel: return $"/identityGovernance/entitlementManagement/assignmentRequests/{AccessPackageAssignmentRequestId}/cancel";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        IdentityGovernance_EntitlementManagement_AssignmentRequests_AccessPackageAssignmentRequestId_Cancel,
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
}
public partial class AccessPackageAssignmentRequestCancelResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-cancel?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-cancel?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageAssignmentRequestCancelResponse> AccessPackageAssignmentRequestCancelAsync()
    {
        var p = new AccessPackageAssignmentRequestCancelParameter();
        return await this.SendAsync<AccessPackageAssignmentRequestCancelParameter, AccessPackageAssignmentRequestCancelResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-cancel?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageAssignmentRequestCancelResponse> AccessPackageAssignmentRequestCancelAsync(CancellationToken cancellationToken)
    {
        var p = new AccessPackageAssignmentRequestCancelParameter();
        return await this.SendAsync<AccessPackageAssignmentRequestCancelParameter, AccessPackageAssignmentRequestCancelResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-cancel?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageAssignmentRequestCancelResponse> AccessPackageAssignmentRequestCancelAsync(AccessPackageAssignmentRequestCancelParameter parameter)
    {
        return await this.SendAsync<AccessPackageAssignmentRequestCancelParameter, AccessPackageAssignmentRequestCancelResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-cancel?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageAssignmentRequestCancelResponse> AccessPackageAssignmentRequestCancelAsync(AccessPackageAssignmentRequestCancelParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessPackageAssignmentRequestCancelParameter, AccessPackageAssignmentRequestCancelResponse>(parameter, cancellationToken);
    }
}
