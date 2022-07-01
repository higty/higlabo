using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminBarriersCreateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.barriers.create";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Barriered_From_Usergroup_Ids { get; set; }
        public string Primary_Usergroup_Id { get; set; }
        public string Restricted_Subjects { get; set; }
    }
    public partial class AdminBarriersCreateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.barriers.create
        /// </summary>
        public async Task<AdminBarriersCreateResponse> AdminBarriersCreateAsync(string barriered_From_Usergroup_Ids, string primary_Usergroup_Id, string restricted_Subjects)
        {
            var p = new AdminBarriersCreateParameter();
            p.Barriered_From_Usergroup_Ids = barriered_From_Usergroup_Ids;
            p.Primary_Usergroup_Id = primary_Usergroup_Id;
            p.Restricted_Subjects = restricted_Subjects;
            return await this.SendAsync<AdminBarriersCreateParameter, AdminBarriersCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.barriers.create
        /// </summary>
        public async Task<AdminBarriersCreateResponse> AdminBarriersCreateAsync(string barriered_From_Usergroup_Ids, string primary_Usergroup_Id, string restricted_Subjects, CancellationToken cancellationToken)
        {
            var p = new AdminBarriersCreateParameter();
            p.Barriered_From_Usergroup_Ids = barriered_From_Usergroup_Ids;
            p.Primary_Usergroup_Id = primary_Usergroup_Id;
            p.Restricted_Subjects = restricted_Subjects;
            return await this.SendAsync<AdminBarriersCreateParameter, AdminBarriersCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.barriers.create
        /// </summary>
        public async Task<AdminBarriersCreateResponse> AdminBarriersCreateAsync(AdminBarriersCreateParameter parameter)
        {
            return await this.SendAsync<AdminBarriersCreateParameter, AdminBarriersCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.barriers.create
        /// </summary>
        public async Task<AdminBarriersCreateResponse> AdminBarriersCreateAsync(AdminBarriersCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminBarriersCreateParameter, AdminBarriersCreateResponse>(parameter, cancellationToken);
        }
    }
}
