using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneTemTelecomexpensemanagementpartnerDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_TelecomExpenseManagementPartners_TelecomExpenseManagementPartnerId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_TelecomExpenseManagementPartners_TelecomExpenseManagementPartnerId: return $"/deviceManagement/telecomExpenseManagementPartners/{TelecomExpenseManagementPartnerId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string TelecomExpenseManagementPartnerId { get; set; }
    }
    public partial class IntuneTemTelecomexpensemanagementpartnerDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-telecomexpensemanagementpartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemTelecomexpensemanagementpartnerDeleteResponse> IntuneTemTelecomexpensemanagementpartnerDeleteAsync()
        {
            var p = new IntuneTemTelecomexpensemanagementpartnerDeleteParameter();
            return await this.SendAsync<IntuneTemTelecomexpensemanagementpartnerDeleteParameter, IntuneTemTelecomexpensemanagementpartnerDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-telecomexpensemanagementpartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemTelecomexpensemanagementpartnerDeleteResponse> IntuneTemTelecomexpensemanagementpartnerDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneTemTelecomexpensemanagementpartnerDeleteParameter();
            return await this.SendAsync<IntuneTemTelecomexpensemanagementpartnerDeleteParameter, IntuneTemTelecomexpensemanagementpartnerDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-telecomexpensemanagementpartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemTelecomexpensemanagementpartnerDeleteResponse> IntuneTemTelecomexpensemanagementpartnerDeleteAsync(IntuneTemTelecomexpensemanagementpartnerDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneTemTelecomexpensemanagementpartnerDeleteParameter, IntuneTemTelecomexpensemanagementpartnerDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-telecomexpensemanagementpartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemTelecomexpensemanagementpartnerDeleteResponse> IntuneTemTelecomexpensemanagementpartnerDeleteAsync(IntuneTemTelecomexpensemanagementpartnerDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneTemTelecomexpensemanagementpartnerDeleteParameter, IntuneTemTelecomexpensemanagementpartnerDeleteResponse>(parameter, cancellationToken);
        }
    }
}
