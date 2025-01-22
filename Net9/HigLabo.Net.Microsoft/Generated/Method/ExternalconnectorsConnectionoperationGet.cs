using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/externalconnectors-connectionoperation-get?view=graph-rest-1.0
/// </summary>
public partial class ExternalConnectorsConnectionOperationGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ConnectionsId { get; set; }
        public string? ConnectionOperationId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.External_Connections_ConnectionsId_Operations_ConnectionOperationId: return $"/external/connections/{ConnectionsId}/operations/{ConnectionOperationId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        External_Connections_ConnectionsId_Operations_ConnectionOperationId,
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
public partial class ExternalConnectorsConnectionOperationGetResponse : RestApiResponse
{
    public enum ExternalConnectorsConnectionOperationExternalConnectorsConnectionOperationStatus
    {
        Unspecified,
        Inprogress,
        Completed,
        Failed,
        UnknownFutureValue,
    }

    public PublicError? Error { get; set; }
    public string? Id { get; set; }
    public ExternalConnectorsConnectionOperationExternalConnectorsConnectionOperationStatus Status { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/externalconnectors-connectionoperation-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-connectionoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ExternalConnectorsConnectionOperationGetResponse> ExternalConnectorsConnectionOperationGetAsync()
    {
        var p = new ExternalConnectorsConnectionOperationGetParameter();
        return await this.SendAsync<ExternalConnectorsConnectionOperationGetParameter, ExternalConnectorsConnectionOperationGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-connectionoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ExternalConnectorsConnectionOperationGetResponse> ExternalConnectorsConnectionOperationGetAsync(CancellationToken cancellationToken)
    {
        var p = new ExternalConnectorsConnectionOperationGetParameter();
        return await this.SendAsync<ExternalConnectorsConnectionOperationGetParameter, ExternalConnectorsConnectionOperationGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-connectionoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ExternalConnectorsConnectionOperationGetResponse> ExternalConnectorsConnectionOperationGetAsync(ExternalConnectorsConnectionOperationGetParameter parameter)
    {
        return await this.SendAsync<ExternalConnectorsConnectionOperationGetParameter, ExternalConnectorsConnectionOperationGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-connectionoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ExternalConnectorsConnectionOperationGetResponse> ExternalConnectorsConnectionOperationGetAsync(ExternalConnectorsConnectionOperationGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ExternalConnectorsConnectionOperationGetParameter, ExternalConnectorsConnectionOperationGetResponse>(parameter, cancellationToken);
    }
}
