using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/ipnamedlocation-get?view=graph-rest-1.0
/// </summary>
public partial class IpnamedLocationGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Identity_ConditionalAccess_NamedLocations_Id: return $"/identity/conditionalAccess/namedLocations/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Identity_ConditionalAccess_NamedLocations_Id,
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
public partial class IpnamedLocationGetResponse : RestApiResponse
{
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public IpRange[]? IpRanges { get; set; }
    public bool? IsTrusted { get; set; }
    public DateTimeOffset? ModifiedDateTime { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/ipnamedlocation-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/ipnamedlocation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IpnamedLocationGetResponse> IpnamedLocationGetAsync()
    {
        var p = new IpnamedLocationGetParameter();
        return await this.SendAsync<IpnamedLocationGetParameter, IpnamedLocationGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/ipnamedlocation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IpnamedLocationGetResponse> IpnamedLocationGetAsync(CancellationToken cancellationToken)
    {
        var p = new IpnamedLocationGetParameter();
        return await this.SendAsync<IpnamedLocationGetParameter, IpnamedLocationGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/ipnamedlocation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IpnamedLocationGetResponse> IpnamedLocationGetAsync(IpnamedLocationGetParameter parameter)
    {
        return await this.SendAsync<IpnamedLocationGetParameter, IpnamedLocationGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/ipnamedlocation-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IpnamedLocationGetResponse> IpnamedLocationGetAsync(IpnamedLocationGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<IpnamedLocationGetParameter, IpnamedLocationGetResponse>(parameter, cancellationToken);
    }
}
