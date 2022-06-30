
namespace HigLabo.Net.Slack
{
    public partial class FilesSharedPublicURLParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "files.sharedPublicURL";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string File { get; set; }
    }
    public partial class FilesSharedPublicURLResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/files.sharedPublicURL
        /// </summary>
        public async Task<FilesSharedPublicURLResponse> FilesSharedPublicURLAsync(string file)
        {
            var p = new FilesSharedPublicURLParameter();
            p.File = file;
            return await this.SendAsync<FilesSharedPublicURLParameter, FilesSharedPublicURLResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.sharedPublicURL
        /// </summary>
        public async Task<FilesSharedPublicURLResponse> FilesSharedPublicURLAsync(string file, CancellationToken cancellationToken)
        {
            var p = new FilesSharedPublicURLParameter();
            p.File = file;
            return await this.SendAsync<FilesSharedPublicURLParameter, FilesSharedPublicURLResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.sharedPublicURL
        /// </summary>
        public async Task<FilesSharedPublicURLResponse> FilesSharedPublicURLAsync(FilesSharedPublicURLParameter parameter)
        {
            return await this.SendAsync<FilesSharedPublicURLParameter, FilesSharedPublicURLResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.sharedPublicURL
        /// </summary>
        public async Task<FilesSharedPublicURLResponse> FilesSharedPublicURLAsync(FilesSharedPublicURLParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesSharedPublicURLParameter, FilesSharedPublicURLResponse>(parameter, cancellationToken);
        }
    }
}
