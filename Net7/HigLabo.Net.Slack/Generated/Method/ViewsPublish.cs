using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class ViewsPublishParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "views.publish";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? User_Id { get; set; }
        public string? View { get; set; }
        public string? Hash { get; set; }
    }
    public partial class ViewsPublishResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/views.publish
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/views.publish
        /// </summary>
        public async ValueTask<ViewsPublishResponse> ViewsPublishAsync(string? user_Id, string? view)
        {
            var p = new ViewsPublishParameter();
            p.User_Id = user_Id;
            p.View = view;
            return await this.SendAsync<ViewsPublishParameter, ViewsPublishResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/views.publish
        /// </summary>
        public async ValueTask<ViewsPublishResponse> ViewsPublishAsync(string? user_Id, string? view, CancellationToken cancellationToken)
        {
            var p = new ViewsPublishParameter();
            p.User_Id = user_Id;
            p.View = view;
            return await this.SendAsync<ViewsPublishParameter, ViewsPublishResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/views.publish
        /// </summary>
        public async ValueTask<ViewsPublishResponse> ViewsPublishAsync(ViewsPublishParameter parameter)
        {
            return await this.SendAsync<ViewsPublishParameter, ViewsPublishResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/views.publish
        /// </summary>
        public async ValueTask<ViewsPublishResponse> ViewsPublishAsync(ViewsPublishParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ViewsPublishParameter, ViewsPublishResponse>(parameter, cancellationToken);
        }
    }
}
