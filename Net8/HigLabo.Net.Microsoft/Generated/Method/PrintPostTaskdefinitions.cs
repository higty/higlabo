using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/print-post-taskdefinitions?view=graph-rest-1.0
/// </summary>
public partial class PrintPostTaskDefinitionsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Print_TaskDefinitions: return $"/print/taskDefinitions";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Print_TaskDefinitions,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public AppIdentity? CreatedBy { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public PrintTask[]? Tasks { get; set; }
}
public partial class PrintPostTaskDefinitionsResponse : RestApiResponse
{
    public AppIdentity? CreatedBy { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public PrintTask[]? Tasks { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/print-post-taskdefinitions?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-post-taskdefinitions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintPostTaskDefinitionsResponse> PrintPostTaskDefinitionsAsync()
    {
        var p = new PrintPostTaskDefinitionsParameter();
        return await this.SendAsync<PrintPostTaskDefinitionsParameter, PrintPostTaskDefinitionsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-post-taskdefinitions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintPostTaskDefinitionsResponse> PrintPostTaskDefinitionsAsync(CancellationToken cancellationToken)
    {
        var p = new PrintPostTaskDefinitionsParameter();
        return await this.SendAsync<PrintPostTaskDefinitionsParameter, PrintPostTaskDefinitionsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-post-taskdefinitions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintPostTaskDefinitionsResponse> PrintPostTaskDefinitionsAsync(PrintPostTaskDefinitionsParameter parameter)
    {
        return await this.SendAsync<PrintPostTaskDefinitionsParameter, PrintPostTaskDefinitionsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-post-taskdefinitions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintPostTaskDefinitionsResponse> PrintPostTaskDefinitionsAsync(PrintPostTaskDefinitionsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PrintPostTaskDefinitionsParameter, PrintPostTaskDefinitionsResponse>(parameter, cancellationToken);
    }
}
