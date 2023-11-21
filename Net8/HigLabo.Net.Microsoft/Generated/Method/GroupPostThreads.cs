using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-post-threads?view=graph-rest-1.0
    /// </summary>
    public partial class GroupPostThreadsParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public Recipient[]? CcRecipients { get; set; }
        public bool? HasAttachments { get; set; }
        public string? Id { get; set; }
        public bool? IsLocked { get; set; }
        public DateTimeOffset? LastDeliveredDateTime { get; set; }
        public string? Preview { get; set; }
        public string? Topic { get; set; }
        public Recipient[]? ToRecipients { get; set; }
        public String[]? UniqueSenders { get; set; }
        public Post[]? Posts { get; set; }
    }
    public partial class GroupPostThreadsResponse : RestApiResponse
    {
        public Recipient[]? CcRecipients { get; set; }
        public bool? HasAttachments { get; set; }
        public string? Id { get; set; }
        public bool? IsLocked { get; set; }
        public DateTimeOffset? LastDeliveredDateTime { get; set; }
        public string? Preview { get; set; }
        public string? Topic { get; set; }
        public Recipient[]? ToRecipients { get; set; }
        public String[]? UniqueSenders { get; set; }
        public Post[]? Posts { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-post-threads?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-post-threads?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupPostThreadsResponse> GroupPostThreadsAsync()
        {
            var p = new GroupPostThreadsParameter();
            return await this.SendAsync<GroupPostThreadsParameter, GroupPostThreadsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-post-threads?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupPostThreadsResponse> GroupPostThreadsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupPostThreadsParameter();
            return await this.SendAsync<GroupPostThreadsParameter, GroupPostThreadsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-post-threads?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupPostThreadsResponse> GroupPostThreadsAsync(GroupPostThreadsParameter parameter)
        {
            return await this.SendAsync<GroupPostThreadsParameter, GroupPostThreadsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-post-threads?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupPostThreadsResponse> GroupPostThreadsAsync(GroupPostThreadsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupPostThreadsParameter, GroupPostThreadsResponse>(parameter, cancellationToken);
        }
    }
}
