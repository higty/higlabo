using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class ViewsUpdateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "views.update";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? View { get; set; }
        public string? External_Id { get; set; }
        public string? View_Id { get; set; }
        public string? Hash { get; set; }
    }
    public partial class ViewsUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/views.update
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/views.update
        /// </summary>
        public async ValueTask<ViewsUpdateResponse> ViewsUpdateAsync(string? view)
        {
            var p = new ViewsUpdateParameter();
            p.View = view;
            return await this.SendAsync<ViewsUpdateParameter, ViewsUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/views.update
        /// </summary>
        public async ValueTask<ViewsUpdateResponse> ViewsUpdateAsync(string? view, CancellationToken cancellationToken)
        {
            var p = new ViewsUpdateParameter();
            p.View = view;
            return await this.SendAsync<ViewsUpdateParameter, ViewsUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/views.update
        /// </summary>
        public async ValueTask<ViewsUpdateResponse> ViewsUpdateAsync(ViewsUpdateParameter parameter)
        {
            return await this.SendAsync<ViewsUpdateParameter, ViewsUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/views.update
        /// </summary>
        public async ValueTask<ViewsUpdateResponse> ViewsUpdateAsync(ViewsUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ViewsUpdateParameter, ViewsUpdateResponse>(parameter, cancellationToken);
        }
    }
}
