using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-list-serviceconfigurationrecords?view=graph-rest-1.0
    /// </summary>
    public partial class DomainListServiceConfigurationrecordsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Domains_Id_ServiceConfigurationRecords: return $"/domains/{Id}/serviceConfigurationRecords";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Domains_Id_ServiceConfigurationRecords,
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
    public partial class DomainListServiceConfigurationrecordsResponse : RestApiResponse
    {
        public DomainDnsRecord[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-list-serviceconfigurationrecords?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-list-serviceconfigurationrecords?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListServiceConfigurationrecordsResponse> DomainListServiceConfigurationrecordsAsync()
        {
            var p = new DomainListServiceConfigurationrecordsParameter();
            return await this.SendAsync<DomainListServiceConfigurationrecordsParameter, DomainListServiceConfigurationrecordsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-list-serviceconfigurationrecords?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListServiceConfigurationrecordsResponse> DomainListServiceConfigurationrecordsAsync(CancellationToken cancellationToken)
        {
            var p = new DomainListServiceConfigurationrecordsParameter();
            return await this.SendAsync<DomainListServiceConfigurationrecordsParameter, DomainListServiceConfigurationrecordsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-list-serviceconfigurationrecords?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListServiceConfigurationrecordsResponse> DomainListServiceConfigurationrecordsAsync(DomainListServiceConfigurationrecordsParameter parameter)
        {
            return await this.SendAsync<DomainListServiceConfigurationrecordsParameter, DomainListServiceConfigurationrecordsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-list-serviceconfigurationrecords?view=graph-rest-1.0
        /// </summary>
        public async Task<DomainListServiceConfigurationrecordsResponse> DomainListServiceConfigurationrecordsAsync(DomainListServiceConfigurationrecordsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DomainListServiceConfigurationrecordsParameter, DomainListServiceConfigurationrecordsResponse>(parameter, cancellationToken);
        }
    }
}
