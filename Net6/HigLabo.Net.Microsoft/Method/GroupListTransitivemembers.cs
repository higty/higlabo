using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListTransitivemembersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_TransitiveMembers: return $"/groups/{Id}/transitiveMembers";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DeletedDateTime,
            Id,
        }
        public enum ApiPath
        {
            Groups_Id_TransitiveMembers,
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
    public partial class GroupListTransitivemembersResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-transitivemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListTransitivemembersResponse> GroupListTransitivemembersAsync()
        {
            var p = new GroupListTransitivemembersParameter();
            return await this.SendAsync<GroupListTransitivemembersParameter, GroupListTransitivemembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-transitivemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListTransitivemembersResponse> GroupListTransitivemembersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListTransitivemembersParameter();
            return await this.SendAsync<GroupListTransitivemembersParameter, GroupListTransitivemembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-transitivemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListTransitivemembersResponse> GroupListTransitivemembersAsync(GroupListTransitivemembersParameter parameter)
        {
            return await this.SendAsync<GroupListTransitivemembersParameter, GroupListTransitivemembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-transitivemembers?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListTransitivemembersResponse> GroupListTransitivemembersAsync(GroupListTransitivemembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListTransitivemembersParameter, GroupListTransitivemembersResponse>(parameter, cancellationToken);
        }
    }
}
