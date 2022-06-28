
namespace HigLabo.Net.Slack
{
    public class FilesRevokePublicURLParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "files.revokePublicURL";
        public string HttpMethod { get; private set; } = "POST";
        public string File { get; set; } = "";
    }
    public partial class FilesRevokePublicURLResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<FilesRevokePublicURLResponse> FilesRevokePublicURLAsync(string file)
        {
            var p = new FilesRevokePublicURLParameter();
            p.File = file;
            return await this.SendAsync<FilesRevokePublicURLParameter, FilesRevokePublicURLResponse>(p, CancellationToken.None);
        }
        public async Task<FilesRevokePublicURLResponse> FilesRevokePublicURLAsync(string file, CancellationToken cancellationToken)
        {
            var p = new FilesRevokePublicURLParameter();
            p.File = file;
            return await this.SendAsync<FilesRevokePublicURLParameter, FilesRevokePublicURLResponse>(p, cancellationToken);
        }
        public async Task<FilesRevokePublicURLResponse> FilesRevokePublicURLAsync(FilesRevokePublicURLParameter parameter)
        {
            return await this.SendAsync<FilesRevokePublicURLParameter, FilesRevokePublicURLResponse>(parameter, CancellationToken.None);
        }
        public async Task<FilesRevokePublicURLResponse> FilesRevokePublicURLAsync(FilesRevokePublicURLParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesRevokePublicURLParameter, FilesRevokePublicURLResponse>(parameter, cancellationToken);
        }
    }
}
