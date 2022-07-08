using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class NotebookPostSectionsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string IdOrUserPrincipalName { get; set; }
            public string GroupsId { get; set; }
            public string NotebooksId { get; set; }
            public string SitesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Onenote_Notebooks_Id_Sections: return $"/me/onenote/notebooks/{Id}/sections";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Notebooks_Id_Sections: return $"/users/{IdOrUserPrincipalName}/onenote/notebooks/{Id}/sections";
                    case ApiPath.Groups_Id_Onenote_Notebooks_Id_Sections: return $"/groups/{GroupsId}/onenote/notebooks/{NotebooksId}/sections";
                    case ApiPath.Sites_Id_Onenote_Notebooks_Id_Sections: return $"/sites/{SitesId}/onenote/notebooks/{NotebooksId}/sections";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Onenote_Notebooks_Id_Sections,
            Users_IdOrUserPrincipalName_Onenote_Notebooks_Id_Sections,
            Groups_Id_Onenote_Notebooks_Id_Sections,
            Sites_Id_Onenote_Notebooks_Id_Sections,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
        public Page[]? Pages { get; set; }
        public Notebook? ParentNotebook { get; set; }
        public SectionGroup? ParentSectionGroup { get; set; }
    }
    public partial class NotebookPostSectionsResponse : RestApiResponse
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
        public Page[]? Pages { get; set; }
        public Notebook? ParentNotebook { get; set; }
        public SectionGroup? ParentSectionGroup { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-post-sections?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookPostSectionsResponse> NotebookPostSectionsAsync()
        {
            var p = new NotebookPostSectionsParameter();
            return await this.SendAsync<NotebookPostSectionsParameter, NotebookPostSectionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-post-sections?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookPostSectionsResponse> NotebookPostSectionsAsync(CancellationToken cancellationToken)
        {
            var p = new NotebookPostSectionsParameter();
            return await this.SendAsync<NotebookPostSectionsParameter, NotebookPostSectionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-post-sections?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookPostSectionsResponse> NotebookPostSectionsAsync(NotebookPostSectionsParameter parameter)
        {
            return await this.SendAsync<NotebookPostSectionsParameter, NotebookPostSectionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-post-sections?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookPostSectionsResponse> NotebookPostSectionsAsync(NotebookPostSectionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<NotebookPostSectionsParameter, NotebookPostSectionsResponse>(parameter, cancellationToken);
        }
    }
}
