using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/application-list-tokenissuancepolicies?view=graph-rest-1.0
/// </summary>
public partial class ApplicationListTokenissuancepoliciesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Applications_Id_TokenIssuancePolicies: return $"/applications/{Id}/tokenIssuancePolicies";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
        Definition,
        Description,
        DisplayName,
        Id,
        IsOrganizationDefault,
        AppliesTo,
    }
    public enum ApiPath
    {
        Applications_Id_TokenIssuancePolicies,
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
public partial class ApplicationListTokenissuancepoliciesResponse : RestApiResponse
{
    public TokenIssuancePolicy[]? Value { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/application-list-tokenissuancepolicies?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list-tokenissuancepolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationListTokenissuancepoliciesResponse> ApplicationListTokenissuancepoliciesAsync()
    {
        var p = new ApplicationListTokenissuancepoliciesParameter();
        return await this.SendAsync<ApplicationListTokenissuancepoliciesParameter, ApplicationListTokenissuancepoliciesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list-tokenissuancepolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationListTokenissuancepoliciesResponse> ApplicationListTokenissuancepoliciesAsync(CancellationToken cancellationToken)
    {
        var p = new ApplicationListTokenissuancepoliciesParameter();
        return await this.SendAsync<ApplicationListTokenissuancepoliciesParameter, ApplicationListTokenissuancepoliciesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list-tokenissuancepolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationListTokenissuancepoliciesResponse> ApplicationListTokenissuancepoliciesAsync(ApplicationListTokenissuancepoliciesParameter parameter)
    {
        return await this.SendAsync<ApplicationListTokenissuancepoliciesParameter, ApplicationListTokenissuancepoliciesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list-tokenissuancepolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationListTokenissuancepoliciesResponse> ApplicationListTokenissuancepoliciesAsync(ApplicationListTokenissuancepoliciesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ApplicationListTokenissuancepoliciesParameter, ApplicationListTokenissuancepoliciesResponse>(parameter, cancellationToken);
    }
}
