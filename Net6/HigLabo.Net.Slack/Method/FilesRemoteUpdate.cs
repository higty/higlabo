
namespace HigLabo.Net.Slack
{
    public class FilesRemoteUpdateParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "files.remote.update";
        public string HttpMethod { get; private set; } = "GET";
        public string External_Id { get; set; } = "";
        public string External_Url { get; set; } = "";
        public string File { get; set; } = "";
        public string Filetype { get; set; } = "";
        public string Indexable_File_Contents { get; set; } = "";
        public string Preview_Image { get; set; } = "";
        public string Title { get; set; } = "";
    }
    public partial class FilesRemoteUpdateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<FilesRemoteUpdateResponse> FilesRemoteUpdateAsync()
        {
            var p = new FilesRemoteUpdateParameter();
            return await this.SendAsync<FilesRemoteUpdateParameter, FilesRemoteUpdateResponse>(p, CancellationToken.None);
        }
        public async Task<FilesRemoteUpdateResponse> FilesRemoteUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new FilesRemoteUpdateParameter();
            return await this.SendAsync<FilesRemoteUpdateParameter, FilesRemoteUpdateResponse>(p, cancellationToken);
        }
        public async Task<FilesRemoteUpdateResponse> FilesRemoteUpdateAsync(FilesRemoteUpdateParameter parameter)
        {
            return await this.SendAsync<FilesRemoteUpdateParameter, FilesRemoteUpdateResponse>(parameter, CancellationToken.None);
        }
        public async Task<FilesRemoteUpdateResponse> FilesRemoteUpdateAsync(FilesRemoteUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesRemoteUpdateParameter, FilesRemoteUpdateResponse>(parameter, cancellationToken);
        }
    }
}
