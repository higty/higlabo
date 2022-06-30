
namespace HigLabo.Net.Slack
{
    public partial class FilesRemoteListParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "files.remote.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Channel { get; set; }
        public string Cursor { get; set; }
        string IRestApiPagingParameter.NextPageToken { get; set; }
        public int? Limit { get; set; }
        public string Ts_From { get; set; }
        public string Ts_To { get; set; }
    }
    public partial class FilesRemoteListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/files.remote.list
        /// </summary>
        public async Task<FilesRemoteListResponse> FilesRemoteListAsync()
        {
            var p = new FilesRemoteListParameter();
            return await this.SendAsync<FilesRemoteListParameter, FilesRemoteListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.remote.list
        /// </summary>
        public async Task<FilesRemoteListResponse> FilesRemoteListAsync(CancellationToken cancellationToken)
        {
            var p = new FilesRemoteListParameter();
            return await this.SendAsync<FilesRemoteListParameter, FilesRemoteListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.remote.list
        /// </summary>
        public async Task<FilesRemoteListResponse> FilesRemoteListAsync(FilesRemoteListParameter parameter)
        {
            return await this.SendAsync<FilesRemoteListParameter, FilesRemoteListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.remote.list
        /// </summary>
        public async Task<FilesRemoteListResponse> FilesRemoteListAsync(FilesRemoteListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesRemoteListParameter, FilesRemoteListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.remote.list
        /// </summary>
        public async Task<List<FilesRemoteListResponse>> FilesRemoteListAsync(PagingContext<FilesRemoteListResponse> context)
        {
            var p = new FilesRemoteListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.remote.list
        /// </summary>
        public async Task<List<FilesRemoteListResponse>> FilesRemoteListAsync(CancellationToken cancellationToken, PagingContext<FilesRemoteListResponse> context)
        {
            var p = new FilesRemoteListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.remote.list
        /// </summary>
        public async Task<List<FilesRemoteListResponse>> FilesRemoteListAsync(FilesRemoteListParameter parameter, PagingContext<FilesRemoteListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.remote.list
        /// </summary>
        public async Task<List<FilesRemoteListResponse>> FilesRemoteListAsync(FilesRemoteListParameter parameter, PagingContext<FilesRemoteListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
