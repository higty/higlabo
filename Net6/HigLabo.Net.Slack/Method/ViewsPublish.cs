
namespace HigLabo.Net.Slack
{
    public partial class ViewsPublishParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "views.publish";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string User_Id { get; set; }
        public string View { get; set; }
        public string Hash { get; set; }
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
