using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-memberof?view=graph-rest-1.0
    /// </summary>
    public partial class GroupListMemberofParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_MemberOf: return $"/groups/{Id}/memberOf";
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
            Groups_Id_MemberOf,
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
    public partial class GroupListMemberofResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-memberof?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListMemberofResponse> GroupListMemberofAsync()
        {
            var p = new GroupListMemberofParameter();
            return await this.SendAsync<GroupListMemberofParameter, GroupListMemberofResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListMemberofResponse> GroupListMemberofAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListMemberofParameter();
            return await this.SendAsync<GroupListMemberofParameter, GroupListMemberofResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListMemberofResponse> GroupListMemberofAsync(GroupListMemberofParameter parameter)
        {
            return await this.SendAsync<GroupListMemberofParameter, GroupListMemberofResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListMemberofResponse> GroupListMemberofAsync(GroupListMemberofParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListMemberofParameter, GroupListMemberofResponse>(parameter, cancellationToken);
        }
    }
}
