using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListTransitivememberofParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_TransitiveMemberOf: return $"/groups/{Id}/transitiveMemberOf";
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
            Groups_Id_TransitiveMemberOf,
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
    public partial class GroupListTransitivememberofResponse : RestApiResponse
    {
        public DirectoryObject[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListTransitivememberofResponse> GroupListTransitivememberofAsync()
        {
            var p = new GroupListTransitivememberofParameter();
            return await this.SendAsync<GroupListTransitivememberofParameter, GroupListTransitivememberofResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListTransitivememberofResponse> GroupListTransitivememberofAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListTransitivememberofParameter();
            return await this.SendAsync<GroupListTransitivememberofParameter, GroupListTransitivememberofResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListTransitivememberofResponse> GroupListTransitivememberofAsync(GroupListTransitivememberofParameter parameter)
        {
            return await this.SendAsync<GroupListTransitivememberofParameter, GroupListTransitivememberofResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-transitivememberof?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListTransitivememberofResponse> GroupListTransitivememberofAsync(GroupListTransitivememberofParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListTransitivememberofParameter, GroupListTransitivememberofResponse>(parameter, cancellationToken);
        }
    }
}
