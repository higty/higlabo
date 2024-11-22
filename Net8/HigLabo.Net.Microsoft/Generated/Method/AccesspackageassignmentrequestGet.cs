using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-get?view=graph-rest-1.0
/// </summary>
public partial class AccessPackageAssignmentRequestGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? AccessPackageAssignmentRequestId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentRequests_AccessPackageAssignmentRequestId: return $"/identityGovernance/entitlementManagement/assignmentRequests/{AccessPackageAssignmentRequestId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_EntitlementManagement_AssignmentRequests_AccessPackageAssignmentRequestId,
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
public partial class AccessPackageAssignmentRequestGetResponse : RestApiResponse
{
    public enum AccessPackageAssignmentRequestAccessPackageRequestType
    {
        NotSpecified,
        UserAdd,
        UserExtend,
        UserUpdate,
        UserRemove,
        AdminAdd,
        AdminUpdate,
        AdminRemove,
        SystemAdd,
        SystemUpdate,
        SystemRemove,
        OnBehalfAdd,
        UnknownFutureValue,
    }
    public enum AccessPackageAssignmentRequestAccessPackageRequestState
    {
        Submitted,
        PendingApproval,
        Delivering,
        Delivered,
        DeliveryFailed,
        Denied,
        Scheduled,
        Canceled,
        PartiallyDelivered,
        UnknownFutureValue,
        Eq,
    }

    public AccessPackageAnswer[]? Answers { get; set; }
    public DateTimeOffset? CompletedDateTime { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public AccessPackageAssignmentRequestAccessPackageRequestType RequestType { get; set; }
    public EntitlementManagementSchedule? Schedule { get; set; }
    public AccessPackageAssignmentRequestAccessPackageRequestState State { get; set; }
    public string? Status { get; set; }
    public AccessPackage? AccessPackage { get; set; }
    public AccessPackageAssignment? Assignment { get; set; }
    public AccessPackageSubject? Requestor { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageAssignmentRequestGetResponse> AccessPackageAssignmentRequestGetAsync()
    {
        var p = new AccessPackageAssignmentRequestGetParameter();
        return await this.SendAsync<AccessPackageAssignmentRequestGetParameter, AccessPackageAssignmentRequestGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageAssignmentRequestGetResponse> AccessPackageAssignmentRequestGetAsync(CancellationToken cancellationToken)
    {
        var p = new AccessPackageAssignmentRequestGetParameter();
        return await this.SendAsync<AccessPackageAssignmentRequestGetParameter, AccessPackageAssignmentRequestGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageAssignmentRequestGetResponse> AccessPackageAssignmentRequestGetAsync(AccessPackageAssignmentRequestGetParameter parameter)
    {
        return await this.SendAsync<AccessPackageAssignmentRequestGetParameter, AccessPackageAssignmentRequestGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageAssignmentRequestGetResponse> AccessPackageAssignmentRequestGetAsync(AccessPackageAssignmentRequestGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessPackageAssignmentRequestGetParameter, AccessPackageAssignmentRequestGetResponse>(parameter, cancellationToken);
    }
}
