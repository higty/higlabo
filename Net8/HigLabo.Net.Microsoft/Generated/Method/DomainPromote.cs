using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/domain-promote?view=graph-rest-1.0
/// </summary>
public partial class DomainPromoteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Domains_Id_Promote: return $"/domains/{Id}/promote";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Domains_Id_Promote,
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
}
public partial class DomainPromoteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/domain-promote?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-promote?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DomainPromoteResponse> DomainPromoteAsync()
    {
        var p = new DomainPromoteParameter();
        return await this.SendAsync<DomainPromoteParameter, DomainPromoteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-promote?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DomainPromoteResponse> DomainPromoteAsync(CancellationToken cancellationToken)
    {
        var p = new DomainPromoteParameter();
        return await this.SendAsync<DomainPromoteParameter, DomainPromoteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-promote?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DomainPromoteResponse> DomainPromoteAsync(DomainPromoteParameter parameter)
    {
        return await this.SendAsync<DomainPromoteParameter, DomainPromoteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-promote?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DomainPromoteResponse> DomainPromoteAsync(DomainPromoteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DomainPromoteParameter, DomainPromoteResponse>(parameter, cancellationToken);
    }
}
