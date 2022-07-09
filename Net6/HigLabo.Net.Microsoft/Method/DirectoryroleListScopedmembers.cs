using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryroleListScopedmembersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? RoleId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Directoryroles_RoleId_ScopedMembers: return $"/directoryroles/{RoleId}/scopedMembers";
                    case ApiPath.Directoryroles_RoleTemplateId: return $"/directoryroles/roleTemplateId";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Directoryroles_RoleId_ScopedMembers,
            Directoryroles_RoleTemplateId,
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
    public partial class DirectoryroleListScopedmembersResponse : RestApiResponse
    {
        public ScopedRoleMembership[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-list-scopedmembers?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleListScopedmembersResponse> DirectoryroleListScopedmembersAsync()
        {
            var p = new DirectoryroleListScopedmembersParameter();
            return await this.SendAsync<DirectoryroleListScopedmembersParameter, DirectoryroleListScopedmembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-list-scopedmembers?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleListScopedmembersResponse> DirectoryroleListScopedmembersAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryroleListScopedmembersParameter();
            return await this.SendAsync<DirectoryroleListScopedmembersParameter, DirectoryroleListScopedmembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-list-scopedmembers?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleListScopedmembersResponse> DirectoryroleListScopedmembersAsync(DirectoryroleListScopedmembersParameter parameter)
        {
            return await this.SendAsync<DirectoryroleListScopedmembersParameter, DirectoryroleListScopedmembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-list-scopedmembers?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleListScopedmembersResponse> DirectoryroleListScopedmembersAsync(DirectoryroleListScopedmembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryroleListScopedmembersParameter, DirectoryroleListScopedmembersResponse>(parameter, cancellationToken);
        }
    }
}
