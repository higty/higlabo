using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedgroups?view=graph-rest-1.0
    /// </summary>
    public partial class PrinterShareListAllowedGroupsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterShareId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Shares_PrinterShareId_AllowedGroups: return $"/print/shares/{PrinterShareId}/allowedGroups";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Shares_PrinterShareId_AllowedGroups,
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
    public partial class PrinterShareListAllowedGroupsResponse : RestApiResponse<Group>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedgroups?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedgroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterShareListAllowedGroupsResponse> PrinterShareListAllowedGroupsAsync()
        {
            var p = new PrinterShareListAllowedGroupsParameter();
            return await this.SendAsync<PrinterShareListAllowedGroupsParameter, PrinterShareListAllowedGroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedgroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterShareListAllowedGroupsResponse> PrinterShareListAllowedGroupsAsync(CancellationToken cancellationToken)
        {
            var p = new PrinterShareListAllowedGroupsParameter();
            return await this.SendAsync<PrinterShareListAllowedGroupsParameter, PrinterShareListAllowedGroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedgroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterShareListAllowedGroupsResponse> PrinterShareListAllowedGroupsAsync(PrinterShareListAllowedGroupsParameter parameter)
        {
            return await this.SendAsync<PrinterShareListAllowedGroupsParameter, PrinterShareListAllowedGroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedgroups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinterShareListAllowedGroupsResponse> PrinterShareListAllowedGroupsAsync(PrinterShareListAllowedGroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinterShareListAllowedGroupsParameter, PrinterShareListAllowedGroupsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedgroups?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Group> PrinterShareListAllowedGroupsEnumerateAsync(PrinterShareListAllowedGroupsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<PrinterShareListAllowedGroupsParameter, PrinterShareListAllowedGroupsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Group>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
