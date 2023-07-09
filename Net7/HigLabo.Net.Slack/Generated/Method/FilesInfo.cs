using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class FilesInfoParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "files.info";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? File { get; set; }
        public int? Count { get; set; }
        public string? Cursor { get; set; }
        string? IRestApiPagingParameter.NextPageToken
        {
            get
            {
                return this.Cursor;
            }
            set
            {
                this.Cursor = value;
            }
        }
        public int? Limit { get; set; }
        public int? Page { get; set; }
    }
    public partial class FilesInfoResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/files.info
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/files.info
        /// </summary>
        public async ValueTask<FilesInfoResponse> FilesInfoAsync(string? file)
        {
            var p = new FilesInfoParameter();
            p.File = file;
            return await this.SendAsync<FilesInfoParameter, FilesInfoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.info
        /// </summary>
        public async ValueTask<FilesInfoResponse> FilesInfoAsync(string? file, CancellationToken cancellationToken)
        {
            var p = new FilesInfoParameter();
            p.File = file;
            return await this.SendAsync<FilesInfoParameter, FilesInfoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.info
        /// </summary>
        public async ValueTask<FilesInfoResponse> FilesInfoAsync(FilesInfoParameter parameter)
        {
            return await this.SendAsync<FilesInfoParameter, FilesInfoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.info
        /// </summary>
        public async ValueTask<FilesInfoResponse> FilesInfoAsync(FilesInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesInfoParameter, FilesInfoResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.info
        /// </summary>
        public async ValueTask<List<FilesInfoResponse>> FilesInfoAsync(string? file, PagingContext<FilesInfoResponse> context)
        {
            var p = new FilesInfoParameter();
            p.File = file;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.info
        /// </summary>
        public async ValueTask<List<FilesInfoResponse>> FilesInfoAsync(string? file, PagingContext<FilesInfoResponse> context, CancellationToken cancellationToken)
        {
            var p = new FilesInfoParameter();
            p.File = file;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.info
        /// </summary>
        public async ValueTask<List<FilesInfoResponse>> FilesInfoAsync(FilesInfoParameter parameter, PagingContext<FilesInfoResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.info
        /// </summary>
        public async ValueTask<List<FilesInfoResponse>> FilesInfoAsync(FilesInfoParameter parameter, PagingContext<FilesInfoResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
