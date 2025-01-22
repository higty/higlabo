using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-list-incidents?view=graph-rest-1.0
/// </summary>
public partial class SecurityListIncidentsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_Incidents: return $"/security/incidents";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Security_Incidents,
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
public partial class SecurityListIncidentsResponse : RestApiResponse<Incident>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/security-list-incidents?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-list-incidents?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityListIncidentsResponse> SecurityListIncidentsAsync()
    {
        var p = new SecurityListIncidentsParameter();
        return await this.SendAsync<SecurityListIncidentsParameter, SecurityListIncidentsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-list-incidents?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityListIncidentsResponse> SecurityListIncidentsAsync(CancellationToken cancellationToken)
    {
        var p = new SecurityListIncidentsParameter();
        return await this.SendAsync<SecurityListIncidentsParameter, SecurityListIncidentsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-list-incidents?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityListIncidentsResponse> SecurityListIncidentsAsync(SecurityListIncidentsParameter parameter)
    {
        return await this.SendAsync<SecurityListIncidentsParameter, SecurityListIncidentsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-list-incidents?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecurityListIncidentsResponse> SecurityListIncidentsAsync(SecurityListIncidentsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecurityListIncidentsParameter, SecurityListIncidentsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-list-incidents?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Incident> SecurityListIncidentsEnumerateAsync(SecurityListIncidentsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<SecurityListIncidentsParameter, SecurityListIncidentsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Incident>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
