
namespace HigLabo.Net.Slack
{
    public partial class AdminBarriersDeleteParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.barriers.delete";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Barrier_Id { get; set; }
    }
    public partial class AdminBarriersDeleteResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminBarriersDeleteResponse> AdminBarriersDeleteAsync(string barrier_Id)
        {
            var p = new AdminBarriersDeleteParameter();
            p.Barrier_Id = barrier_Id;
            return await this.SendAsync<AdminBarriersDeleteParameter, AdminBarriersDeleteResponse>(p, CancellationToken.None);
        }
        public async Task<AdminBarriersDeleteResponse> AdminBarriersDeleteAsync(string barrier_Id, CancellationToken cancellationToken)
        {
            var p = new AdminBarriersDeleteParameter();
            p.Barrier_Id = barrier_Id;
            return await this.SendAsync<AdminBarriersDeleteParameter, AdminBarriersDeleteResponse>(p, cancellationToken);
        }
        public async Task<AdminBarriersDeleteResponse> AdminBarriersDeleteAsync(AdminBarriersDeleteParameter parameter)
        {
            return await this.SendAsync<AdminBarriersDeleteParameter, AdminBarriersDeleteResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminBarriersDeleteResponse> AdminBarriersDeleteAsync(AdminBarriersDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminBarriersDeleteParameter, AdminBarriersDeleteResponse>(parameter, cancellationToken);
        }
    }
}
