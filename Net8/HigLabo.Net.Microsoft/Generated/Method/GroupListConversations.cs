using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-conversations?view=graph-rest-1.0
    /// </summary>
    public partial class GroupListConversationsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Conversations: return $"/groups/{Id}/conversations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Id_Conversations,
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
    public partial class GroupListConversationsResponse : RestApiResponse<Conversation>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-conversations?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-conversations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListConversationsResponse> GroupListConversationsAsync()
        {
            var p = new GroupListConversationsParameter();
            return await this.SendAsync<GroupListConversationsParameter, GroupListConversationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-conversations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListConversationsResponse> GroupListConversationsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListConversationsParameter();
            return await this.SendAsync<GroupListConversationsParameter, GroupListConversationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-conversations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListConversationsResponse> GroupListConversationsAsync(GroupListConversationsParameter parameter)
        {
            return await this.SendAsync<GroupListConversationsParameter, GroupListConversationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-conversations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupListConversationsResponse> GroupListConversationsAsync(GroupListConversationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListConversationsParameter, GroupListConversationsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-conversations?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Conversation> GroupListConversationsEnumerateAsync(GroupListConversationsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<GroupListConversationsParameter, GroupListConversationsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Conversation>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
