using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class FilesDeleteParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "files.delete";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? File { get; set; }
    }
    public partial class FilesDeleteResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/files.delete
        /// </summary>
        public async Task<FilesDeleteResponse> FilesDeleteAsync(string? file)
        {
            var p = new FilesDeleteParameter();
            p.File = file;
            return await this.SendAsync<FilesDeleteParameter, FilesDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.delete
        /// </summary>
        public async Task<FilesDeleteResponse> FilesDeleteAsync(string? file, CancellationToken cancellationToken)
        {
            var p = new FilesDeleteParameter();
            p.File = file;
            return await this.SendAsync<FilesDeleteParameter, FilesDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.delete
        /// </summary>
        public async Task<FilesDeleteResponse> FilesDeleteAsync(FilesDeleteParameter parameter)
        {
            return await this.SendAsync<FilesDeleteParameter, FilesDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.delete
        /// </summary>
        public async Task<FilesDeleteResponse> FilesDeleteAsync(FilesDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesDeleteParameter, FilesDeleteResponse>(parameter, cancellationToken);
        }
    }
}
