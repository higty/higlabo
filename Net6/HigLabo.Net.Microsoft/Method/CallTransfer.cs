using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-transfer?view=graph-rest-1.0
    /// </summary>
    public partial class CallTransferParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_Calls_Id_Transfer: return $"/communications/calls/{Id}/transfer";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Communications_Calls_Id_Transfer,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public InvitationParticipantInfo? TransferTarget { get; set; }
        public ParticipantInfo? Transferee { get; set; }
    }
    public partial class CallTransferResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-transfer?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-transfer?view=graph-rest-1.0
        /// </summary>
        public async Task<CallTransferResponse> CallTransferAsync()
        {
            var p = new CallTransferParameter();
            return await this.SendAsync<CallTransferParameter, CallTransferResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-transfer?view=graph-rest-1.0
        /// </summary>
        public async Task<CallTransferResponse> CallTransferAsync(CancellationToken cancellationToken)
        {
            var p = new CallTransferParameter();
            return await this.SendAsync<CallTransferParameter, CallTransferResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-transfer?view=graph-rest-1.0
        /// </summary>
        public async Task<CallTransferResponse> CallTransferAsync(CallTransferParameter parameter)
        {
            return await this.SendAsync<CallTransferParameter, CallTransferResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-transfer?view=graph-rest-1.0
        /// </summary>
        public async Task<CallTransferResponse> CallTransferAsync(CallTransferParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallTransferParameter, CallTransferResponse>(parameter, cancellationToken);
        }
    }
}
