using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshiprequest-get?view=graph-rest-1.0
/// </summary>
public partial class DelegatedadminrelationshipRequestGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? DelegatedAdminRelationshipId { get; set; }
        public string? DelegatedAdminRelationshipRequestId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId_Requests_DelegatedAdminRelationshipRequestId: return $"/tenantRelationships/delegatedAdminRelationships/{DelegatedAdminRelationshipId}/requests/{DelegatedAdminRelationshipRequestId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId_Requests_DelegatedAdminRelationshipRequestId,
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
public partial class DelegatedadminrelationshipRequestGetResponse : RestApiResponse
{
    public enum DelegatedAdminRelationshipRequestDelegatedAdminRelationshipRequestStatus
    {
        Created,
        Pending,
        Succeeded,
        Failed,
        UnknownFutureValue,
    }

    public DelegatedAdminRelationshipRequestAction? Action { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public DelegatedAdminRelationshipRequestDelegatedAdminRelationshipRequestStatus Status { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshiprequest-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshiprequest-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DelegatedadminrelationshipRequestGetResponse> DelegatedadminrelationshipRequestGetAsync()
    {
        var p = new DelegatedadminrelationshipRequestGetParameter();
        return await this.SendAsync<DelegatedadminrelationshipRequestGetParameter, DelegatedadminrelationshipRequestGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshiprequest-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DelegatedadminrelationshipRequestGetResponse> DelegatedadminrelationshipRequestGetAsync(CancellationToken cancellationToken)
    {
        var p = new DelegatedadminrelationshipRequestGetParameter();
        return await this.SendAsync<DelegatedadminrelationshipRequestGetParameter, DelegatedadminrelationshipRequestGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshiprequest-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DelegatedadminrelationshipRequestGetResponse> DelegatedadminrelationshipRequestGetAsync(DelegatedadminrelationshipRequestGetParameter parameter)
    {
        return await this.SendAsync<DelegatedadminrelationshipRequestGetParameter, DelegatedadminrelationshipRequestGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshiprequest-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DelegatedadminrelationshipRequestGetResponse> DelegatedadminrelationshipRequestGetAsync(DelegatedadminrelationshipRequestGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DelegatedadminrelationshipRequestGetParameter, DelegatedadminrelationshipRequestGetResponse>(parameter, cancellationToken);
    }
}
