using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-connectors?view=graph-rest-1.0
    /// </summary>
    public partial class PrintListConnectorsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Connectors: return $"/print/connectors";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AppVersion,
            DisplayName,
            FullyQualifiedDomainName,
            Id,
            Location,
            OperatingSystem,
            RegisteredBy,
            RegisteredDateTime,
        }
        public enum ApiPath
        {
            Print_Connectors,
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
    public partial class PrintListConnectorsResponse : RestApiResponse
    {
        public PrintConnector[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-connectors?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListConnectorsResponse> PrintListConnectorsAsync()
        {
            var p = new PrintListConnectorsParameter();
            return await this.SendAsync<PrintListConnectorsParameter, PrintListConnectorsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListConnectorsResponse> PrintListConnectorsAsync(CancellationToken cancellationToken)
        {
            var p = new PrintListConnectorsParameter();
            return await this.SendAsync<PrintListConnectorsParameter, PrintListConnectorsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListConnectorsResponse> PrintListConnectorsAsync(PrintListConnectorsParameter parameter)
        {
            return await this.SendAsync<PrintListConnectorsParameter, PrintListConnectorsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-connectors?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListConnectorsResponse> PrintListConnectorsAsync(PrintListConnectorsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintListConnectorsParameter, PrintListConnectorsResponse>(parameter, cancellationToken);
        }
    }
}
