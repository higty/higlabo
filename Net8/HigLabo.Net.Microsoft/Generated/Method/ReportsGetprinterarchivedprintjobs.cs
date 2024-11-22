using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reports-getprinterarchivedprintjobs?view=graph-rest-1.0
/// </summary>
public partial class ReportsGetprinterArchivedprintJobsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_GetPrinterArchivedPrintJobs: return $"/reports/getPrinterArchivedPrintJobs";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_GetPrinterArchivedPrintJobs,
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
public partial class ReportsGetprinterArchivedprintJobsResponse : RestApiResponse<ArchivedPrintJob>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reports-getprinterarchivedprintjobs?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reports-getprinterarchivedprintjobs?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportsGetprinterArchivedprintJobsResponse> ReportsGetprinterArchivedprintJobsAsync()
    {
        var p = new ReportsGetprinterArchivedprintJobsParameter();
        return await this.SendAsync<ReportsGetprinterArchivedprintJobsParameter, ReportsGetprinterArchivedprintJobsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reports-getprinterarchivedprintjobs?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportsGetprinterArchivedprintJobsResponse> ReportsGetprinterArchivedprintJobsAsync(CancellationToken cancellationToken)
    {
        var p = new ReportsGetprinterArchivedprintJobsParameter();
        return await this.SendAsync<ReportsGetprinterArchivedprintJobsParameter, ReportsGetprinterArchivedprintJobsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reports-getprinterarchivedprintjobs?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportsGetprinterArchivedprintJobsResponse> ReportsGetprinterArchivedprintJobsAsync(ReportsGetprinterArchivedprintJobsParameter parameter)
    {
        return await this.SendAsync<ReportsGetprinterArchivedprintJobsParameter, ReportsGetprinterArchivedprintJobsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reports-getprinterarchivedprintjobs?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportsGetprinterArchivedprintJobsResponse> ReportsGetprinterArchivedprintJobsAsync(ReportsGetprinterArchivedprintJobsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportsGetprinterArchivedprintJobsParameter, ReportsGetprinterArchivedprintJobsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reports-getprinterarchivedprintjobs?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ArchivedPrintJob> ReportsGetprinterArchivedprintJobsEnumerateAsync(ReportsGetprinterArchivedprintJobsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ReportsGetprinterArchivedprintJobsParameter, ReportsGetprinterArchivedprintJobsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ArchivedPrintJob>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
