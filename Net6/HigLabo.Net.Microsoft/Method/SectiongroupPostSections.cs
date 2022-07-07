using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SectiongroupPostSectionsParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string GroupsId { get; set; }
        public string SectionGroupsId { get; set; }
        public string SitesId { get; set; }
    }
    public partial class SectiongroupPostSectionsResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/sectiongroup-post-sections?view=graph-rest-1.0
        /// </summary>
        public async Task<SectiongroupPostSectionsResponse> SectiongroupPostSectionsAsync()
        {
            var p = new SectiongroupPostSectionsParameter();
            return await this.SendAsync<SectiongroupPostSectionsParameter, SectiongroupPostSectionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/sectiongroup-post-sections?view=graph-rest-1.0
        /// </summary>
        public async Task<SectiongroupPostSectionsResponse> SectiongroupPostSectionsAsync(CancellationToken cancellationToken)
        {
            var p = new SectiongroupPostSectionsParameter();
            return await this.SendAsync<SectiongroupPostSectionsParameter, SectiongroupPostSectionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/sectiongroup-post-sections?view=graph-rest-1.0
        /// </summary>
        public async Task<SectiongroupPostSectionsResponse> SectiongroupPostSectionsAsync(SectiongroupPostSectionsParameter parameter)
        {
            return await this.SendAsync<SectiongroupPostSectionsParameter, SectiongroupPostSectionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/sectiongroup-post-sections?view=graph-rest-1.0
        /// </summary>
        public async Task<SectiongroupPostSectionsResponse> SectiongroupPostSectionsAsync(SectiongroupPostSectionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SectiongroupPostSectionsParameter, SectiongroupPostSectionsResponse>(parameter, cancellationToken);
        }
    }
}
