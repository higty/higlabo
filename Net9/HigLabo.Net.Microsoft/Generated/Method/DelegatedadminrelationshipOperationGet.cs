using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshipoperation-get?view=graph-rest-1.0
/// </summary>
public partial class DelegatedadminrelationshipOperationGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? DelegatedAdminRelationshipId { get; set; }
        public string? DelegatedAdminRelationshipOperationId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId_Operations_DelegatedAdminRelationshipOperationId: return $"/tenantRelationships/delegatedAdminRelationships/{DelegatedAdminRelationshipId}/operations/{DelegatedAdminRelationshipOperationId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId_Operations_DelegatedAdminRelationshipOperationId,
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
public partial class DelegatedadminrelationshipOperationGetResponse : RestApiResponse
{
    public enum DelegatedAdminRelationshipOperationDelegatedAdminRelationshipOperationType
    {
        DelegatedAdminAccessAssignmentUpdate,
        UnknownFutureValue,
    }
    public enum DelegatedAdminRelationshipOperationLongRunningOperationStatus
    {
        NotStarted,
        Running,
        Succeeded,
        Failed,
        UnknownFutureValue,
    }

    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Data { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public DelegatedAdminRelationshipOperationDelegatedAdminRelationshipOperationType OperationType { get; set; }
    public DelegatedAdminRelationshipOperationLongRunningOperationStatus Status { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshipoperation-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshipoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DelegatedadminrelationshipOperationGetResponse> DelegatedadminrelationshipOperationGetAsync()
    {
        var p = new DelegatedadminrelationshipOperationGetParameter();
        return await this.SendAsync<DelegatedadminrelationshipOperationGetParameter, DelegatedadminrelationshipOperationGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshipoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DelegatedadminrelationshipOperationGetResponse> DelegatedadminrelationshipOperationGetAsync(CancellationToken cancellationToken)
    {
        var p = new DelegatedadminrelationshipOperationGetParameter();
        return await this.SendAsync<DelegatedadminrelationshipOperationGetParameter, DelegatedadminrelationshipOperationGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshipoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DelegatedadminrelationshipOperationGetResponse> DelegatedadminrelationshipOperationGetAsync(DelegatedadminrelationshipOperationGetParameter parameter)
    {
        return await this.SendAsync<DelegatedadminrelationshipOperationGetParameter, DelegatedadminrelationshipOperationGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationshipoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DelegatedadminrelationshipOperationGetResponse> DelegatedadminrelationshipOperationGetAsync(DelegatedadminrelationshipOperationGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DelegatedadminrelationshipOperationGetParameter, DelegatedadminrelationshipOperationGetResponse>(parameter, cancellationToken);
    }
}
