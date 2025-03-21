﻿using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/site-list-subsites?view=graph-rest-1.0
/// </summary>
public partial class SiteListSubsitesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? SiteId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Sites_SiteId_Sites: return $"/sites/{SiteId}/sites";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Sites_SiteId_Sites,
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
public partial class SiteListSubsitesResponse : RestApiResponse<Site>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/site-list-subsites?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-subsites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteListSubsitesResponse> SiteListSubsitesAsync()
    {
        var p = new SiteListSubsitesParameter();
        return await this.SendAsync<SiteListSubsitesParameter, SiteListSubsitesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-subsites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteListSubsitesResponse> SiteListSubsitesAsync(CancellationToken cancellationToken)
    {
        var p = new SiteListSubsitesParameter();
        return await this.SendAsync<SiteListSubsitesParameter, SiteListSubsitesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-subsites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteListSubsitesResponse> SiteListSubsitesAsync(SiteListSubsitesParameter parameter)
    {
        return await this.SendAsync<SiteListSubsitesParameter, SiteListSubsitesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-subsites?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteListSubsitesResponse> SiteListSubsitesAsync(SiteListSubsitesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SiteListSubsitesParameter, SiteListSubsitesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-subsites?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Site> SiteListSubsitesEnumerateAsync(SiteListSubsitesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<SiteListSubsitesParameter, SiteListSubsitesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Site>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
