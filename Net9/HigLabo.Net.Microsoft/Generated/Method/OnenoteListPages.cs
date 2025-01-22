using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/onenote-list-pages?view=graph-rest-1.0
/// </summary>
public partial class OnenoteListPagesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Onenote_Pages: return $"/me/onenote/pages";
                case ApiPath.Users_IdOrUserPrincipalName_Onenote_Pages: return $"/users/{IdOrUserPrincipalName}/onenote/pages";
                case ApiPath.Groups_Id_Onenote_Pages: return $"/groups/{Id}/onenote/pages";
                case ApiPath.Sites_Id_Onenote_Pages: return $"/sites/{Id}/onenote/pages";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Onenote_Pages,
        Users_IdOrUserPrincipalName_Onenote_Pages,
        Groups_Id_Onenote_Pages,
        Sites_Id_Onenote_Pages,
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
public partial class OnenoteListPagesResponse : RestApiResponse<Page>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/onenote-list-pages?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onenote-list-pages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OnenoteListPagesResponse> OnenoteListPagesAsync()
    {
        var p = new OnenoteListPagesParameter();
        return await this.SendAsync<OnenoteListPagesParameter, OnenoteListPagesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onenote-list-pages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OnenoteListPagesResponse> OnenoteListPagesAsync(CancellationToken cancellationToken)
    {
        var p = new OnenoteListPagesParameter();
        return await this.SendAsync<OnenoteListPagesParameter, OnenoteListPagesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onenote-list-pages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OnenoteListPagesResponse> OnenoteListPagesAsync(OnenoteListPagesParameter parameter)
    {
        return await this.SendAsync<OnenoteListPagesParameter, OnenoteListPagesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onenote-list-pages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OnenoteListPagesResponse> OnenoteListPagesAsync(OnenoteListPagesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<OnenoteListPagesParameter, OnenoteListPagesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onenote-list-pages?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Page> OnenoteListPagesEnumerateAsync(OnenoteListPagesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<OnenoteListPagesParameter, OnenoteListPagesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Page>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
