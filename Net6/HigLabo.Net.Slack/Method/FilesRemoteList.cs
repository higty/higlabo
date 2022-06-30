
namespace HigLabo.Net.Slack
{
    public partial class FilesRemoteListParameter : IRestApiParameter, ICursor
    {
        string IRestApiParameter.ApiPath { get; } = "files.remote.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Channel { get; set; }
        public string Cursor { get; set; }
        public int? Limit { get; set; }
        public string Ts_From { get; set; }
        public string Ts_To { get; set; }
    }
    public partial class FilesRemoteListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<FilesRemoteListResponse> FilesRemoteListAsync()
        {
            var p = new FilesRemoteListParameter();
            return await this.SendAsync<FilesRemoteListParameter, FilesRemoteListResponse>(p, CancellationToken.None);
        }
        public async Task<FilesRemoteListResponse> FilesRemoteListAsync(CancellationToken cancellationToken)
        {
            var p = new FilesRemoteListParameter();
            return await this.SendAsync<FilesRemoteListParameter, FilesRemoteListResponse>(p, cancellationToken);
        }
        public async Task<FilesRemoteListResponse> FilesRemoteListAsync(FilesRemoteListParameter parameter)
        {
            return await this.SendAsync<FilesRemoteListParameter, FilesRemoteListResponse>(parameter, CancellationToken.None);
        }
        public async Task<FilesRemoteListResponse> FilesRemoteListAsync(FilesRemoteListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesRemoteListParameter, FilesRemoteListResponse>(parameter, cancellationToken);
        }
        public async Task<List<FilesRemoteListResponse>> FilesRemoteListAsync(PagingContext<FilesRemoteListResponse> context)
        {
            var p = new FilesRemoteListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<FilesRemoteListResponse>> FilesRemoteListAsync(CancellationToken cancellationToken, PagingContext<FilesRemoteListResponse> context)
        {
            var p = new FilesRemoteListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<FilesRemoteListResponse>> FilesRemoteListAsync(FilesRemoteListParameter parameter, PagingContext<FilesRemoteListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<FilesRemoteListResponse>> FilesRemoteListAsync(FilesRemoteListParameter parameter, PagingContext<FilesRemoteListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
