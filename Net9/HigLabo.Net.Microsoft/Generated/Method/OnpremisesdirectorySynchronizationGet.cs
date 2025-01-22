using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/onpremisesdirectorysynchronization-get?view=graph-rest-1.0
/// </summary>
public partial class OnpremisesdirectorySynchronizationGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Directory_OnPremisesSynchronization: return $"/directory/onPremisesSynchronization";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Directory_OnPremisesSynchronization,
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
public partial class OnpremisesdirectorySynchronizationGetResponse : RestApiResponse
{
    public OnPremisesDirectorySynchronizationConfiguration? Configuration { get; set; }
    public OnPremisesDirectorySynchronizationFeature? Features { get; set; }
    public string? Id { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/onpremisesdirectorysynchronization-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onpremisesdirectorysynchronization-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OnpremisesdirectorySynchronizationGetResponse> OnpremisesdirectorySynchronizationGetAsync()
    {
        var p = new OnpremisesdirectorySynchronizationGetParameter();
        return await this.SendAsync<OnpremisesdirectorySynchronizationGetParameter, OnpremisesdirectorySynchronizationGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onpremisesdirectorysynchronization-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OnpremisesdirectorySynchronizationGetResponse> OnpremisesdirectorySynchronizationGetAsync(CancellationToken cancellationToken)
    {
        var p = new OnpremisesdirectorySynchronizationGetParameter();
        return await this.SendAsync<OnpremisesdirectorySynchronizationGetParameter, OnpremisesdirectorySynchronizationGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onpremisesdirectorysynchronization-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OnpremisesdirectorySynchronizationGetResponse> OnpremisesdirectorySynchronizationGetAsync(OnpremisesdirectorySynchronizationGetParameter parameter)
    {
        return await this.SendAsync<OnpremisesdirectorySynchronizationGetParameter, OnpremisesdirectorySynchronizationGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onpremisesdirectorysynchronization-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OnpremisesdirectorySynchronizationGetResponse> OnpremisesdirectorySynchronizationGetAsync(OnpremisesdirectorySynchronizationGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<OnpremisesdirectorySynchronizationGetParameter, OnpremisesdirectorySynchronizationGetResponse>(parameter, cancellationToken);
    }
}
