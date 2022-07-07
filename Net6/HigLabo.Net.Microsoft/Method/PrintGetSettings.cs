using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintGetSettingsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
            Settings,
        }
        public enum ApiPath
        {
            Print_Settings,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Settings: return $"/print/settings";
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
    public partial class PrintGetSettingsResponse : RestApiResponse
    {
        public bool? DocumentConversionEnabled { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-get-settings?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintGetSettingsResponse> PrintGetSettingsAsync()
        {
            var p = new PrintGetSettingsParameter();
            return await this.SendAsync<PrintGetSettingsParameter, PrintGetSettingsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-get-settings?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintGetSettingsResponse> PrintGetSettingsAsync(CancellationToken cancellationToken)
        {
            var p = new PrintGetSettingsParameter();
            return await this.SendAsync<PrintGetSettingsParameter, PrintGetSettingsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-get-settings?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintGetSettingsResponse> PrintGetSettingsAsync(PrintGetSettingsParameter parameter)
        {
            return await this.SendAsync<PrintGetSettingsParameter, PrintGetSettingsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-get-settings?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintGetSettingsResponse> PrintGetSettingsAsync(PrintGetSettingsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintGetSettingsParameter, PrintGetSettingsResponse>(parameter, cancellationToken);
        }
    }
}
