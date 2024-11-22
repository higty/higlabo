using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directory-list-administrativeunits?view=graph-rest-1.0
/// </summary>
public partial class DirectoryListAdministrativeunitsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Directory_AdministrativeUnits: return $"/directory/administrativeUnits";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Directory_AdministrativeUnits,
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
public partial class DirectoryListAdministrativeunitsResponse : RestApiResponse<AdministrativeUnit>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directory-list-administrativeunits?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-list-administrativeunits?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryListAdministrativeunitsResponse> DirectoryListAdministrativeunitsAsync()
    {
        var p = new DirectoryListAdministrativeunitsParameter();
        return await this.SendAsync<DirectoryListAdministrativeunitsParameter, DirectoryListAdministrativeunitsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-list-administrativeunits?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryListAdministrativeunitsResponse> DirectoryListAdministrativeunitsAsync(CancellationToken cancellationToken)
    {
        var p = new DirectoryListAdministrativeunitsParameter();
        return await this.SendAsync<DirectoryListAdministrativeunitsParameter, DirectoryListAdministrativeunitsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-list-administrativeunits?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryListAdministrativeunitsResponse> DirectoryListAdministrativeunitsAsync(DirectoryListAdministrativeunitsParameter parameter)
    {
        return await this.SendAsync<DirectoryListAdministrativeunitsParameter, DirectoryListAdministrativeunitsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-list-administrativeunits?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryListAdministrativeunitsResponse> DirectoryListAdministrativeunitsAsync(DirectoryListAdministrativeunitsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DirectoryListAdministrativeunitsParameter, DirectoryListAdministrativeunitsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-list-administrativeunits?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AdministrativeUnit> DirectoryListAdministrativeunitsEnumerateAsync(DirectoryListAdministrativeunitsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<DirectoryListAdministrativeunitsParameter, DirectoryListAdministrativeunitsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<AdministrativeUnit>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
