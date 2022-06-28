
namespace HigLabo.Net.Slack
{
    public class ViewsPublishParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "views.publish";
        public string HttpMethod { get; private set; } = "POST";
        public string User_Id { get; set; } = "";
        public string View { get; set; } = "";
        public string Hash { get; set; } = "";
    }
    public partial class ViewsPublishResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ViewsPublishResponse> ViewsPublishAsync(string user_Id, string view)
        {
            var p = new ViewsPublishParameter();
            p.User_Id = user_Id;
            p.View = view;
            return await this.SendAsync<ViewsPublishParameter, ViewsPublishResponse>(p, CancellationToken.None);
        }
        public async Task<ViewsPublishResponse> ViewsPublishAsync(string user_Id, string view, CancellationToken cancellationToken)
        {
            var p = new ViewsPublishParameter();
            p.User_Id = user_Id;
            p.View = view;
            return await this.SendAsync<ViewsPublishParameter, ViewsPublishResponse>(p, cancellationToken);
        }
        public async Task<ViewsPublishResponse> ViewsPublishAsync(ViewsPublishParameter parameter)
        {
            return await this.SendAsync<ViewsPublishParameter, ViewsPublishResponse>(parameter, CancellationToken.None);
        }
        public async Task<ViewsPublishResponse> ViewsPublishAsync(ViewsPublishParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ViewsPublishParameter, ViewsPublishResponse>(parameter, cancellationToken);
        }
    }
}
