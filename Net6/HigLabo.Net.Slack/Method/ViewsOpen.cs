
namespace HigLabo.Net.Slack
{
    public partial class ViewsOpenParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "views.open";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Trigger_Id { get; set; }
        public string View { get; set; }
    }
    public partial class ViewsOpenResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ViewsOpenResponse> ViewsOpenAsync(string trigger_Id, string view)
        {
            var p = new ViewsOpenParameter();
            p.Trigger_Id = trigger_Id;
            p.View = view;
            return await this.SendAsync<ViewsOpenParameter, ViewsOpenResponse>(p, CancellationToken.None);
        }
        public async Task<ViewsOpenResponse> ViewsOpenAsync(string trigger_Id, string view, CancellationToken cancellationToken)
        {
            var p = new ViewsOpenParameter();
            p.Trigger_Id = trigger_Id;
            p.View = view;
            return await this.SendAsync<ViewsOpenParameter, ViewsOpenResponse>(p, cancellationToken);
        }
        public async Task<ViewsOpenResponse> ViewsOpenAsync(ViewsOpenParameter parameter)
        {
            return await this.SendAsync<ViewsOpenParameter, ViewsOpenResponse>(parameter, CancellationToken.None);
        }
        public async Task<ViewsOpenResponse> ViewsOpenAsync(ViewsOpenParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ViewsOpenParameter, ViewsOpenResponse>(parameter, cancellationToken);
        }
    }
}
