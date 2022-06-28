
namespace HigLabo.Net.Slack
{
    public class AdminUsersUnsupportedVersionsExportParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.users.unsupportedVersions.export";
        public string HttpMethod { get; private set; } = "GET";
        public int? Date_End_Of_Support { get; set; }
        public int? Date_Sessions_Started { get; set; }
    }
    public partial class AdminUsersUnsupportedVersionsExportResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsersUnsupportedVersionsExportResponse> AdminUsersUnsupportedVersionsExportAsync()
        {
            var p = new AdminUsersUnsupportedVersionsExportParameter();
            return await this.SendAsync<AdminUsersUnsupportedVersionsExportParameter, AdminUsersUnsupportedVersionsExportResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsersUnsupportedVersionsExportResponse> AdminUsersUnsupportedVersionsExportAsync(CancellationToken cancellationToken)
        {
            var p = new AdminUsersUnsupportedVersionsExportParameter();
            return await this.SendAsync<AdminUsersUnsupportedVersionsExportParameter, AdminUsersUnsupportedVersionsExportResponse>(p, cancellationToken);
        }
        public async Task<AdminUsersUnsupportedVersionsExportResponse> AdminUsersUnsupportedVersionsExportAsync(AdminUsersUnsupportedVersionsExportParameter parameter)
        {
            return await this.SendAsync<AdminUsersUnsupportedVersionsExportParameter, AdminUsersUnsupportedVersionsExportResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsersUnsupportedVersionsExportResponse> AdminUsersUnsupportedVersionsExportAsync(AdminUsersUnsupportedVersionsExportParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersUnsupportedVersionsExportParameter, AdminUsersUnsupportedVersionsExportResponse>(parameter, cancellationToken);
        }
    }
}
