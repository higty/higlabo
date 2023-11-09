using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Delete an assistant file.
    /// <seealso href="https://api.openai.com/v1/assistants/{assistant_id}/files/{file_id}">https://api.openai.com/v1/assistants/{assistant_id}/files/{file_id}</seealso>
    /// </summary>
    public partial class AssistantFileDeleteParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        /// <summary>
        /// The ID of the assistant that the file belongs to.
        /// </summary>
        public string Assistant_Id { get; set; } = "";
        /// <summary>
        /// The ID of the file to delete.
        /// </summary>
        public string File_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/assistants/{Assistant_Id}/files/{File_Id}";
        }
    }
    public partial class AssistantFileDeleteResponse : DeleteObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<AssistantFileDeleteResponse> AssistantFileDeleteAsync(string assistant_Id, string file_Id, CancellationToken cancellationToken)
        {
            var p = new AssistantFileDeleteParameter();
            p.Assistant_Id = assistant_Id;
            p.File_Id = file_Id;
            return await this.SendJsonAsync<AssistantFileDeleteParameter, AssistantFileDeleteResponse>(p, cancellationToken);
        }
        public async ValueTask<AssistantFileDeleteResponse> AssistantFileDeleteAsync(AssistantFileDeleteParameter parameter)
        {
            return await this.SendJsonAsync<AssistantFileDeleteParameter, AssistantFileDeleteResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<AssistantFileDeleteResponse> AssistantFileDeleteAsync(AssistantFileDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<AssistantFileDeleteParameter, AssistantFileDeleteResponse>(parameter, cancellationToken);
        }
    }
}
