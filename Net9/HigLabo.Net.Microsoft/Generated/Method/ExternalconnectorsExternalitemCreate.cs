using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-create?view=graph-rest-1.0
/// </summary>
public partial class ExternalConnectorsExternalItemCreateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ConnectionId { get; set; }
        public string? ItemId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.External_Connections_ConnectionId_Items_ItemId: return $"/external/connections/{ConnectionId}/items/{ItemId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        External_Connections_ConnectionId_Items_ItemId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "PUT";
    public string? Id { get; set; }
    public ExternalConnectorsProperties? Properties { get; set; }
    public ExternalConnectorsExternalItemContent? Content { get; set; }
    public ExternalConnectorsAcl[]? Acl { get; set; }
}
public partial class ExternalConnectorsExternalItemCreateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-create?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-create?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ExternalConnectorsExternalItemCreateResponse> ExternalConnectorsExternalItemCreateAsync()
    {
        var p = new ExternalConnectorsExternalItemCreateParameter();
        return await this.SendAsync<ExternalConnectorsExternalItemCreateParameter, ExternalConnectorsExternalItemCreateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-create?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ExternalConnectorsExternalItemCreateResponse> ExternalConnectorsExternalItemCreateAsync(CancellationToken cancellationToken)
    {
        var p = new ExternalConnectorsExternalItemCreateParameter();
        return await this.SendAsync<ExternalConnectorsExternalItemCreateParameter, ExternalConnectorsExternalItemCreateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-create?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ExternalConnectorsExternalItemCreateResponse> ExternalConnectorsExternalItemCreateAsync(ExternalConnectorsExternalItemCreateParameter parameter)
    {
        return await this.SendAsync<ExternalConnectorsExternalItemCreateParameter, ExternalConnectorsExternalItemCreateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-create?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ExternalConnectorsExternalItemCreateResponse> ExternalConnectorsExternalItemCreateAsync(ExternalConnectorsExternalItemCreateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ExternalConnectorsExternalItemCreateParameter, ExternalConnectorsExternalItemCreateResponse>(parameter, cancellationToken);
    }
}
