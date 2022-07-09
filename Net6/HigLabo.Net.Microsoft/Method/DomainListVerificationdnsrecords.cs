using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DomainListVerificationdnsrecordsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Domains_Id_VerificationDnsRecords: return $"/domains/{Id}/verificationDnsRecords";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Domains_Id_VerificationDnsRecords,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class DomainListVerificationdnsrecordsResponse : RestApiResponse
    {
        public DomainDnsRecord[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-list-verificationdnsrecords?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListVerificationdnsrecordsResponse> DomainListVerificationdnsrecordsAsync()
        {
            var p = new DomainListVerificationdnsrecordsParameter();
            return await this.SendAsync<DomainListVerificationdnsrecordsParameter, DomainListVerificationdnsrecordsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-list-verificationdnsrecords?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListVerificationdnsrecordsResponse> DomainListVerificationdnsrecordsAsync(CancellationToken cancellationToken)
        {
            var p = new DomainListVerificationdnsrecordsParameter();
            return await this.SendAsync<DomainListVerificationdnsrecordsParameter, DomainListVerificationdnsrecordsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-list-verificationdnsrecords?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListVerificationdnsrecordsResponse> DomainListVerificationdnsrecordsAsync(DomainListVerificationdnsrecordsParameter parameter)
        {
            return await this.SendAsync<DomainListVerificationdnsrecordsParameter, DomainListVerificationdnsrecordsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-list-verificationdnsrecords?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListVerificationdnsrecordsResponse> DomainListVerificationdnsrecordsAsync(DomainListVerificationdnsrecordsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DomainListVerificationdnsrecordsParameter, DomainListVerificationdnsrecordsResponse>(parameter, cancellationToken);
        }
    }
}
