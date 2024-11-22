using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-serviceprincipalriskdetections?view=graph-rest-1.0
/// </summary>
public partial class IdentityProtectionRootListServicePrincipalriskdetectionsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityProtection_ServicePrincipalRiskDetections: return $"/identityProtection/servicePrincipalRiskDetections";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityProtection_ServicePrincipalRiskDetections,
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
public partial class IdentityProtectionRootListServicePrincipalriskdetectionsResponse : RestApiResponse<ServicePrincipalRiskDetection>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-serviceprincipalriskdetections?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-serviceprincipalriskdetections?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProtectionRootListServicePrincipalriskdetectionsResponse> IdentityProtectionRootListServicePrincipalriskdetectionsAsync()
    {
        var p = new IdentityProtectionRootListServicePrincipalriskdetectionsParameter();
        return await this.SendAsync<IdentityProtectionRootListServicePrincipalriskdetectionsParameter, IdentityProtectionRootListServicePrincipalriskdetectionsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-serviceprincipalriskdetections?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProtectionRootListServicePrincipalriskdetectionsResponse> IdentityProtectionRootListServicePrincipalriskdetectionsAsync(CancellationToken cancellationToken)
    {
        var p = new IdentityProtectionRootListServicePrincipalriskdetectionsParameter();
        return await this.SendAsync<IdentityProtectionRootListServicePrincipalriskdetectionsParameter, IdentityProtectionRootListServicePrincipalriskdetectionsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-serviceprincipalriskdetections?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProtectionRootListServicePrincipalriskdetectionsResponse> IdentityProtectionRootListServicePrincipalriskdetectionsAsync(IdentityProtectionRootListServicePrincipalriskdetectionsParameter parameter)
    {
        return await this.SendAsync<IdentityProtectionRootListServicePrincipalriskdetectionsParameter, IdentityProtectionRootListServicePrincipalriskdetectionsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-serviceprincipalriskdetections?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProtectionRootListServicePrincipalriskdetectionsResponse> IdentityProtectionRootListServicePrincipalriskdetectionsAsync(IdentityProtectionRootListServicePrincipalriskdetectionsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<IdentityProtectionRootListServicePrincipalriskdetectionsParameter, IdentityProtectionRootListServicePrincipalriskdetectionsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprotectionroot-list-serviceprincipalriskdetections?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ServicePrincipalRiskDetection> IdentityProtectionRootListServicePrincipalriskdetectionsEnumerateAsync(IdentityProtectionRootListServicePrincipalriskdetectionsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<IdentityProtectionRootListServicePrincipalriskdetectionsParameter, IdentityProtectionRootListServicePrincipalriskdetectionsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ServicePrincipalRiskDetection>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
