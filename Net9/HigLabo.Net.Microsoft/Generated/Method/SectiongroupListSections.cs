using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/sectiongroup-list-sections?view=graph-rest-1.0
/// </summary>
public partial class SectionGroupListSectionsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? IdOrUserPrincipalName { get; set; }
        public string? GroupsId { get; set; }
        public string? SectionGroupsId { get; set; }
        public string? SitesId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Onenote_SectionGroups_Id_Sections: return $"/me/onenote/sectionGroups/{Id}/sections";
                case ApiPath.Users_IdOrUserPrincipalName_Onenote_SectionGroups_Id_Sections: return $"/users/{IdOrUserPrincipalName}/onenote/sectionGroups/{Id}/sections";
                case ApiPath.Groups_Id_Onenote_SectionGroups_Id_Sections: return $"/groups/{GroupsId}/onenote/sectionGroups/{SectionGroupsId}/sections";
                case ApiPath.Sites_Id_Onenote_SectionGroups_Id_Sections: return $"/sites/{SitesId}/onenote/sectionGroups/{SectionGroupsId}/sections";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Onenote_SectionGroups_Id_Sections,
        Users_IdOrUserPrincipalName_Onenote_SectionGroups_Id_Sections,
        Groups_Id_Onenote_SectionGroups_Id_Sections,
        Sites_Id_Onenote_SectionGroups_Id_Sections,
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
public partial class SectionGroupListSectionsResponse : RestApiResponse<Section>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/sectiongroup-list-sections?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sectiongroup-list-sections?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SectionGroupListSectionsResponse> SectionGroupListSectionsAsync()
    {
        var p = new SectionGroupListSectionsParameter();
        return await this.SendAsync<SectionGroupListSectionsParameter, SectionGroupListSectionsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sectiongroup-list-sections?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SectionGroupListSectionsResponse> SectionGroupListSectionsAsync(CancellationToken cancellationToken)
    {
        var p = new SectionGroupListSectionsParameter();
        return await this.SendAsync<SectionGroupListSectionsParameter, SectionGroupListSectionsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sectiongroup-list-sections?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SectionGroupListSectionsResponse> SectionGroupListSectionsAsync(SectionGroupListSectionsParameter parameter)
    {
        return await this.SendAsync<SectionGroupListSectionsParameter, SectionGroupListSectionsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sectiongroup-list-sections?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SectionGroupListSectionsResponse> SectionGroupListSectionsAsync(SectionGroupListSectionsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SectionGroupListSectionsParameter, SectionGroupListSectionsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/sectiongroup-list-sections?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Section> SectionGroupListSectionsEnumerateAsync(SectionGroupListSectionsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<SectionGroupListSectionsParameter, SectionGroupListSectionsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Section>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
