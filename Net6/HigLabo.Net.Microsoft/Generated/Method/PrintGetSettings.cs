using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-get-settings?view=graph-rest-1.0
    /// </summary>
    public partial class PrintGetSettingsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Settings: return $"/print/settings";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Settings,
            Connectors,
            Operations,
            Printers,
            Services,
            Shares,
            TaskDefinitions,
        }
        public enum ApiPath
        {
            Print_Settings,
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
    public partial class PrintGetSettingsResponse : RestApiResponse
    {
        public bool? DocumentConversionEnabled { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-get-settings?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-get-settings?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintGetSettingsResponse> PrintGetSettingsAsync()
        {
            var p = new PrintGetSettingsParameter();
            return await this.SendAsync<PrintGetSettingsParameter, PrintGetSettingsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-get-settings?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintGetSettingsResponse> PrintGetSettingsAsync(CancellationToken cancellationToken)
        {
            var p = new PrintGetSettingsParameter();
            return await this.SendAsync<PrintGetSettingsParameter, PrintGetSettingsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-get-settings?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintGetSettingsResponse> PrintGetSettingsAsync(PrintGetSettingsParameter parameter)
        {
            return await this.SendAsync<PrintGetSettingsParameter, PrintGetSettingsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-get-settings?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintGetSettingsResponse> PrintGetSettingsAsync(PrintGetSettingsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintGetSettingsParameter, PrintGetSettingsResponse>(parameter, cancellationToken);
        }
    }
}
