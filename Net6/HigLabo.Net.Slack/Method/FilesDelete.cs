﻿
namespace HigLabo.Net.Slack
{
    public partial class FilesDeleteParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "files.delete";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string File { get; set; }
    }
    public partial class FilesDeleteResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<FilesDeleteResponse> FilesDeleteAsync(string file)
        {
            var p = new FilesDeleteParameter();
            p.File = file;
            return await this.SendAsync<FilesDeleteParameter, FilesDeleteResponse>(p, CancellationToken.None);
        }
        public async Task<FilesDeleteResponse> FilesDeleteAsync(string file, CancellationToken cancellationToken)
        {
            var p = new FilesDeleteParameter();
            p.File = file;
            return await this.SendAsync<FilesDeleteParameter, FilesDeleteResponse>(p, cancellationToken);
        }
        public async Task<FilesDeleteResponse> FilesDeleteAsync(FilesDeleteParameter parameter)
        {
            return await this.SendAsync<FilesDeleteParameter, FilesDeleteResponse>(parameter, CancellationToken.None);
        }
        public async Task<FilesDeleteResponse> FilesDeleteAsync(FilesDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesDeleteParameter, FilesDeleteResponse>(parameter, cancellationToken);
        }
    }
}