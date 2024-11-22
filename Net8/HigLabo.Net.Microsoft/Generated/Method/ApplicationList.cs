using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/application-list?view=graph-rest-1.0
/// </summary>
public partial class ApplicationListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Applications: return $"/applications";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Applications,
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
public partial class ApplicationListResponse : RestApiResponse<Application>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/application-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationListResponse> ApplicationListAsync()
    {
        var p = new ApplicationListParameter();
        return await this.SendAsync<ApplicationListParameter, ApplicationListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationListResponse> ApplicationListAsync(CancellationToken cancellationToken)
    {
        var p = new ApplicationListParameter();
        return await this.SendAsync<ApplicationListParameter, ApplicationListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationListResponse> ApplicationListAsync(ApplicationListParameter parameter)
    {
        return await this.SendAsync<ApplicationListParameter, ApplicationListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationListResponse> ApplicationListAsync(ApplicationListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ApplicationListParameter, ApplicationListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Application> ApplicationListEnumerateAsync(ApplicationListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ApplicationListParameter, ApplicationListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Application>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
