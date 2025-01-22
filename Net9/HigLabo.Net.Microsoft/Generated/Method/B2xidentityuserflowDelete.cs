using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete?view=graph-rest-1.0
/// </summary>
public partial class B2xidentityUserflowDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Identity_B2xUserFlows_Id: return $"/identity/b2xUserFlows/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Identity_B2xUserFlows_Id,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class B2xidentityUserflowDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<B2xidentityUserflowDeleteResponse> B2xidentityUserflowDeleteAsync()
    {
        var p = new B2xidentityUserflowDeleteParameter();
        return await this.SendAsync<B2xidentityUserflowDeleteParameter, B2xidentityUserflowDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<B2xidentityUserflowDeleteResponse> B2xidentityUserflowDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new B2xidentityUserflowDeleteParameter();
        return await this.SendAsync<B2xidentityUserflowDeleteParameter, B2xidentityUserflowDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<B2xidentityUserflowDeleteResponse> B2xidentityUserflowDeleteAsync(B2xidentityUserflowDeleteParameter parameter)
    {
        return await this.SendAsync<B2xidentityUserflowDeleteParameter, B2xidentityUserflowDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<B2xidentityUserflowDeleteResponse> B2xidentityUserflowDeleteAsync(B2xidentityUserflowDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<B2xidentityUserflowDeleteParameter, B2xidentityUserflowDeleteResponse>(parameter, cancellationToken);
    }
}
