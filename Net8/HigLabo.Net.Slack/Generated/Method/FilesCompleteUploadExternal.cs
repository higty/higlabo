using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class FilesCompleteUploadExternalParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "files.completeUploadExternal";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Files { get; set; }
        public string? Channel_Id { get; set; }
        public string? Initial_Comment { get; set; }
        public string? Thread_Ts { get; set; }
    }
    public partial class FilesCompleteUploadExternalResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/files.completeUploadExternal
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/files.completeUploadExternal
        /// </summary>
        public async ValueTask<FilesCompleteUploadExternalResponse> FilesCompleteUploadExternalAsync(string? files)
        {
            var p = new FilesCompleteUploadExternalParameter();
            p.Files = files;
            return await this.SendAsync<FilesCompleteUploadExternalParameter, FilesCompleteUploadExternalResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.completeUploadExternal
        /// </summary>
        public async ValueTask<FilesCompleteUploadExternalResponse> FilesCompleteUploadExternalAsync(string? files, CancellationToken cancellationToken)
        {
            var p = new FilesCompleteUploadExternalParameter();
            p.Files = files;
            return await this.SendAsync<FilesCompleteUploadExternalParameter, FilesCompleteUploadExternalResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.completeUploadExternal
        /// </summary>
        public async ValueTask<FilesCompleteUploadExternalResponse> FilesCompleteUploadExternalAsync(FilesCompleteUploadExternalParameter parameter)
        {
            return await this.SendAsync<FilesCompleteUploadExternalParameter, FilesCompleteUploadExternalResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.completeUploadExternal
        /// </summary>
        public async ValueTask<FilesCompleteUploadExternalResponse> FilesCompleteUploadExternalAsync(FilesCompleteUploadExternalParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesCompleteUploadExternalParameter, FilesCompleteUploadExternalResponse>(parameter, cancellationToken);
        }
    }
}
