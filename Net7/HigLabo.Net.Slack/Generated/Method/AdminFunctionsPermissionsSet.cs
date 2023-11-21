using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.functions.permissions.set
    /// </summary>
    public partial class AdminFunctionsPermissionsSetParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.functions.permissions.set";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Function_Id { get; set; }
        public string? Visibility { get; set; }
        public string? User_Ids { get; set; }
    }
    public partial class AdminFunctionsPermissionsSetResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.functions.permissions.set
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.functions.permissions.set
        /// </summary>
        public async ValueTask<AdminFunctionsPermissionsSetResponse> AdminFunctionsPermissionsSetAsync(string? function_Id, string? visibility)
        {
            var p = new AdminFunctionsPermissionsSetParameter();
            p.Function_Id = function_Id;
            p.Visibility = visibility;
            return await this.SendAsync<AdminFunctionsPermissionsSetParameter, AdminFunctionsPermissionsSetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.functions.permissions.set
        /// </summary>
        public async ValueTask<AdminFunctionsPermissionsSetResponse> AdminFunctionsPermissionsSetAsync(string? function_Id, string? visibility, CancellationToken cancellationToken)
        {
            var p = new AdminFunctionsPermissionsSetParameter();
            p.Function_Id = function_Id;
            p.Visibility = visibility;
            return await this.SendAsync<AdminFunctionsPermissionsSetParameter, AdminFunctionsPermissionsSetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.functions.permissions.set
        /// </summary>
        public async ValueTask<AdminFunctionsPermissionsSetResponse> AdminFunctionsPermissionsSetAsync(AdminFunctionsPermissionsSetParameter parameter)
        {
            return await this.SendAsync<AdminFunctionsPermissionsSetParameter, AdminFunctionsPermissionsSetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.functions.permissions.set
        /// </summary>
        public async ValueTask<AdminFunctionsPermissionsSetResponse> AdminFunctionsPermissionsSetAsync(AdminFunctionsPermissionsSetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminFunctionsPermissionsSetParameter, AdminFunctionsPermissionsSetResponse>(parameter, cancellationToken);
        }
    }
}
