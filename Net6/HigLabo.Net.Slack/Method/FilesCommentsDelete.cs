using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class FilesCommentsDeleteParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "files.comments.delete";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string File { get; set; }
        public string Id { get; set; }
    }
    public partial class FilesCommentsDeleteResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/files.comments.delete
        /// </summary>
        public async Task<FilesCommentsDeleteResponse> FilesCommentsDeleteAsync(string file, string id)
        {
            var p = new FilesCommentsDeleteParameter();
            p.File = file;
            p.Id = id;
            return await this.SendAsync<FilesCommentsDeleteParameter, FilesCommentsDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.comments.delete
        /// </summary>
        public async Task<FilesCommentsDeleteResponse> FilesCommentsDeleteAsync(string file, string id, CancellationToken cancellationToken)
        {
            var p = new FilesCommentsDeleteParameter();
            p.File = file;
            p.Id = id;
            return await this.SendAsync<FilesCommentsDeleteParameter, FilesCommentsDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.comments.delete
        /// </summary>
        public async Task<FilesCommentsDeleteResponse> FilesCommentsDeleteAsync(FilesCommentsDeleteParameter parameter)
        {
            return await this.SendAsync<FilesCommentsDeleteParameter, FilesCommentsDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.comments.delete
        /// </summary>
        public async Task<FilesCommentsDeleteResponse> FilesCommentsDeleteAsync(FilesCommentsDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesCommentsDeleteParameter, FilesCommentsDeleteResponse>(parameter, cancellationToken);
        }
    }
}
