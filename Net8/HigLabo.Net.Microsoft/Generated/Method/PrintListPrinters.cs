using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
/// </summary>
public partial class PrintListPrintersParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Print_Printers: return $"/print/printers";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Print_Printers,
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
public partial class PrintListPrintersResponse : RestApiResponse<Printer>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintListPrintersResponse> PrintListPrintersAsync()
    {
        var p = new PrintListPrintersParameter();
        return await this.SendAsync<PrintListPrintersParameter, PrintListPrintersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintListPrintersResponse> PrintListPrintersAsync(CancellationToken cancellationToken)
    {
        var p = new PrintListPrintersParameter();
        return await this.SendAsync<PrintListPrintersParameter, PrintListPrintersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintListPrintersResponse> PrintListPrintersAsync(PrintListPrintersParameter parameter)
    {
        return await this.SendAsync<PrintListPrintersParameter, PrintListPrintersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintListPrintersResponse> PrintListPrintersAsync(PrintListPrintersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PrintListPrintersParameter, PrintListPrintersResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-printers?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Printer> PrintListPrintersEnumerateAsync(PrintListPrintersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<PrintListPrintersParameter, PrintListPrintersResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Printer>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
