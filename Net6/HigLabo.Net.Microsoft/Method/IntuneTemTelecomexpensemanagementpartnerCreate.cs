using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneTemTelecomexpensemanagementpartnerCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_TelecomExpenseManagementPartners,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_TelecomExpenseManagementPartners: return $"/deviceManagement/telecomExpenseManagementPartners";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Url { get; set; }
        public bool? AppAuthorized { get; set; }
        public bool? Enabled { get; set; }
        public DateTimeOffset? LastConnectionDateTime { get; set; }
    }
    public partial class IntuneTemTelecomexpensemanagementpartnerCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Url { get; set; }
        public bool? AppAuthorized { get; set; }
        public bool? Enabled { get; set; }
        public DateTimeOffset? LastConnectionDateTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-telecomexpensemanagementpartner-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemTelecomexpensemanagementpartnerCreateResponse> IntuneTemTelecomexpensemanagementpartnerCreateAsync()
        {
            var p = new IntuneTemTelecomexpensemanagementpartnerCreateParameter();
            return await this.SendAsync<IntuneTemTelecomexpensemanagementpartnerCreateParameter, IntuneTemTelecomexpensemanagementpartnerCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-telecomexpensemanagementpartner-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemTelecomexpensemanagementpartnerCreateResponse> IntuneTemTelecomexpensemanagementpartnerCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneTemTelecomexpensemanagementpartnerCreateParameter();
            return await this.SendAsync<IntuneTemTelecomexpensemanagementpartnerCreateParameter, IntuneTemTelecomexpensemanagementpartnerCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-telecomexpensemanagementpartner-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemTelecomexpensemanagementpartnerCreateResponse> IntuneTemTelecomexpensemanagementpartnerCreateAsync(IntuneTemTelecomexpensemanagementpartnerCreateParameter parameter)
        {
            return await this.SendAsync<IntuneTemTelecomexpensemanagementpartnerCreateParameter, IntuneTemTelecomexpensemanagementpartnerCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-telecomexpensemanagementpartner-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemTelecomexpensemanagementpartnerCreateResponse> IntuneTemTelecomexpensemanagementpartnerCreateAsync(IntuneTemTelecomexpensemanagementpartnerCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneTemTelecomexpensemanagementpartnerCreateParameter, IntuneTemTelecomexpensemanagementpartnerCreateResponse>(parameter, cancellationToken);
        }
    }
}
