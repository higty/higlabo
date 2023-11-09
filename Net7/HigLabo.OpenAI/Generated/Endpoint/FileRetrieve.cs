using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Returns information about a specific file.
    /// <seealso href="https://api.openai.com/v1/files/{file_id}">https://api.openai.com/v1/files/{file_id}</seealso>
    /// </summary>
    public partial class FileRetrieveParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "GET";
        /// <summary>
        /// The ID of the file to use for this request.
        /// </summary>
        public string File_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/files/{File_Id}";
        }
    }
    public partial class FileRetrieveResponse : FileObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<FileRetrieveResponse> FileRetrieveAsync(string file_Id)
        {
            var p = new FileRetrieveParameter();
            p.File_Id = file_Id;
            return await this.SendJsonAsync<FileRetrieveParameter, FileRetrieveResponse>(p, CancellationToken.None);
        }
        public async ValueTask<FileRetrieveResponse> FileRetrieveAsync(string file_Id, CancellationToken cancellationToken)
        {
            var p = new FileRetrieveParameter();
            p.File_Id = file_Id;
            return await this.SendJsonAsync<FileRetrieveParameter, FileRetrieveResponse>(p, cancellationToken);
        }
        public async ValueTask<FileRetrieveResponse> FileRetrieveAsync(FileRetrieveParameter parameter)
        {
            return await this.SendJsonAsync<FileRetrieveParameter, FileRetrieveResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<FileRetrieveResponse> FileRetrieveAsync(FileRetrieveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<FileRetrieveParameter, FileRetrieveResponse>(parameter, cancellationToken);
        }
    }
}
