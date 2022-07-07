using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SectiongroupListSectionsParameter : IRestApiParameter, IQueryParameterProperty
    {
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

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Onenote_SectionGroups_Id_Sections: return $"/me/onenote/sectionGroups/{Id}/sections";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_SectionGroups_Id_Sections: return $"/users/{IdOrUserPrincipalName}/onenote/sectionGroups/{Id}/sections";
                    case ApiPath.Groups_Id_Onenote_SectionGroups_Id_Sections: return $"/groups/{GroupsId}/onenote/sectionGroups/{SectionGroupsId}/sections";
                    case ApiPath.Sites_Id_Onenote_SectionGroups_Id_Sections: return $"/sites/{SitesId}/onenote/sectionGroups/{SectionGroupsId}/sections";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string GroupsId { get; set; }
        public string SectionGroupsId { get; set; }
        public string SitesId { get; set; }
    }
    public partial class SectiongroupListSectionsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/section?view=graph-rest-1.0
        /// </summary>
        public partial class Section
        {
            public IdentitySet? CreatedBy { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Id { get; set; }
            public bool? IsDefault { get; set; }
            public IdentitySet? LastModifiedBy { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public SectionLinks? Links { get; set; }
            public string? DisplayName { get; set; }
            public string? PagesUrl { get; set; }
            public string? Self { get; set; }
        }

        public Section[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/sectiongroup-list-sections?view=graph-rest-1.0
        /// </summary>
        public async Task<SectiongroupListSectionsResponse> SectiongroupListSectionsAsync()
        {
            var p = new SectiongroupListSectionsParameter();
            return await this.SendAsync<SectiongroupListSectionsParameter, SectiongroupListSectionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/sectiongroup-list-sections?view=graph-rest-1.0
        /// </summary>
        public async Task<SectiongroupListSectionsResponse> SectiongroupListSectionsAsync(CancellationToken cancellationToken)
        {
            var p = new SectiongroupListSectionsParameter();
            return await this.SendAsync<SectiongroupListSectionsParameter, SectiongroupListSectionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/sectiongroup-list-sections?view=graph-rest-1.0
        /// </summary>
        public async Task<SectiongroupListSectionsResponse> SectiongroupListSectionsAsync(SectiongroupListSectionsParameter parameter)
        {
            return await this.SendAsync<SectiongroupListSectionsParameter, SectiongroupListSectionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/sectiongroup-list-sections?view=graph-rest-1.0
        /// </summary>
        public async Task<SectiongroupListSectionsResponse> SectiongroupListSectionsAsync(SectiongroupListSectionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SectiongroupListSectionsParameter, SectiongroupListSectionsResponse>(parameter, cancellationToken);
        }
    }
}
