﻿
namespace HigLabo.Net.Slack
{
    public partial class AdminUsersSessionResetBulkParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.users.session.resetBulk";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string User_Ids { get; set; }
        public bool? Mobile_Only { get; set; }
        public bool? Web_Only { get; set; }
    }
    public partial class AdminUsersSessionResetBulkResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsersSessionResetBulkResponse> AdminUsersSessionResetBulkAsync(string user_Ids)
        {
            var p = new AdminUsersSessionResetBulkParameter();
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminUsersSessionResetBulkParameter, AdminUsersSessionResetBulkResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsersSessionResetBulkResponse> AdminUsersSessionResetBulkAsync(string user_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSessionResetBulkParameter();
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminUsersSessionResetBulkParameter, AdminUsersSessionResetBulkResponse>(p, cancellationToken);
        }
        public async Task<AdminUsersSessionResetBulkResponse> AdminUsersSessionResetBulkAsync(AdminUsersSessionResetBulkParameter parameter)
        {
            return await this.SendAsync<AdminUsersSessionResetBulkParameter, AdminUsersSessionResetBulkResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsersSessionResetBulkResponse> AdminUsersSessionResetBulkAsync(AdminUsersSessionResetBulkParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSessionResetBulkParameter, AdminUsersSessionResetBulkResponse>(parameter, cancellationToken);
        }
    }
}