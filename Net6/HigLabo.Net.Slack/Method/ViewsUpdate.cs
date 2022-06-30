
namespace HigLabo.Net.Slack
{
    public partial class ViewsUpdateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "views.update";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string View { get; set; }
        public string External_Id { get; set; }
        public string View_Id { get; set; }
        public string Hash { get; set; }
    }
    public partial class ViewsUpdateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ViewsUpdateResponse> ViewsUpdateAsync(string view)
        {
            var p = new ViewsUpdateParameter();
            p.View = view;
            return await this.SendAsync<ViewsUpdateParameter, ViewsUpdateResponse>(p, CancellationToken.None);
        }
        public async Task<ViewsUpdateResponse> ViewsUpdateAsync(string view, CancellationToken cancellationToken)
        {
            var p = new ViewsUpdateParameter();
            p.View = view;
            return await this.SendAsync<ViewsUpdateParameter, ViewsUpdateResponse>(p, cancellationToken);
        }
        public async Task<ViewsUpdateResponse> ViewsUpdateAsync(ViewsUpdateParameter parameter)
        {
            return await this.SendAsync<ViewsUpdateParameter, ViewsUpdateResponse>(parameter, CancellationToken.None);
        }
        public async Task<ViewsUpdateResponse> ViewsUpdateAsync(ViewsUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ViewsUpdateParameter, ViewsUpdateResponse>(parameter, cancellationToken);
        }
    }
}
