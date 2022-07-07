using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneTemTelecomexpensemanagementpartnerGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string TelecomExpenseManagementPartnerId { get; set; }
    }
    public partial class IntuneTemTelecomexpensemanagementpartnerGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-telecomexpensemanagementpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemTelecomexpensemanagementpartnerGetResponse> IntuneTemTelecomexpensemanagementpartnerGetAsync()
        {
            var p = new IntuneTemTelecomexpensemanagementpartnerGetParameter();
            return await this.SendAsync<IntuneTemTelecomexpensemanagementpartnerGetParameter, IntuneTemTelecomexpensemanagementpartnerGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-telecomexpensemanagementpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemTelecomexpensemanagementpartnerGetResponse> IntuneTemTelecomexpensemanagementpartnerGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneTemTelecomexpensemanagementpartnerGetParameter();
            return await this.SendAsync<IntuneTemTelecomexpensemanagementpartnerGetParameter, IntuneTemTelecomexpensemanagementpartnerGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-telecomexpensemanagementpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemTelecomexpensemanagementpartnerGetResponse> IntuneTemTelecomexpensemanagementpartnerGetAsync(IntuneTemTelecomexpensemanagementpartnerGetParameter parameter)
        {
            return await this.SendAsync<IntuneTemTelecomexpensemanagementpartnerGetParameter, IntuneTemTelecomexpensemanagementpartnerGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-telecomexpensemanagementpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemTelecomexpensemanagementpartnerGetResponse> IntuneTemTelecomexpensemanagementpartnerGetAsync(IntuneTemTelecomexpensemanagementpartnerGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneTemTelecomexpensemanagementpartnerGetParameter, IntuneTemTelecomexpensemanagementpartnerGetResponse>(parameter, cancellationToken);
        }
    }
}
