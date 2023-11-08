using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Delete a file.
    /// <seealso href="https://api.openai.com/v1/files/{file_id}">https://api.openai.com/v1/files/{file_id}</seealso>
    /// </summary>
    public partial class FileDeleteParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the file to use for this request.
        /// </summary>
        public string File_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/files/{File_Id}";
        }
    }
    public partial class FileDeleteResponse : RestApiResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FileDeleteResponse> FileDeleteAsync(string file_Id, CancellationToken cancellationToken)
        {
            var p = new FileDeleteParameter();
            p.File_Id = file_Id;
            return await this.SendJsonAsync<FileDeleteParameter, FileDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<FileDeleteResponse> FileDeleteAsync(FileDeleteParameter parameter)
        {
            return await this.SendJsonAsync<FileDeleteParameter, FileDeleteResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<FileDeleteResponse> FileDeleteAsync(FileDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FileDeleteParameter, FileDeleteResponse>(parameter, cancellationToken);
        }
    }
}
