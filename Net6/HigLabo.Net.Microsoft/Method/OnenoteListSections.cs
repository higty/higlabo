using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OnenoteListSectionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string IdOrUserPrincipalName { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Onenote_Sections: return $"/me/onenote/sections";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Sections: return $"/users/{IdOrUserPrincipalName}/onenote/sections";
                    case ApiPath.Groups_Id_Onenote_Sections: return $"/groups/{Id}/onenote/sections";
                    case ApiPath.Sites_Id_Onenote_Sections: return $"/sites/{Id}/onenote/sections";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedBy,
            CreatedDateTime,
            Id,
            IsDefault,
            LastModifiedBy,
            LastModifiedDateTime,
            Links,
            DisplayName,
            PagesUrl,
            Self,
            Pages,
            ParentNotebook,
            ParentSectionGroup,
        }
        public enum ApiPath
        {
            Me_Onenote_Sections,
            Users_IdOrUserPrincipalName_Onenote_Sections,
            Groups_Id_Onenote_Sections,
            Sites_Id_Onenote_Sections,
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
    public partial class OnenoteListSectionsResponse : RestApiResponse
    {
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
