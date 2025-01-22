using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/richlongrunningoperation-get?view=graph-rest-1.0
/// </summary>
public partial class RichlongrunningOperationGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? SiteId { get; set; }
        public string? RichLongRunningOperationID { get; set; }
        public string? ListId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Sites_SiteId_Operations_RichLongRunningOperationID: return $"/sites/{SiteId}/operations/{RichLongRunningOperationID}";
                case ApiPath.Sites_SiteId_Lists_ListId_Operations_RichLongRunningOperationID: return $"/sites/{SiteId}/lists/{ListId}/operations/{RichLongRunningOperationID}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Sites_SiteId_Operations_RichLongRunningOperationID,
        Sites_SiteId_Lists_ListId_Operations_RichLongRunningOperationID,
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
public partial class RichlongrunningOperationGetResponse : RestApiResponse
{
    public enum RichLongRunningOperationLongRunningOperationStatus
    {
        NotStarted,
        Running,
        Succeeded,
        Failed,
        UnknownFutureValue,
    }

    public DateTimeOffset? CreatedDateTime { get; set; }
    public PublicError? Error { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastActionDateTime { get; set; }
    public Int32? PercentageComplete { get; set; }
    public string? ResourceId { get; set; }
    public string? ResourceLocation { get; set; }
    public RichLongRunningOperationLongRunningOperationStatus Status { get; set; }
    public string? StatusDetail { get; set; }
    public string? Type { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/richlongrunningoperation-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/richlongrunningoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RichlongrunningOperationGetResponse> RichlongrunningOperationGetAsync()
    {
        var p = new RichlongrunningOperationGetParameter();
        return await this.SendAsync<RichlongrunningOperationGetParameter, RichlongrunningOperationGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/richlongrunningoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RichlongrunningOperationGetResponse> RichlongrunningOperationGetAsync(CancellationToken cancellationToken)
    {
        var p = new RichlongrunningOperationGetParameter();
        return await this.SendAsync<RichlongrunningOperationGetParameter, RichlongrunningOperationGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/richlongrunningoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RichlongrunningOperationGetResponse> RichlongrunningOperationGetAsync(RichlongrunningOperationGetParameter parameter)
    {
        return await this.SendAsync<RichlongrunningOperationGetParameter, RichlongrunningOperationGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/richlongrunningoperation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RichlongrunningOperationGetResponse> RichlongrunningOperationGetAsync(RichlongrunningOperationGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<RichlongrunningOperationGetParameter, RichlongrunningOperationGetResponse>(parameter, cancellationToken);
    }
}
