using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class FilesListParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "files.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Channel { get; set; }
        public int Count { get; set; }
        public string Files { get; set; }
        public int Page { get; set; }
        public bool Show_Files_Hidden_By_Limit { get; set; }
        public string Team_Id { get; set; }
        public string Ts_From { get; set; }
        public string Ts_To { get; set; }
        public FileType Types { get; set; }
        public string User { get; set; }
    }
    public partial class FilesListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/files.list
        /// </summary>
        public async Task<FilesListResponse> FilesListAsync()
        {
            var p = new FilesListParameter();
            return await this.SendAsync<FilesListParameter, FilesListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.list
        /// </summary>
        public async Task<FilesListResponse> FilesListAsync(CancellationToken cancellationToken)
        {
            var p = new FilesListParameter();
            return await this.SendAsync<FilesListParameter, FilesListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.list
        /// </summary>
        public async Task<FilesListResponse> FilesListAsync(FilesListParameter parameter)
        {
            return await this.SendAsync<FilesListParameter, FilesListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/files.list
        /// </summary>
        public async Task<FilesListResponse> FilesListAsync(FilesListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FilesListParameter, FilesListResponse>(parameter, cancellationToken);
        }
    }
}
