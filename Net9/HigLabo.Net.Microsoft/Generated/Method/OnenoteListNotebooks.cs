using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/onenote-list-notebooks?view=graph-rest-1.0
/// </summary>
public partial class OnenoteListNotebooksParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.Me_Onenote_Notebooks: return $"/me/onenote/notebooks";
                case ApiPath.Users_IdOrUserPrincipalName_Onenote_Notebooks: return $"/users/{IdOrUserPrincipalName}/onenote/notebooks";
                case ApiPath.Groups_Id_Onenote_Notebooks: return $"/groups/{Id}/onenote/notebooks";
                case ApiPath.Sites_Id_Onenote_Notebooks: return $"/sites/{Id}/onenote/notebooks";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Onenote_Notebooks,
        Users_IdOrUserPrincipalName_Onenote_Notebooks,
        Groups_Id_Onenote_Notebooks,
        Sites_Id_Onenote_Notebooks,
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
public partial class OnenoteListNotebooksResponse : RestApiResponse<Notebook>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/onenote-list-notebooks?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onenote-list-notebooks?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OnenoteListNotebooksResponse> OnenoteListNotebooksAsync()
    {
        var p = new OnenoteListNotebooksParameter();
        return await this.SendAsync<OnenoteListNotebooksParameter, OnenoteListNotebooksResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onenote-list-notebooks?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OnenoteListNotebooksResponse> OnenoteListNotebooksAsync(CancellationToken cancellationToken)
    {
        var p = new OnenoteListNotebooksParameter();
        return await this.SendAsync<OnenoteListNotebooksParameter, OnenoteListNotebooksResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onenote-list-notebooks?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OnenoteListNotebooksResponse> OnenoteListNotebooksAsync(OnenoteListNotebooksParameter parameter)
    {
        return await this.SendAsync<OnenoteListNotebooksParameter, OnenoteListNotebooksResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onenote-list-notebooks?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OnenoteListNotebooksResponse> OnenoteListNotebooksAsync(OnenoteListNotebooksParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<OnenoteListNotebooksParameter, OnenoteListNotebooksResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onenote-list-notebooks?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Notebook> OnenoteListNotebooksEnumerateAsync(OnenoteListNotebooksParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<OnenoteListNotebooksParameter, OnenoteListNotebooksResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Notebook>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
