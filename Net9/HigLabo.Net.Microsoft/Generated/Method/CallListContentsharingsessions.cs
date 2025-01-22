using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/call-list-contentsharingsessions?view=graph-rest-1.0
/// </summary>
public partial class CallListContentsharingsessionsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Communications_Calls_Id_ContentSharingSessions: return $"/communications/calls/{Id}/contentSharingSessions";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Communications_Calls_Id_ContentSharingSessions,
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
public partial class CallListContentsharingsessionsResponse : RestApiResponse<ContentSharingSession>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/call-list-contentsharingsessions?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-list-contentsharingsessions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallListContentsharingsessionsResponse> CallListContentsharingsessionsAsync()
    {
        var p = new CallListContentsharingsessionsParameter();
        return await this.SendAsync<CallListContentsharingsessionsParameter, CallListContentsharingsessionsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-list-contentsharingsessions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallListContentsharingsessionsResponse> CallListContentsharingsessionsAsync(CancellationToken cancellationToken)
    {
        var p = new CallListContentsharingsessionsParameter();
        return await this.SendAsync<CallListContentsharingsessionsParameter, CallListContentsharingsessionsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-list-contentsharingsessions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallListContentsharingsessionsResponse> CallListContentsharingsessionsAsync(CallListContentsharingsessionsParameter parameter)
    {
        return await this.SendAsync<CallListContentsharingsessionsParameter, CallListContentsharingsessionsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-list-contentsharingsessions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallListContentsharingsessionsResponse> CallListContentsharingsessionsAsync(CallListContentsharingsessionsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<CallListContentsharingsessionsParameter, CallListContentsharingsessionsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-list-contentsharingsessions?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ContentSharingSession> CallListContentsharingsessionsEnumerateAsync(CallListContentsharingsessionsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<CallListContentsharingsessionsParameter, CallListContentsharingsessionsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ContentSharingSession>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
