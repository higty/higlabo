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
    /// Create a ChatKit session
    /// <seealso href="https://api.openai.com/v1/chatkit/sessions">https://api.openai.com/v1/chatkit/sessions</seealso>
    /// </summary>
    public partial class ChatKitSessionCreateParameter : RestApiParameter, IRestApiParameter
    {
        string IRestApiParameter.HttpMethod { get; } = "POST";
        /// <summary>
        /// A free-form string that identifies your end user; ensures this Session can access other objects that have the same user scope.
        /// </summary>
        public string User { get; set; } = "";
        /// <summary>
        /// Workflow that powers the session.
        /// </summary>
        public ChatKitWorkflow Workflow { get; set; } = new();
        /// <summary>
        /// Optional overrides for ChatKit runtime configuration features
        /// </summary>
        public object? Chatkit_Configuration { get; set; }
        /// <summary>
        /// Optional override for session expiration timing in seconds from creation. Defaults to 10 minutes.
        /// </summary>
        public ExpirationPolicy? Expires_After { get; set; }
        /// <summary>
        /// Optional override for per-minute request limits. When omitted, defaults to 10.
        /// </summary>
        public ChatKitRateLimits? Rate_Limits { get; set; }

        string IRestApiParameter.GetApiPath()
        {
            return $"/chatkit/sessions";
        }
        public override object GetRequestBody()
        {
            return new {
            	user = this.User,
            	workflow = this.Workflow,
            	chatkit_configuration = this.Chatkit_Configuration,
            	expires_after = this.Expires_After,
            	rate_limits = this.Rate_Limits,
            };
        }
    }
    public partial class ChatKitSessionCreateResponse : ChatKitSessionResponse
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<ChatKitSessionCreateResponse> ChatKitSessionCreateAsync(string user, ChatKitWorkflow workflow)
        {
            var p = new ChatKitSessionCreateParameter();
            p.User = user;
            p.Workflow = workflow;
            return await this.SendJsonAsync<ChatKitSessionCreateParameter, ChatKitSessionCreateResponse>(p, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatKitSessionCreateResponse> ChatKitSessionCreateAsync(string user, ChatKitWorkflow workflow, CancellationToken cancellationToken)
        {
            var p = new ChatKitSessionCreateParameter();
            p.User = user;
            p.Workflow = workflow;
            return await this.SendJsonAsync<ChatKitSessionCreateParameter, ChatKitSessionCreateResponse>(p, cancellationToken);
        }
        public async ValueTask<ChatKitSessionCreateResponse> ChatKitSessionCreateAsync(ChatKitSessionCreateParameter parameter)
        {
            return await this.SendJsonAsync<ChatKitSessionCreateParameter, ChatKitSessionCreateResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<ChatKitSessionCreateResponse> ChatKitSessionCreateAsync(ChatKitSessionCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<ChatKitSessionCreateParameter, ChatKitSessionCreateResponse>(parameter, cancellationToken);
        }
    }
}
