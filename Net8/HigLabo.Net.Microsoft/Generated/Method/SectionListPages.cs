using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/section-list-pages?view=graph-rest-1.0
    /// </summary>
    public partial class SectionListPagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? GroupsId { get; set; }
            public string? SectionsId { get; set; }
            public string? SitesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Onenote_Sections_Id_Pages: return $"/me/onenote/sections/{Id}/pages";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Sections_Id_Pages: return $"/users/{IdOrUserPrincipalName}/onenote/sections/{Id}/pages";
                    case ApiPath.Groups_Id_Onenote_Sections_Id_Pages: return $"/groups/{GroupsId}/onenote/sections/{SectionsId}/pages";
                    case ApiPath.Sites_Id_Onenote_Sections_Id_Pages: return $"/sites/{SitesId}/onenote/sections/{SectionsId}/pages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Onenote_Sections_Id_Pages,
            Users_IdOrUserPrincipalName_Onenote_Sections_Id_Pages,
            Groups_Id_Onenote_Sections_Id_Pages,
            Sites_Id_Onenote_Sections_Id_Pages,
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
    public partial class SectionListPagesResponse : RestApiResponse<Page>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/section-list-pages?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/section-list-pages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SectionListPagesResponse> SectionListPagesAsync()
        {
            var p = new SectionListPagesParameter();
            return await this.SendAsync<SectionListPagesParameter, SectionListPagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/section-list-pages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SectionListPagesResponse> SectionListPagesAsync(CancellationToken cancellationToken)
        {
            var p = new SectionListPagesParameter();
            return await this.SendAsync<SectionListPagesParameter, SectionListPagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/section-list-pages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SectionListPagesResponse> SectionListPagesAsync(SectionListPagesParameter parameter)
        {
            return await this.SendAsync<SectionListPagesParameter, SectionListPagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/section-list-pages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SectionListPagesResponse> SectionListPagesAsync(SectionListPagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SectionListPagesParameter, SectionListPagesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/section-list-pages?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Page> SectionListPagesEnumerateAsync(SectionListPagesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SectionListPagesParameter, SectionListPagesResponse>(parameter, cancellationToken);
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
}
