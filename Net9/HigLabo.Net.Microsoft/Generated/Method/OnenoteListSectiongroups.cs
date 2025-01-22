using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/onenote-list-sectiongroups?view=graph-rest-1.0
/// </summary>
public partial class OnenoteListSectionGroupsParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.Me_Onenote_SectionGroups: return $"/me/onenote/sectionGroups";
                case ApiPath.Users_IdOrUserPrincipalName_Onenote_SectionGroups: return $"/users/{IdOrUserPrincipalName}/onenote/sectionGroups";
                case ApiPath.Groups_Id_Onenote_SectionGroups: return $"/groups/{Id}/onenote/sectionGroups";
                case ApiPath.Sites_Id_Onenote_SectionGroups: return $"/sites/{Id}/onenote/sectionGroups";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Onenote_SectionGroups,
        Users_IdOrUserPrincipalName_Onenote_SectionGroups,
        Groups_Id_Onenote_SectionGroups,
        Sites_Id_Onenote_SectionGroups,
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
public partial class OnenoteListSectionGroupsResponse : RestApiResponse<SectionGroup>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/onenote-list-sectiongroups?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onenote-list-sectiongroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OnenoteListSectionGroupsResponse> OnenoteListSectionGroupsAsync()
    {
        var p = new OnenoteListSectionGroupsParameter();
        return await this.SendAsync<OnenoteListSectionGroupsParameter, OnenoteListSectionGroupsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onenote-list-sectiongroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OnenoteListSectionGroupsResponse> OnenoteListSectionGroupsAsync(CancellationToken cancellationToken)
    {
        var p = new OnenoteListSectionGroupsParameter();
        return await this.SendAsync<OnenoteListSectionGroupsParameter, OnenoteListSectionGroupsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onenote-list-sectiongroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OnenoteListSectionGroupsResponse> OnenoteListSectionGroupsAsync(OnenoteListSectionGroupsParameter parameter)
    {
        return await this.SendAsync<OnenoteListSectionGroupsParameter, OnenoteListSectionGroupsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onenote-list-sectiongroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OnenoteListSectionGroupsResponse> OnenoteListSectionGroupsAsync(OnenoteListSectionGroupsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<OnenoteListSectionGroupsParameter, OnenoteListSectionGroupsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onenote-list-sectiongroups?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<SectionGroup> OnenoteListSectionGroupsEnumerateAsync(OnenoteListSectionGroupsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<OnenoteListSectionGroupsParameter, OnenoteListSectionGroupsResponse>(parameter, cancellationToken);
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
