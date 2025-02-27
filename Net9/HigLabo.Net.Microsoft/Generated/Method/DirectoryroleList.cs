﻿using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryrole-list?view=graph-rest-1.0
/// </summary>
public partial class DirectoryroleListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.DirectoryRoles: return $"/directoryRoles";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        DirectoryRoles,
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
public partial class DirectoryroleListResponse : RestApiResponse<DirectoryRole>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryrole-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryroleListResponse> DirectoryroleListAsync()
    {
        var p = new DirectoryroleListParameter();
        return await this.SendAsync<DirectoryroleListParameter, DirectoryroleListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryroleListResponse> DirectoryroleListAsync(CancellationToken cancellationToken)
    {
        var p = new DirectoryroleListParameter();
        return await this.SendAsync<DirectoryroleListParameter, DirectoryroleListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryroleListResponse> DirectoryroleListAsync(DirectoryroleListParameter parameter)
    {
        return await this.SendAsync<DirectoryroleListParameter, DirectoryroleListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryroleListResponse> DirectoryroleListAsync(DirectoryroleListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DirectoryroleListParameter, DirectoryroleListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryRole> DirectoryroleListEnumerateAsync(DirectoryroleListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<DirectoryroleListParameter, DirectoryroleListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<DirectoryRole>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
