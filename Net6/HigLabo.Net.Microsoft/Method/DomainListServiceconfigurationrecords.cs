using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DomainListServiceconfigurationrecordsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Domains_Id_ServiceConfigurationRecords,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Domains_Id_ServiceConfigurationRecords: return $"/domains/{Id}/serviceConfigurationRecords";
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
        public string Id { get; set; }
    }
    public partial class DomainListServiceconfigurationrecordsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/domaindnsrecord?view=graph-rest-1.0
        /// </summary>
        public partial class DomainDnsRecord
        {
            public string? Id { get; set; }
            public bool? IsOptional { get; set; }
            public string? Label { get; set; }
            public string? RecordType { get; set; }
            public string? SupportedService { get; set; }
            public Int32? Ttl { get; set; }
        }

        public DomainDnsRecord[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-list-serviceconfigurationrecords?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListServiceconfigurationrecordsResponse> DomainListServiceconfigurationrecordsAsync()
        {
            var p = new DomainListServiceconfigurationrecordsParameter();
            return await this.SendAsync<DomainListServiceconfigurationrecordsParameter, DomainListServiceconfigurationrecordsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-list-serviceconfigurationrecords?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListServiceconfigurationrecordsResponse> DomainListServiceconfigurationrecordsAsync(CancellationToken cancellationToken)
        {
            var p = new DomainListServiceconfigurationrecordsParameter();
            return await this.SendAsync<DomainListServiceconfigurationrecordsParameter, DomainListServiceconfigurationrecordsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-list-serviceconfigurationrecords?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListServiceconfigurationrecordsResponse> DomainListServiceconfigurationrecordsAsync(DomainListServiceconfigurationrecordsParameter parameter)
        {
            return await this.SendAsync<DomainListServiceconfigurationrecordsParameter, DomainListServiceconfigurationrecordsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/domain-list-serviceconfigurationrecords?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListServiceconfigurationrecordsResponse> DomainListServiceconfigurationrecordsAsync(DomainListServiceconfigurationrecordsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DomainListServiceconfigurationrecordsParameter, DomainListServiceconfigurationrecordsResponse>(parameter, cancellationToken);
        }
    }
}
