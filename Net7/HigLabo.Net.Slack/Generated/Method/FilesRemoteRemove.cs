using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class FilesRemoteRemoveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "files.remote.remove";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? External_Id { get; set; }
        public string? File { get; set; }
    }
    public partial class FilesRemoteRemoveResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/files.remote.remove
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/files.remote.remove
        /// </summary>
        public async ValueTask<FilesRemoteRemoveResponse> FilesRemoteRemoveAsync()
        {
            var p = new FilesRemoteRemoveParameter();
            return await this.SendAsync<FilesRemoteRemoveParameter, FilesRemoteRemoveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.remote.remove
        /// </summary>
        public async ValueTask<FilesRemoteRemoveResponse> FilesRemoteRemoveAsync(CancellationToken cancellationToken)
        {
            var p = new FilesRemoteRemoveParameter();
            return await this.SendAsync<FilesRemoteRemoveParameter, FilesRemoteRemoveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.remote.remove
        /// </summary>
        public async ValueTask<FilesRemoteRemoveResponse> FilesRemoteRemoveAsync(FilesRemoteRemoveParameter parameter)
        {
            return await this.SendAsync<FilesRemoteRemoveParameter, FilesRemoteRemoveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.remote.remove
        /// </summary>
        public async ValueTask<FilesRemoteRemoveResponse> FilesRemoteRemoveAsync(FilesRemoteRemoveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesRemoteRemoveParameter, FilesRemoteRemoveResponse>(parameter, cancellationToken);
        }
    }
}
