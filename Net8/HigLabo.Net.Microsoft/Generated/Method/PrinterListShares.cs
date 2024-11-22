using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printer-list-shares?view=graph-rest-1.0
/// </summary>
public partial class PrinterListSharesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? PrinterId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Print_Printers_PrinterId_Shares: return $"/print/printers/{PrinterId}/shares";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Print_Printers_PrinterId_Shares,
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
public partial class PrinterListSharesResponse : RestApiResponse<PrinterShare>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/printer-list-shares?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-list-shares?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterListSharesResponse> PrinterListSharesAsync()
    {
        var p = new PrinterListSharesParameter();
        return await this.SendAsync<PrinterListSharesParameter, PrinterListSharesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-list-shares?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterListSharesResponse> PrinterListSharesAsync(CancellationToken cancellationToken)
    {
        var p = new PrinterListSharesParameter();
        return await this.SendAsync<PrinterListSharesParameter, PrinterListSharesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-list-shares?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterListSharesResponse> PrinterListSharesAsync(PrinterListSharesParameter parameter)
    {
        return await this.SendAsync<PrinterListSharesParameter, PrinterListSharesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-list-shares?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrinterListSharesResponse> PrinterListSharesAsync(PrinterListSharesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PrinterListSharesParameter, PrinterListSharesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printer-list-shares?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<PrinterShare> PrinterListSharesEnumerateAsync(PrinterListSharesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<PrinterListSharesParameter, PrinterListSharesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<PrinterShare>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
