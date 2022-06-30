﻿
namespace HigLabo.Net.Slack
{
    public partial class FilesUploadParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "files.upload";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channels { get; set; }
        public string Content { get; set; }
        public string File { get; set; }
        public string Filename { get; set; }
        public string Filetype { get; set; }
        public string Initial_Comment { get; set; }
        public string Thread_Ts { get; set; }
        public string Title { get; set; }
    }
    public partial class FilesUploadResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<FilesUploadResponse> FilesUploadAsync()
        {
            var p = new FilesUploadParameter();
            return await this.SendAsync<FilesUploadParameter, FilesUploadResponse>(p, CancellationToken.None);
        }
        public async Task<FilesUploadResponse> FilesUploadAsync(CancellationToken cancellationToken)
        {
            var p = new FilesUploadParameter();
            return await this.SendAsync<FilesUploadParameter, FilesUploadResponse>(p, cancellationToken);
        }
        public async Task<FilesUploadResponse> FilesUploadAsync(FilesUploadParameter parameter)
        {
            return await this.SendAsync<FilesUploadParameter, FilesUploadResponse>(parameter, CancellationToken.None);
        }
        public async Task<FilesUploadResponse> FilesUploadAsync(FilesUploadParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesUploadParameter, FilesUploadResponse>(parameter, cancellationToken);
        }
    }
}