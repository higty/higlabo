using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintConnectorGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string PrintConnectorId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Connectors_PrintConnectorId: return $"/print/connectors/{PrintConnectorId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            DisplayName,
            FullyQualifiedDomainName,
            OperatingSystem,
            AppVersion,
            Location,
            RegisteredDateTime,
            RegisteredBy,
        }
        public enum ApiPath
        {
            Print_Connectors_PrintConnectorId,
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
    public partial class PrintConnectorGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? FullyQualifiedDomainName { get; set; }
        public string? OperatingSystem { get; set; }
        public string? AppVersion { get; set; }
        public PrinterLocation? Location { get; set; }
        public DateTimeOffset? RegisteredDateTime { get; set; }
        public UserIdentity? RegisteredBy { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintConnectorGetResponse> PrintConnectorGetAsync()
        {
            var p = new PrintConnectorGetParameter();
            return await this.SendAsync<PrintConnectorGetParameter, PrintConnectorGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintConnectorGetResponse> PrintConnectorGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrintConnectorGetParameter();
            return await this.SendAsync<PrintConnectorGetParameter, PrintConnectorGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintConnectorGetResponse> PrintConnectorGetAsync(PrintConnectorGetParameter parameter)
        {
            return await this.SendAsync<PrintConnectorGetParameter, PrintConnectorGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintConnectorGetResponse> PrintConnectorGetAsync(PrintConnectorGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintConnectorGetParameter, PrintConnectorGetResponse>(parameter, cancellationToken);
        }
    }
}
