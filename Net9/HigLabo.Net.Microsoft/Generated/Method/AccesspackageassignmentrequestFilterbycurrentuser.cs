using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
/// </summary>
public partial class AccessPackageAssignmentRequestFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentRequests_FilterByCurrentUser: return $"/identityGovernance/entitlementManagement/assignmentRequests/filterByCurrentUser";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_EntitlementManagement_AssignmentRequests_FilterByCurrentUser,
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
public partial class AccessPackageAssignmentRequestFilterbycurrentUserResponse : RestApiResponse<AccessPackageAssignmentRequest>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageAssignmentRequestFilterbycurrentUserResponse> AccessPackageAssignmentRequestFilterbycurrentUserAsync()
    {
        var p = new AccessPackageAssignmentRequestFilterbycurrentUserParameter();
        return await this.SendAsync<AccessPackageAssignmentRequestFilterbycurrentUserParameter, AccessPackageAssignmentRequestFilterbycurrentUserResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageAssignmentRequestFilterbycurrentUserResponse> AccessPackageAssignmentRequestFilterbycurrentUserAsync(CancellationToken cancellationToken)
    {
        var p = new AccessPackageAssignmentRequestFilterbycurrentUserParameter();
        return await this.SendAsync<AccessPackageAssignmentRequestFilterbycurrentUserParameter, AccessPackageAssignmentRequestFilterbycurrentUserResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageAssignmentRequestFilterbycurrentUserResponse> AccessPackageAssignmentRequestFilterbycurrentUserAsync(AccessPackageAssignmentRequestFilterbycurrentUserParameter parameter)
    {
        return await this.SendAsync<AccessPackageAssignmentRequestFilterbycurrentUserParameter, AccessPackageAssignmentRequestFilterbycurrentUserResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageAssignmentRequestFilterbycurrentUserResponse> AccessPackageAssignmentRequestFilterbycurrentUserAsync(AccessPackageAssignmentRequestFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessPackageAssignmentRequestFilterbycurrentUserParameter, AccessPackageAssignmentRequestFilterbycurrentUserResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AccessPackageAssignmentRequest> AccessPackageAssignmentRequestFilterbycurrentUserEnumerateAsync(AccessPackageAssignmentRequestFilterbycurrentUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<AccessPackageAssignmentRequestFilterbycurrentUserParameter, AccessPackageAssignmentRequestFilterbycurrentUserResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<AccessPackageAssignmentRequest>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
