
namespace HigLabo.Net.Slack
{
    public partial class FilesInfoParameter : IRestApiParameter, ICursor
    {
        string IRestApiParameter.ApiPath { get; } = "files.info";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string File { get; set; }
        public int? Count { get; set; }
        public string Cursor { get; set; }
        public int? Limit { get; set; }
        public int? Page { get; set; }
    }
    public partial class FilesInfoResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<FilesInfoResponse> FilesInfoAsync(string file)
        {
            var p = new FilesInfoParameter();
            p.File = file;
            return await this.SendAsync<FilesInfoParameter, FilesInfoResponse>(p, CancellationToken.None);
        }
        public async Task<FilesInfoResponse> FilesInfoAsync(string file, CancellationToken cancellationToken)
        {
            var p = new FilesInfoParameter();
            p.File = file;
            return await this.SendAsync<FilesInfoParameter, FilesInfoResponse>(p, cancellationToken);
        }
        public async Task<FilesInfoResponse> FilesInfoAsync(FilesInfoParameter parameter)
        {
            return await this.SendAsync<FilesInfoParameter, FilesInfoResponse>(parameter, CancellationToken.None);
        }
        public async Task<FilesInfoResponse> FilesInfoAsync(FilesInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesInfoParameter, FilesInfoResponse>(parameter, cancellationToken);
        }
        public async Task<List<FilesInfoResponse>> FilesInfoAsync(string file, PagingContext<FilesInfoResponse> context)
        {
            var p = new FilesInfoParameter();
            p.File = file;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<FilesInfoResponse>> FilesInfoAsync(string file, PagingContext<FilesInfoResponse> context, CancellationToken cancellationToken)
        {
            var p = new FilesInfoParameter();
            p.File = file;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<FilesInfoResponse>> FilesInfoAsync(FilesInfoParameter parameter, PagingContext<FilesInfoResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<FilesInfoResponse>> FilesInfoAsync(FilesInfoParameter parameter, PagingContext<FilesInfoResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
