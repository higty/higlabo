using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/notebook-list-sectiongroups?view=graph-rest-1.0
/// </summary>
public partial class NotebookListSectionGroupsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? IdOrUserPrincipalName { get; set; }
        public string? GroupsId { get; set; }
        public string? NotebooksId { get; set; }
        public string? SitesId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Onenote_Notebooks_Id_SectionGroups: return $"/me/onenote/notebooks/{Id}/sectionGroups";
                case ApiPath.Users_IdOrUserPrincipalName_Onenote_Notebooks_Id_SectionGroups: return $"/users/{IdOrUserPrincipalName}/onenote/notebooks/{Id}/sectionGroups";
                case ApiPath.Groups_Id_Onenote_Notebooks_Id_SectionGroups: return $"/groups/{GroupsId}/onenote/notebooks/{NotebooksId}/sectionGroups";
                case ApiPath.Sites_Id_Onenote_Notebooks_Id_SectionGroups: return $"/sites/{SitesId}/onenote/notebooks/{NotebooksId}/sectionGroups";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Onenote_Notebooks_Id_SectionGroups,
        Users_IdOrUserPrincipalName_Onenote_Notebooks_Id_SectionGroups,
        Groups_Id_Onenote_Notebooks_Id_SectionGroups,
        Sites_Id_Onenote_Notebooks_Id_SectionGroups,
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
public partial class NotebookListSectionGroupsResponse : RestApiResponse<SectionGroup>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/notebook-list-sectiongroups?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/notebook-list-sectiongroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<NotebookListSectionGroupsResponse> NotebookListSectionGroupsAsync()
    {
        var p = new NotebookListSectionGroupsParameter();
        return await this.SendAsync<NotebookListSectionGroupsParameter, NotebookListSectionGroupsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/notebook-list-sectiongroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<NotebookListSectionGroupsResponse> NotebookListSectionGroupsAsync(CancellationToken cancellationToken)
    {
        var p = new NotebookListSectionGroupsParameter();
        return await this.SendAsync<NotebookListSectionGroupsParameter, NotebookListSectionGroupsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/notebook-list-sectiongroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<NotebookListSectionGroupsResponse> NotebookListSectionGroupsAsync(NotebookListSectionGroupsParameter parameter)
    {
        return await this.SendAsync<NotebookListSectionGroupsParameter, NotebookListSectionGroupsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/notebook-list-sectiongroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<NotebookListSectionGroupsResponse> NotebookListSectionGroupsAsync(NotebookListSectionGroupsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<NotebookListSectionGroupsParameter, NotebookListSectionGroupsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/notebook-list-sectiongroups?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<SectionGroup> NotebookListSectionGroupsEnumerateAsync(NotebookListSectionGroupsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<NotebookListSectionGroupsParameter, NotebookListSectionGroupsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<SectionGroup>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
