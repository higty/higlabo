
namespace HigLabo.Net.Slack
{
    public partial class AdminUsersUnsupportedVersionsExportParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.users.unsupportedVersions.export";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public int? Date_End_Of_Support { get; set; }
        public int? Date_Sessions_Started { get; set; }
    }
    public partial class AdminUsersUnsupportedVersionsExportResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.users.unsupportedVersions.export
        /// </summary>
        public async Task<AdminUsersUnsupportedVersionsExportResponse> AdminUsersUnsupportedVersionsExportAsync()
        {
            var p = new AdminUsersUnsupportedVersionsExportParameter();
            return await this.SendAsync<AdminUsersUnsupportedVersionsExportParameter, AdminUsersUnsupportedVersionsExportResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.unsupportedVersions.export
        /// </summary>
        public async Task<AdminUsersUnsupportedVersionsExportResponse> AdminUsersUnsupportedVersionsExportAsync(CancellationToken cancellationToken)
        {
            var p = new AdminUsersUnsupportedVersionsExportParameter();
            return await this.SendAsync<AdminUsersUnsupportedVersionsExportParameter, AdminUsersUnsupportedVersionsExportResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.unsupportedVersions.export
        /// </summary>
        public async Task<AdminUsersUnsupportedVersionsExportResponse> AdminUsersUnsupportedVersionsExportAsync(AdminUsersUnsupportedVersionsExportParameter parameter)
        {
            return await this.SendAsync<AdminUsersUnsupportedVersionsExportParameter, AdminUsersUnsupportedVersionsExportResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.unsupportedVersions.export
        /// </summary>
        public async Task<AdminUsersUnsupportedVersionsExportResponse> AdminUsersUnsupportedVersionsExportAsync(AdminUsersUnsupportedVersionsExportParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersUnsupportedVersionsExportParameter, AdminUsersUnsupportedVersionsExportResponse>(parameter, cancellationToken);
        }
    }
}
