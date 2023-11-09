using System.Runtime.CompilerServices;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Create an assistant file by attaching a File to an assistant.
    /// <seealso href="https://api.openai.com/v1/assistants/{assistant_id}/files">https://api.openai.com/v1/assistants/{assistant_id}/files</seealso>
    /// </summary>
    public partial class AssistantFileCreateParameter : IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// The ID of the assistant for which to create a File.
        /// </summary>
        public string Assistant_Id { get; set; } = "";
        /// <summary>
        /// A File ID (with purpose="assistants") that the assistant should use. Useful for tools like retrieval and code_interpreter that can access files.
        /// </summary>
        public string File_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/assistants/{Assistant_Id}/files";
        }
    }
    public partial class AssistantFileCreateResponse : AssistantFileObjectResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<AssistantFileCreateResponse> AssistantFileCreateAsync(string assistant_Id, string file_Id, CancellationToken cancellationToken)
        {
            var p = new AssistantFileCreateParameter();
            p.Assistant_Id = assistant_Id;
            p.File_Id = file_Id;
            return await this.SendJsonAsync<AssistantFileCreateParameter, AssistantFileCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<AssistantFileCreateResponse> AssistantFileCreateAsync(AssistantFileCreateParameter parameter)
        {
            return await this.SendJsonAsync<AssistantFileCreateParameter, AssistantFileCreateResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<AssistantFileCreateResponse> AssistantFileCreateAsync(AssistantFileCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<AssistantFileCreateParameter, AssistantFileCreateResponse>(parameter, cancellationToken);
        }
    }
}
