using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-delete?view=graph-rest-1.0
/// </summary>
public partial class ExternalConnectorsExternalItemDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ConnectionsId { get; set; }
        public string? ExternalItemId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.External_Connections_ConnectionsId_Items_ExternalItemId: return $"/external/connections/{ConnectionsId}/items/{ExternalItemId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        External_Connections_ConnectionsId_Items_ExternalItemId,
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
public partial class ExternalConnectorsExternalItemDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ExternalConnectorsExternalItemDeleteResponse> ExternalConnectorsExternalItemDeleteAsync()
    {
        var p = new ExternalConnectorsExternalItemDeleteParameter();
        return await this.SendAsync<ExternalConnectorsExternalItemDeleteParameter, ExternalConnectorsExternalItemDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ExternalConnectorsExternalItemDeleteResponse> ExternalConnectorsExternalItemDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new ExternalConnectorsExternalItemDeleteParameter();
        return await this.SendAsync<ExternalConnectorsExternalItemDeleteParameter, ExternalConnectorsExternalItemDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ExternalConnectorsExternalItemDeleteResponse> ExternalConnectorsExternalItemDeleteAsync(ExternalConnectorsExternalItemDeleteParameter parameter)
    {
        return await this.SendAsync<ExternalConnectorsExternalItemDeleteParameter, ExternalConnectorsExternalItemDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/externalconnectors-externalitem-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ExternalConnectorsExternalItemDeleteResponse> ExternalConnectorsExternalItemDeleteAsync(ExternalConnectorsExternalItemDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ExternalConnectorsExternalItemDeleteParameter, ExternalConnectorsExternalItemDeleteResponse>(parameter, cancellationToken);
    }
}
