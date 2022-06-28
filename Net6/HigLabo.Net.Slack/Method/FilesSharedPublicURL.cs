
namespace HigLabo.Net.Slack
{
    public class FilesSharedPublicURLParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "files.sharedPublicURL";
        public string HttpMethod { get; private set; } = "POST";
        public string File { get; set; } = "";
    }
    public partial class FilesSharedPublicURLResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<FilesSharedPublicURLResponse> FilesSharedPublicURLAsync(string file)
        {
            var p = new FilesSharedPublicURLParameter();
            p.File = file;
            return await this.SendAsync<FilesSharedPublicURLParameter, FilesSharedPublicURLResponse>(p, CancellationToken.None);
        }
        public async Task<FilesSharedPublicURLResponse> FilesSharedPublicURLAsync(string file, CancellationToken cancellationToken)
        {
            var p = new FilesSharedPublicURLParameter();
            p.File = file;
            return await this.SendAsync<FilesSharedPublicURLParameter, FilesSharedPublicURLResponse>(p, cancellationToken);
        }
        public async Task<FilesSharedPublicURLResponse> FilesSharedPublicURLAsync(FilesSharedPublicURLParameter parameter)
        {
            return await this.SendAsync<FilesSharedPublicURLParameter, FilesSharedPublicURLResponse>(parameter, CancellationToken.None);
        }
        public async Task<FilesSharedPublicURLResponse> FilesSharedPublicURLAsync(FilesSharedPublicURLParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesSharedPublicURLParameter, FilesSharedPublicURLResponse>(parameter, cancellationToken);
        }
    }
}
