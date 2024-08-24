using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedusers?view=graph-rest-1.0
    /// </summary>
    public partial class PrinterShareListAllowedUsersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterShareId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Shares_PrinterShareId_AllowedUsers: return $"/print/shares/{PrinterShareId}/allowedUsers";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Shares_PrinterShareId_AllowedUsers,
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
    public partial class PrinterShareListAllowedUsersResponse : RestApiResponse<User>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedusers?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedusers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterShareListAllowedUsersResponse> PrinterShareListAllowedUsersAsync()
        {
            var p = new PrinterShareListAllowedUsersParameter();
            return await this.SendAsync<PrinterShareListAllowedUsersParameter, PrinterShareListAllowedUsersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedusers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterShareListAllowedUsersResponse> PrinterShareListAllowedUsersAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterShareListAllowedUsersParameter();
            return await this.SendAsync<PrinterShareListAllowedUsersParameter, PrinterShareListAllowedUsersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedusers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterShareListAllowedUsersResponse> PrinterShareListAllowedUsersAsync(PrinterShareListAllowedUsersParameter parameter)
        {
            return await this.SendAsync<PrinterShareListAllowedUsersParameter, PrinterShareListAllowedUsersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedusers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterShareListAllowedUsersResponse> PrinterShareListAllowedUsersAsync(PrinterShareListAllowedUsersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterShareListAllowedUsersParameter, PrinterShareListAllowedUsersResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedusers?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<User> PrinterShareListAllowedUsersEnumerateAsync(PrinterShareListAllowedUsersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<PrinterShareListAllowedUsersParameter, PrinterShareListAllowedUsersResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<User>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
