using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneTemTelecomexpensemanagementpartnerListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class IntuneTemTelecomexpensemanagementpartnerListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-tem-telecomexpensemanagementpartner?view=graph-rest-1.0
        /// </summary>
        public partial class TelecomExpenseManagementPartner
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? Url { get; set; }
            public bool? AppAuthorized { get; set; }
            public bool? Enabled { get; set; }
            public DateTimeOffset? LastConnectionDateTime { get; set; }
        }

        public TelecomExpenseManagementPartner[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-telecomexpensemanagementpartner-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemTelecomexpensemanagementpartnerListResponse> IntuneTemTelecomexpensemanagementpartnerListAsync()
        {
            var p = new IntuneTemTelecomexpensemanagementpartnerListParameter();
            return await this.SendAsync<IntuneTemTelecomexpensemanagementpartnerListParameter, IntuneTemTelecomexpensemanagementpartnerListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-telecomexpensemanagementpartner-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemTelecomexpensemanagementpartnerListResponse> IntuneTemTelecomexpensemanagementpartnerListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneTemTelecomexpensemanagementpartnerListParameter();
            return await this.SendAsync<IntuneTemTelecomexpensemanagementpartnerListParameter, IntuneTemTelecomexpensemanagementpartnerListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-telecomexpensemanagementpartner-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemTelecomexpensemanagementpartnerListResponse> IntuneTemTelecomexpensemanagementpartnerListAsync(IntuneTemTelecomexpensemanagementpartnerListParameter parameter)
        {
            return await this.SendAsync<IntuneTemTelecomexpensemanagementpartnerListParameter, IntuneTemTelecomexpensemanagementpartnerListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-telecomexpensemanagementpartner-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemTelecomexpensemanagementpartnerListResponse> IntuneTemTelecomexpensemanagementpartnerListAsync(IntuneTemTelecomexpensemanagementpartnerListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneTemTelecomexpensemanagementpartnerListParameter, IntuneTemTelecomexpensemanagementpartnerListResponse>(parameter, cancellationToken);
        }
    }
}
