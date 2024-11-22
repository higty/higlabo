using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/print-update-taskdefinition?view=graph-rest-1.0
/// </summary>
public partial class PrintUpdateTaskDefinitionParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? PrintTaskDefinitionId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Print_TaskDefinitions_PrintTaskDefinitionId: return $"/print/taskDefinitions/{PrintTaskDefinitionId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Print_TaskDefinitions_PrintTaskDefinitionId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public string? DisplayName { get; set; }
    public string? CreatedBy { get; set; }
}
public partial class PrintUpdateTaskDefinitionResponse : RestApiResponse
{
    public AppIdentity? CreatedBy { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public PrintTask[]? Tasks { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/print-update-taskdefinition?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-update-taskdefinition?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintUpdateTaskDefinitionResponse> PrintUpdateTaskDefinitionAsync()
    {
        var p = new PrintUpdateTaskDefinitionParameter();
        return await this.SendAsync<PrintUpdateTaskDefinitionParameter, PrintUpdateTaskDefinitionResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-update-taskdefinition?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintUpdateTaskDefinitionResponse> PrintUpdateTaskDefinitionAsync(CancellationToken cancellationToken)
    {
        var p = new PrintUpdateTaskDefinitionParameter();
        return await this.SendAsync<PrintUpdateTaskDefinitionParameter, PrintUpdateTaskDefinitionResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-update-taskdefinition?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintUpdateTaskDefinitionResponse> PrintUpdateTaskDefinitionAsync(PrintUpdateTaskDefinitionParameter parameter)
    {
        return await this.SendAsync<PrintUpdateTaskDefinitionParameter, PrintUpdateTaskDefinitionResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-update-taskdefinition?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PrintUpdateTaskDefinitionResponse> PrintUpdateTaskDefinitionAsync(PrintUpdateTaskDefinitionParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PrintUpdateTaskDefinitionParameter, PrintUpdateTaskDefinitionResponse>(parameter, cancellationToken);
    }
}
