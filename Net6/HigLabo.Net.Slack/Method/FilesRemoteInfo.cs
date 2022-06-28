
namespace HigLabo.Net.Slack
{
    public class FilesRemoteInfoParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "files.remote.info";
        public string HttpMethod { get; private set; } = "GET";
        public string External_Id { get; set; } = "";
        public string File { get; set; } = "";
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
