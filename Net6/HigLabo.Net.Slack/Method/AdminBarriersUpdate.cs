
namespace HigLabo.Net.Slack
{
    public class AdminBarriersUpdateParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.barriers.update";
        public string HttpMethod { get; private set; } = "GET";
        public string Barrier_Id { get; set; } = "";
        public string Barriered_From_Usergroup_Ids { get; set; } = "";
        public string Primary_Usergroup_Id { get; set; } = "";
        public string Restricted_Subjects { get; set; } = "";
    }
    public partial class AdminBarriersUpdateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminBarriersUpdateResponse> AdminBarriersUpdateAsync(string barrier_Id, string barriered_From_Usergroup_Ids, string primary_Usergroup_Id, string restricted_Subjects)
        {
            var p = new AdminBarriersUpdateParameter();
            p.Barrier_Id = barrier_Id;
            p.Barriered_From_Usergroup_Ids = barriered_From_Usergroup_Ids;
            p.Primary_Usergroup_Id = primary_Usergroup_Id;
            p.Restricted_Subjects = restricted_Subjects;
            return await this.SendAsync<AdminBarriersUpdateParameter, AdminBarriersUpdateResponse>(p, CancellationToken.None);
        }
        public async Task<AdminBarriersUpdateResponse> AdminBarriersUpdateAsync(string barrier_Id, string barriered_From_Usergroup_Ids, string primary_Usergroup_Id, string restricted_Subjects, CancellationToken cancellationToken)
        {
            var p = new AdminBarriersUpdateParameter();
            p.Barrier_Id = barrier_Id;
            p.Barriered_From_Usergroup_Ids = barriered_From_Usergroup_Ids;
            p.Primary_Usergroup_Id = primary_Usergroup_Id;
            p.Restricted_Subjects = restricted_Subjects;
            return await this.SendAsync<AdminBarriersUpdateParameter, AdminBarriersUpdateResponse>(p, cancellationToken);
        }
        public async Task<AdminBarriersUpdateResponse> AdminBarriersUpdateAsync(AdminBarriersUpdateParameter parameter)
        {
            return await this.SendAsync<AdminBarriersUpdateParameter, AdminBarriersUpdateResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminBarriersUpdateResponse> AdminBarriersUpdateAsync(AdminBarriersUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminBarriersUpdateParameter, AdminBarriersUpdateResponse>(parameter, cancellationToken);
        }
    }
}
