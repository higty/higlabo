using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OnenoteListSectionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Onenote_Sections,
            Users_IdOrUserPrincipalName_Onenote_Sections,
            Groups_Id_Onenote_Sections,
            Sites_Id_Onenote_Sections,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Onenote_Sections: return $"/me/onenote/sections";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Sections: return $"/users/{IdOrUserPrincipalName}/onenote/sections";
                    case ApiPath.Groups_Id_Onenote_Sections: return $"/groups/{Id}/onenote/sections";
                    case ApiPath.Sites_Id_Onenote_Sections: return $"/sites/{Id}/onenote/sections";
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
        public string IdOrUserPrincipalName { get; set; }
        public string Id { get; set; }
    }
    public partial class OnenoteListSectionsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/onenote-list-sections?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenoteListSectionsResponse> OnenoteListSectionsAsync()
        {
            var p = new OnenoteListSectionsParameter();
            return await this.SendAsync<OnenoteListSectionsParameter, OnenoteListSectionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-list-sections?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenoteListSectionsResponse> OnenoteListSectionsAsync(CancellationToken cancellationToken)
        {
            var p = new OnenoteListSectionsParameter();
            return await this.SendAsync<OnenoteListSectionsParameter, OnenoteListSectionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-list-sections?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenoteListSectionsResponse> OnenoteListSectionsAsync(OnenoteListSectionsParameter parameter)
        {
            return await this.SendAsync<OnenoteListSectionsParameter, OnenoteListSectionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onenote-list-sections?view=graph-rest-1.0
        /// </summary>
        public async Task<OnenoteListSectionsResponse> OnenoteListSectionsAsync(OnenoteListSectionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OnenoteListSectionsParameter, OnenoteListSectionsResponse>(parameter, cancellationToken);
        }
    }
}
