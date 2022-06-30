
namespace HigLabo.Net.Slack
{
    public partial class FilesRemoteInfoParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "files.remote.info";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string External_Id { get; set; }
        public string File { get; set; }
    }
    public partial class FilesRemoteInfoResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<FilesRemoteInfoResponse> FilesRemoteInfoAsync()
        {
            var p = new FilesRemoteInfoParameter();
            return await this.SendAsync<FilesRemoteInfoParameter, FilesRemoteInfoResponse>(p, CancellationToken.None);
        }
        public async Task<FilesRemoteInfoResponse> FilesRemoteInfoAsync(CancellationToken cancellationToken)
        {
            var p = new FilesRemoteInfoParameter();
            return await this.SendAsync<FilesRemoteInfoParameter, FilesRemoteInfoResponse>(p, cancellationToken);
        }
        public async Task<FilesRemoteInfoResponse> FilesRemoteInfoAsync(FilesRemoteInfoParameter parameter)
        {
            return await this.SendAsync<FilesRemoteInfoParameter, FilesRemoteInfoResponse>(parameter, CancellationToken.None);
        }
        public async Task<FilesRemoteInfoResponse> FilesRemoteInfoAsync(FilesRemoteInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesRemoteInfoParameter, FilesRemoteInfoResponse>(parameter, cancellationToken);
        }
    }
}
