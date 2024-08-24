using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-services?view=graph-rest-1.0
    /// </summary>
    public partial class PrintListServicesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Services: return $"/print/services";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Services,
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
    public partial class PrintListServicesResponse : RestApiResponse<PrintService>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-services?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-services?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListServicesResponse> PrintListServicesAsync()
        {
            var p = new PrintListServicesParameter();
            return await this.SendAsync<PrintListServicesParameter, PrintListServicesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-services?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListServicesResponse> PrintListServicesAsync(CancellationToken cancellationToken)
        {
            var p = new PrintListServicesParameter();
            return await this.SendAsync<PrintListServicesParameter, PrintListServicesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-services?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListServicesResponse> PrintListServicesAsync(PrintListServicesParameter parameter)
        {
            return await this.SendAsync<PrintListServicesParameter, PrintListServicesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-services?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListServicesResponse> PrintListServicesAsync(PrintListServicesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintListServicesParameter, PrintListServicesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-services?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<PrintService> PrintListServicesEnumerateAsync(PrintListServicesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<PrintListServicesParameter, PrintListServicesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<PrintService>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
