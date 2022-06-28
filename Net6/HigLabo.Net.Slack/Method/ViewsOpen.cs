
namespace HigLabo.Net.Slack
{
    public class ViewsOpenParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "views.open";
        public string HttpMethod { get; private set; } = "POST";
        public string Trigger_Id { get; set; } = "";
        public string View { get; set; } = "";
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
