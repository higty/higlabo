using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryobject-delta?view=graph-rest-1.0
/// </summary>
public partial class DirectoryObjectDeltaParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.DirectoryObjects_Delta: return $"/directoryObjects/delta";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        DirectoryObjects_Delta,
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
public partial class DirectoryObjectDeltaResponse : RestApiResponse<DirectoryObject>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryobject-delta?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryObjectDeltaResponse> DirectoryObjectDeltaAsync()
    {
        var p = new DirectoryObjectDeltaParameter();
        return await this.SendAsync<DirectoryObjectDeltaParameter, DirectoryObjectDeltaResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryObjectDeltaResponse> DirectoryObjectDeltaAsync(CancellationToken cancellationToken)
    {
        var p = new DirectoryObjectDeltaParameter();
        return await this.SendAsync<DirectoryObjectDeltaParameter, DirectoryObjectDeltaResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryObjectDeltaResponse> DirectoryObjectDeltaAsync(DirectoryObjectDeltaParameter parameter)
    {
        return await this.SendAsync<DirectoryObjectDeltaParameter, DirectoryObjectDeltaResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delta?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryObjectDeltaResponse> DirectoryObjectDeltaAsync(DirectoryObjectDeltaParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DirectoryObjectDeltaParameter, DirectoryObjectDeltaResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-delta?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryObject> DirectoryObjectDeltaEnumerateAsync(DirectoryObjectDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<DirectoryObjectDeltaParameter, DirectoryObjectDeltaResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<DirectoryObject>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
