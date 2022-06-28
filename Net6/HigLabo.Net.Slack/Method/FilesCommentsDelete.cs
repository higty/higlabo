
namespace HigLabo.Net.Slack
{
    public class FilesCommentsDeleteParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "files.comments.delete";
        public string HttpMethod { get; private set; } = "POST";
        public string File { get; set; } = "";
        public string Id { get; set; } = "";
    }
    public partial class FilesCommentsDeleteResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<FilesCommentsDeleteResponse> FilesCommentsDeleteAsync(string file, string id)
        {
            var p = new FilesCommentsDeleteParameter();
            p.File = file;
            p.Id = id;
            return await this.SendAsync<FilesCommentsDeleteParameter, FilesCommentsDeleteResponse>(p, CancellationToken.None);
        }
        public async Task<FilesCommentsDeleteResponse> FilesCommentsDeleteAsync(string file, string id, CancellationToken cancellationToken)
        {
            var p = new FilesCommentsDeleteParameter();
            p.File = file;
            p.Id = id;
            return await this.SendAsync<FilesCommentsDeleteParameter, FilesCommentsDeleteResponse>(p, cancellationToken);
        }
        public async Task<FilesCommentsDeleteResponse> FilesCommentsDeleteAsync(FilesCommentsDeleteParameter parameter)
        {
            return await this.SendAsync<FilesCommentsDeleteParameter, FilesCommentsDeleteResponse>(parameter, CancellationToken.None);
        }
        public async Task<FilesCommentsDeleteResponse> FilesCommentsDeleteAsync(FilesCommentsDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesCommentsDeleteParameter, FilesCommentsDeleteResponse>(parameter, cancellationToken);
        }
    }
}
