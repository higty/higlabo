using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListRejectedsendersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_RejectedSenders: return $"/groups/{Id}/rejectedSenders";
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
            Groups_Id_RejectedSenders,
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
    public partial class GroupListRejectedsendersResponse : RestApiResponse
    {
        public DirectoryObject[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListRejectedsendersResponse> GroupListRejectedsendersAsync()
        {
            var p = new GroupListRejectedsendersParameter();
            return await this.SendAsync<GroupListRejectedsendersParameter, GroupListRejectedsendersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListRejectedsendersResponse> GroupListRejectedsendersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListRejectedsendersParameter();
            return await this.SendAsync<GroupListRejectedsendersParameter, GroupListRejectedsendersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListRejectedsendersResponse> GroupListRejectedsendersAsync(GroupListRejectedsendersParameter parameter)
        {
            return await this.SendAsync<GroupListRejectedsendersParameter, GroupListRejectedsendersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-rejectedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListRejectedsendersResponse> GroupListRejectedsendersAsync(GroupListRejectedsendersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListRejectedsendersParameter, GroupListRejectedsendersResponse>(parameter, cancellationToken);
        }
    }
}
