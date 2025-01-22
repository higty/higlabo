using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyuser?view=graph-rest-1.0
/// </summary>
public partial class ReportRootListMonthlyprintusagebyUserParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Reports_MonthlyPrintUsageByUser: return $"/reports/monthlyPrintUsageByUser";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Reports_MonthlyPrintUsageByUser,
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
public partial class ReportRootListMonthlyprintusagebyUserResponse : RestApiResponse<PrintUsageByUser>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyuser?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootListMonthlyprintusagebyUserResponse> ReportRootListMonthlyprintusagebyUserAsync()
    {
        var p = new ReportRootListMonthlyprintusagebyUserParameter();
        return await this.SendAsync<ReportRootListMonthlyprintusagebyUserParameter, ReportRootListMonthlyprintusagebyUserResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootListMonthlyprintusagebyUserResponse> ReportRootListMonthlyprintusagebyUserAsync(CancellationToken cancellationToken)
    {
        var p = new ReportRootListMonthlyprintusagebyUserParameter();
        return await this.SendAsync<ReportRootListMonthlyprintusagebyUserParameter, ReportRootListMonthlyprintusagebyUserResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootListMonthlyprintusagebyUserResponse> ReportRootListMonthlyprintusagebyUserAsync(ReportRootListMonthlyprintusagebyUserParameter parameter)
    {
        return await this.SendAsync<ReportRootListMonthlyprintusagebyUserParameter, ReportRootListMonthlyprintusagebyUserResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyuser?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ReportRootListMonthlyprintusagebyUserResponse> ReportRootListMonthlyprintusagebyUserAsync(ReportRootListMonthlyprintusagebyUserParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ReportRootListMonthlyprintusagebyUserParameter, ReportRootListMonthlyprintusagebyUserResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-list-monthlyprintusagebyuser?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<PrintUsageByUser> ReportRootListMonthlyprintusagebyUserEnumerateAsync(ReportRootListMonthlyprintusagebyUserParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ReportRootListMonthlyprintusagebyUserParameter, ReportRootListMonthlyprintusagebyUserResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<PrintUsageByUser>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
