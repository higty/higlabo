using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// Cancel a ChatKit session
    /// <seealso href="https://api.openai.com/v1/chatkit/sessions/{session_id}/cancel">https://api.openai.com/v1/chatkit/sessions/{session_id}/cancel</seealso>
    /// </summary>
    public partial class ChatKitSessionCancelParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// Unique identifier for the ChatKit session to cancel.
        /// </summary>
        public string Session_Id { get; set; } = "";

        string IRestApiParameter.GetApiPath()
        {
            return $"/chatkit/sessions/{Session_Id}/cancel";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class ChatKitSessionCancelResponse : ChatKitSessionResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ChatKitSessionCancelResponse> ChatKitSessionCancelAsync(string session_Id)
        {
            var p = new ChatKitSessionCancelParameter();
            p.Session_Id = session_Id;
            return await this.SendJsonAsync<ChatKitSessionCancelParameter, ChatKitSessionCancelResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatKitSessionCancelResponse> ChatKitSessionCancelAsync(string session_Id, CancellationToken cancellationToken)
        {
            var p = new ChatKitSessionCancelParameter();
            p.Session_Id = session_Id;
            return await this.SendJsonAsync<ChatKitSessionCancelParameter, ChatKitSessionCancelResponse>(p, cancellationToken);
        }
        public async ValueTask<ChatKitSessionCancelResponse> ChatKitSessionCancelAsync(ChatKitSessionCancelParameter parameter)
        {
            return await this.SendJsonAsync<ChatKitSessionCancelParameter, ChatKitSessionCancelResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatKitSessionCancelResponse> ChatKitSessionCancelAsync(ChatKitSessionCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ChatKitSessionCancelParameter, ChatKitSessionCancelResponse>(parameter, cancellationToken);
        }
    }
}
