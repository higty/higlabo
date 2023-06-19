using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminBarriersUpdateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.barriers.update";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Barrier_Id { get; set; }
        public string? Barriered_From_Usergroup_Ids { get; set; }
        public string? Primary_Usergroup_Id { get; set; }
        public string? Restricted_Subjects { get; set; }
    }
    public partial class AdminBarriersUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.barriers.update
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.barriers.update
        /// </summary>
        public async ValueTask<AdminBarriersUpdateResponse> AdminBarriersUpdateAsync(string? barrier_Id, string? barriered_From_Usergroup_Ids, string? primary_Usergroup_Id, string? restricted_Subjects)
        {
            var p = new AdminBarriersUpdateParameter();
            p.Barrier_Id = barrier_Id;
            p.Barriered_From_Usergroup_Ids = barriered_From_Usergroup_Ids;
            p.Primary_Usergroup_Id = primary_Usergroup_Id;
            p.Restricted_Subjects = restricted_Subjects;
            return await this.SendAsync<AdminBarriersUpdateParameter, AdminBarriersUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.barriers.update
        /// </summary>
        public async ValueTask<AdminBarriersUpdateResponse> AdminBarriersUpdateAsync(string? barrier_Id, string? barriered_From_Usergroup_Ids, string? primary_Usergroup_Id, string? restricted_Subjects, CancellationToken cancellationToken)
        {
            var p = new AdminBarriersUpdateParameter();
            p.Barrier_Id = barrier_Id;
            p.Barriered_From_Usergroup_Ids = barriered_From_Usergroup_Ids;
            p.Primary_Usergroup_Id = primary_Usergroup_Id;
            p.Restricted_Subjects = restricted_Subjects;
            return await this.SendAsync<AdminBarriersUpdateParameter, AdminBarriersUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.barriers.update
        /// </summary>
        public async ValueTask<AdminBarriersUpdateResponse> AdminBarriersUpdateAsync(AdminBarriersUpdateParameter parameter)
        {
            return await this.SendAsync<AdminBarriersUpdateParameter, AdminBarriersUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.barriers.update
        /// </summary>
        public async ValueTask<AdminBarriersUpdateResponse> AdminBarriersUpdateAsync(AdminBarriersUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminBarriersUpdateParameter, AdminBarriersUpdateResponse>(parameter, cancellationToken);
        }
    }
}
