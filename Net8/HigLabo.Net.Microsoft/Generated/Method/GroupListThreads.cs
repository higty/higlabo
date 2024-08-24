using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-threads?view=graph-rest-1.0
    /// </summary>
    public partial class GroupListThreadsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

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
    public partial class GroupListThreadsResponse : RestApiResponse<ConversationThread>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-threads?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-threads?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListThreadsResponse> GroupListThreadsAsync()
        {
            var p = new GroupListThreadsParameter();
            return await this.SendAsync<GroupListThreadsParameter, GroupListThreadsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-threads?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListThreadsResponse> GroupListThreadsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListThreadsParameter();
            return await this.SendAsync<GroupListThreadsParameter, GroupListThreadsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-threads?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListThreadsResponse> GroupListThreadsAsync(GroupListThreadsParameter parameter)
        {
            return await this.SendAsync<GroupListThreadsParameter, GroupListThreadsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-threads?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListThreadsResponse> GroupListThreadsAsync(GroupListThreadsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListThreadsParameter, GroupListThreadsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-threads?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<ConversationThread> GroupListThreadsEnumerateAsync(GroupListThreadsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<GroupListThreadsParameter, GroupListThreadsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<ConversationThread>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
