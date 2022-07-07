using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CallTransferParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Communications_Calls_Id_Transfer,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_Calls_Id_Transfer: return $"/communications/calls/{Id}/transfer";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public InvitationParticipantInfo? TransferTarget { get; set; }
        public ParticipantInfo? Transferee { get; set; }
        public string Id { get; set; }
    }
    public partial class CallTransferResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-transfer?view=graph-rest-1.0
        /// </summary>
        public async Task<CallTransferResponse> CallTransferAsync()
        {
            var p = new CallTransferParameter();
            return await this.SendAsync<CallTransferParameter, CallTransferResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-transfer?view=graph-rest-1.0
        /// </summary>
        public async Task<CallTransferResponse> CallTransferAsync(CancellationToken cancellationToken)
        {
            var p = new CallTransferParameter();
            return await this.SendAsync<CallTransferParameter, CallTransferResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-transfer?view=graph-rest-1.0
        /// </summary>
        public async Task<CallTransferResponse> CallTransferAsync(CallTransferParameter parameter)
        {
            return await this.SendAsync<CallTransferParameter, CallTransferResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/call-transfer?view=graph-rest-1.0
        /// </summary>
        public async Task<CallTransferResponse> CallTransferAsync(CallTransferParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallTransferParameter, CallTransferResponse>(parameter, cancellationToken);
        }
    }
}
