using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.lookup
    /// </summary>
    public partial class AdminConversationsLookupParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.conversations.lookup";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public int? Last_Message_Activity_Before { get; set; }
        public string? Team_Ids { get; set; }
        public string? Cursor { get; set; }
        string? IRestApiPagingParameter.NextPageToken
        {
            get
            {
                return this.Cursor;
            }
            set
            {
                this.Cursor = value;
            }
        }
        public int? Limit { get; set; }
        public int? Max_Member_Count { get; set; }
    }
    public partial class AdminConversationsLookupResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.conversations.lookup
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.lookup
        /// </summary>
        public async ValueTask<AdminConversationsLookupResponse> AdminConversationsLookupAsync(int? last_Message_Activity_Before, string? team_Ids)
        {
            var p = new AdminConversationsLookupParameter();
            p.Last_Message_Activity_Before = last_Message_Activity_Before;
            p.Team_Ids = team_Ids;
            return await this.SendAsync<AdminConversationsLookupParameter, AdminConversationsLookupResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.lookup
        /// </summary>
        public async ValueTask<AdminConversationsLookupResponse> AdminConversationsLookupAsync(int? last_Message_Activity_Before, string? team_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsLookupParameter();
            p.Last_Message_Activity_Before = last_Message_Activity_Before;
            p.Team_Ids = team_Ids;
            return await this.SendAsync<AdminConversationsLookupParameter, AdminConversationsLookupResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.lookup
        /// </summary>
        public async ValueTask<AdminConversationsLookupResponse> AdminConversationsLookupAsync(AdminConversationsLookupParameter parameter)
        {
            return await this.SendAsync<AdminConversationsLookupParameter, AdminConversationsLookupResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.lookup
        /// </summary>
        public async ValueTask<AdminConversationsLookupResponse> AdminConversationsLookupAsync(AdminConversationsLookupParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminConversationsLookupParameter, AdminConversationsLookupResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.lookup
        /// </summary>
        public async Task<List<AdminConversationsLookupResponse>> AdminConversationsLookupAsync(int? last_Message_Activity_Before, PagingContext<AdminConversationsLookupResponse> context, string? team_Ids)
        {
            var p = new AdminConversationsLookupParameter();
            p.Last_Message_Activity_Before = last_Message_Activity_Before;
            p.Team_Ids = team_Ids;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.lookup
        /// </summary>
        public async Task<List<AdminConversationsLookupResponse>> AdminConversationsLookupAsync(int? last_Message_Activity_Before, PagingContext<AdminConversationsLookupResponse> context, string? team_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminConversationsLookupParameter();
            p.Last_Message_Activity_Before = last_Message_Activity_Before;
            p.Team_Ids = team_Ids;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.lookup
        /// </summary>
        public async ValueTask<List<AdminConversationsLookupResponse>> AdminConversationsLookupAsync(AdminConversationsLookupParameter parameter, PagingContext<AdminConversationsLookupResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.conversations.lookup
        /// </summary>
        public async ValueTask<List<AdminConversationsLookupResponse>> AdminConversationsLookupAsync(AdminConversationsLookupParameter parameter, PagingContext<AdminConversationsLookupResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
