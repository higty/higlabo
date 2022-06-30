
namespace HigLabo.Net.Slack
{
    public partial class FilesRemoteRemoveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "files.remote.remove";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string External_Id { get; set; }
        public string File { get; set; }
    }
    public partial class FilesRemoteRemoveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<FilesRemoteRemoveResponse> FilesRemoteRemoveAsync()
        {
            var p = new FilesRemoteRemoveParameter();
            return await this.SendAsync<FilesRemoteRemoveParameter, FilesRemoteRemoveResponse>(p, CancellationToken.None);
        }
        public async Task<FilesRemoteRemoveResponse> FilesRemoteRemoveAsync(CancellationToken cancellationToken)
        {
            var p = new FilesRemoteRemoveParameter();
            return await this.SendAsync<FilesRemoteRemoveParameter, FilesRemoteRemoveResponse>(p, cancellationToken);
        }
        public async Task<FilesRemoteRemoveResponse> FilesRemoteRemoveAsync(FilesRemoteRemoveParameter parameter)
        {
            return await this.SendAsync<FilesRemoteRemoveParameter, FilesRemoteRemoveResponse>(parameter, CancellationToken.None);
        }
        public async Task<FilesRemoteRemoveResponse> FilesRemoteRemoveAsync(FilesRemoteRemoveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesRemoteRemoveParameter, FilesRemoteRemoveResponse>(parameter, cancellationToken);
        }
    }
}
