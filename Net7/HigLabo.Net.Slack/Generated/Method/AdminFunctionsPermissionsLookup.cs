using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.functions.permissions.lookup
    /// </summary>
    public partial class AdminFunctionsPermissionsLookupParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.functions.permissions.lookup";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Function_Ids { get; set; }
    }
    public partial class AdminFunctionsPermissionsLookupResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.functions.permissions.lookup
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.functions.permissions.lookup
        /// </summary>
        public async ValueTask<AdminFunctionsPermissionsLookupResponse> AdminFunctionsPermissionsLookupAsync(string? function_Ids)
        {
            var p = new AdminFunctionsPermissionsLookupParameter();
            p.Function_Ids = function_Ids;
            return await this.SendAsync<AdminFunctionsPermissionsLookupParameter, AdminFunctionsPermissionsLookupResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.functions.permissions.lookup
        /// </summary>
        public async ValueTask<AdminFunctionsPermissionsLookupResponse> AdminFunctionsPermissionsLookupAsync(string? function_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminFunctionsPermissionsLookupParameter();
            p.Function_Ids = function_Ids;
            return await this.SendAsync<AdminFunctionsPermissionsLookupParameter, AdminFunctionsPermissionsLookupResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.functions.permissions.lookup
        /// </summary>
        public async ValueTask<AdminFunctionsPermissionsLookupResponse> AdminFunctionsPermissionsLookupAsync(AdminFunctionsPermissionsLookupParameter parameter)
        {
            return await this.SendAsync<AdminFunctionsPermissionsLookupParameter, AdminFunctionsPermissionsLookupResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.functions.permissions.lookup
        /// </summary>
        public async ValueTask<AdminFunctionsPermissionsLookupResponse> AdminFunctionsPermissionsLookupAsync(AdminFunctionsPermissionsLookupParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminFunctionsPermissionsLookupParameter, AdminFunctionsPermissionsLookupResponse>(parameter, cancellationToken);
        }
    }
}
