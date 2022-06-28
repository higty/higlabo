
namespace HigLabo.Net.Slack
{
    public class ViewsPushParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "views.push";
        public string HttpMethod { get; private set; } = "POST";
        public string Trigger_Id { get; set; } = "";
        public string View { get; set; } = "";
    }
    public partial class ViewsPushResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ViewsPushResponse> ViewsPushAsync(string trigger_Id, string view)
        {
            var p = new ViewsPushParameter();
            p.Trigger_Id = trigger_Id;
            p.View = view;
            return await this.SendAsync<ViewsPushParameter, ViewsPushResponse>(p, CancellationToken.None);
        }
        public async Task<ViewsPushResponse> ViewsPushAsync(string trigger_Id, string view, CancellationToken cancellationToken)
        {
            var p = new ViewsPushParameter();
            p.Trigger_Id = trigger_Id;
            p.View = view;
            return await this.SendAsync<ViewsPushParameter, ViewsPushResponse>(p, cancellationToken);
        }
        public async Task<ViewsPushResponse> ViewsPushAsync(ViewsPushParameter parameter)
        {
            return await this.SendAsync<ViewsPushParameter, ViewsPushResponse>(parameter, CancellationToken.None);
        }
        public async Task<ViewsPushResponse> ViewsPushAsync(ViewsPushParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ViewsPushParameter, ViewsPushResponse>(parameter, cancellationToken);
        }
    }
}
