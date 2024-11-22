using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyprinter?view=graph-rest-1.0
/// </summary>
public partial class ReportRootListDailyprintusagebyprinterParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_DailyPrintUsageByPrinter: return $"/reports/dailyPrintUsageByPrinter";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_DailyPrintUsageByPrinter,
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
public partial class ReportRootListDailyprintusagebyprinterResponse : RestApiResponse<PrintUsageByPrinter>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyprinter?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyprinter?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootListDailyprintusagebyprinterResponse> ReportRootListDailyprintusagebyprinterAsync()
    {
        var p = new ReportRootListDailyprintusagebyprinterParameter();
        return await this.SendAsync<ReportRootListDailyprintusagebyprinterParameter, ReportRootListDailyprintusagebyprinterResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyprinter?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootListDailyprintusagebyprinterResponse> ReportRootListDailyprintusagebyprinterAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootListDailyprintusagebyprinterParameter();
        return await this.SendAsync<ReportRootListDailyprintusagebyprinterParameter, ReportRootListDailyprintusagebyprinterResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyprinter?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootListDailyprintusagebyprinterResponse> ReportRootListDailyprintusagebyprinterAsync(ReportRootListDailyprintusagebyprinterParameter parameter)
    {
        return await this.SendAsync<ReportRootListDailyprintusagebyprinterParameter, ReportRootListDailyprintusagebyprinterResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyprinter?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootListDailyprintusagebyprinterResponse> ReportRootListDailyprintusagebyprinterAsync(ReportRootListDailyprintusagebyprinterParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootListDailyprintusagebyprinterParameter, ReportRootListDailyprintusagebyprinterResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-list-dailyprintusagebyprinter?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<PrintUsageByPrinter> ReportRootListDailyprintusagebyprinterEnumerateAsync(ReportRootListDailyprintusagebyprinterParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ReportRootListDailyprintusagebyprinterParameter, ReportRootListDailyprintusagebyprinterResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<PrintUsageByPrinter>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
