using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListThreadsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Threads: return $"/groups/{Id}/threads";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            ToRecipients,
            CcRecipients,
            Topic,
            HasAttachments,
            LastDeliveredDateTime,
            UniqueSenders,
            Preview,
            IsLocked,
            Posts,
        }
        public enum ApiPath
        {
            Groups_Id_Threads,
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
    public partial class GroupListThreadsResponse : RestApiResponse
    {
        public ConversationThread[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-threads?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListThreadsResponse> GroupListThreadsAsync()
        {
            var p = new GroupListThreadsParameter();
            return await this.SendAsync<GroupListThreadsParameter, GroupListThreadsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-threads?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListThreadsResponse> GroupListThreadsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListThreadsParameter();
            return await this.SendAsync<GroupListThreadsParameter, GroupListThreadsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-threads?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListThreadsResponse> GroupListThreadsAsync(GroupListThreadsParameter parameter)
        {
            return await this.SendAsync<GroupListThreadsParameter, GroupListThreadsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-threads?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListThreadsResponse> GroupListThreadsAsync(GroupListThreadsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListThreadsParameter, GroupListThreadsResponse>(parameter, cancellationToken);
        }
    }
}
