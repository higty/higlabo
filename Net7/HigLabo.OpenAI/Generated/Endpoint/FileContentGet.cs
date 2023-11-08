using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns the contents of the specified file.
    /// <seealso href="https://api.openai.com/v1/files/{file_id}/content">https://api.openai.com/v1/files/{file_id}/content</seealso>
    /// </summary>
    public partial class FileContentGetParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the file to use for this request.
        /// </summary>
        public string File_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/files/{File_Id}/content";
        }
    }
    public partial class FileContentGetResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FileContentGetResponse> FileContentGetAsync(string file_Id, CancellationToken cancellationToken)
        {
            var p = new FileContentGetParameter();
            p.File_Id = file_Id;
            return await this.SendJsonAsync<FileContentGetParameter, FileContentGetResponse>(p, cancellationToken);
        }
        public async ValueTask<FileContentGetResponse> FileContentGetAsync(FileContentGetParameter parameter)
        {
            return await this.SendJsonAsync<FileContentGetParameter, FileContentGetResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<FileContentGetResponse> FileContentGetAsync(FileContentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FileContentGetParameter, FileContentGetResponse>(parameter, cancellationToken);
        }
    }
}
