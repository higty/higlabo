using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class FilesRevokePublicURLParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "files.revokePublicURL";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? File { get; set; }
    }
    public partial class FilesRevokePublicURLResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/files.revokePublicURL
        /// </summary>
        public async Task<FilesRevokePublicURLResponse> FilesRevokePublicURLAsync(string? file)
        {
            var p = new FilesRevokePublicURLParameter();
            p.File = file;
            return await this.SendAsync<FilesRevokePublicURLParameter, FilesRevokePublicURLResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.revokePublicURL
        /// </summary>
        public async Task<FilesRevokePublicURLResponse> FilesRevokePublicURLAsync(string? file, CancellationToken cancellationToken)
        {
            var p = new FilesRevokePublicURLParameter();
            p.File = file;
            return await this.SendAsync<FilesRevokePublicURLParameter, FilesRevokePublicURLResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.revokePublicURL
        /// </summary>
        public async Task<FilesRevokePublicURLResponse> FilesRevokePublicURLAsync(FilesRevokePublicURLParameter parameter)
        {
            return await this.SendAsync<FilesRevokePublicURLParameter, FilesRevokePublicURLResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.revokePublicURL
        /// </summary>
        public async Task<FilesRevokePublicURLResponse> FilesRevokePublicURLAsync(FilesRevokePublicURLParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesRevokePublicURLParameter, FilesRevokePublicURLResponse>(parameter, cancellationToken);
        }
    }
}
