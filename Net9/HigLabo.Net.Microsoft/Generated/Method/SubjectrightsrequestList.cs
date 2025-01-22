using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list?view=graph-rest-1.0
/// </summary>
public partial class SubjectrightsRequestListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Privacy_SubjectRightsRequests: return $"/privacy/subjectRightsRequests";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Privacy_SubjectRightsRequests,
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
public partial class SubjectrightsRequestListResponse : RestApiResponse<SubjectRightsRequest>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SubjectrightsRequestListResponse> SubjectrightsRequestListAsync()
    {
        var p = new SubjectrightsRequestListParameter();
        return await this.SendAsync<SubjectrightsRequestListParameter, SubjectrightsRequestListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SubjectrightsRequestListResponse> SubjectrightsRequestListAsync(CancellationToken cancellationToken)
    {
        var p = new SubjectrightsRequestListParameter();
        return await this.SendAsync<SubjectrightsRequestListParameter, SubjectrightsRequestListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SubjectrightsRequestListResponse> SubjectrightsRequestListAsync(SubjectrightsRequestListParameter parameter)
    {
        return await this.SendAsync<SubjectrightsRequestListParameter, SubjectrightsRequestListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SubjectrightsRequestListResponse> SubjectrightsRequestListAsync(SubjectrightsRequestListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SubjectrightsRequestListParameter, SubjectrightsRequestListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subjectrightsrequest-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<SubjectRightsRequest> SubjectrightsRequestListEnumerateAsync(SubjectrightsRequestListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<SubjectrightsRequestListParameter, SubjectrightsRequestListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<SubjectRightsRequest>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
