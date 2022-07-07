using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class MessageSendParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Messages_Id_Send,
            Users_IdOrUserPrincipalName_Messages_Id_Send,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Messages_Id_Send: return $"/me/messages/{Id}/send";
                    case ApiPath.Users_IdOrUserPrincipalName_Messages_Id_Send: return $"/users/{IdOrUserPrincipalName}/messages/{Id}/send";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class MessageSendResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-send?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageSendResponse> MessageSendAsync()
        {
            var p = new MessageSendParameter();
            return await this.SendAsync<MessageSendParameter, MessageSendResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-send?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageSendResponse> MessageSendAsync(CancellationToken cancellationToken)
        {
            var p = new MessageSendParameter();
            return await this.SendAsync<MessageSendParameter, MessageSendResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-send?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageSendResponse> MessageSendAsync(MessageSendParameter parameter)
        {
            return await this.SendAsync<MessageSendParameter, MessageSendResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/message-send?view=graph-rest-1.0
        /// </summary>
        public async Task<MessageSendResponse> MessageSendAsync(MessageSendParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MessageSendParameter, MessageSendResponse>(parameter, cancellationToken);
        }
    }
}
