using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-list-agreementacceptances?view=graph-rest-1.0
/// </summary>
public partial class UserListAgreementAcceptancesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_AgreementAcceptances: return $"/me/agreementAcceptances";
                case ApiPath.Users_IdOrUserPrincipalName_AgreementAcceptances: return $"/users/{IdOrUserPrincipalName}/agreementAcceptances";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_AgreementAcceptances,
        Users_IdOrUserPrincipalName_AgreementAcceptances,
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
public partial class UserListAgreementAcceptancesResponse : RestApiResponse<AgreementAcceptance>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-list-agreementacceptances?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-agreementacceptances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListAgreementAcceptancesResponse> UserListAgreementAcceptancesAsync()
    {
        var p = new UserListAgreementAcceptancesParameter();
        return await this.SendAsync<UserListAgreementAcceptancesParameter, UserListAgreementAcceptancesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-agreementacceptances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListAgreementAcceptancesResponse> UserListAgreementAcceptancesAsync(CancellationToken cancellationToken)
    {
        var p = new UserListAgreementAcceptancesParameter();
        return await this.SendAsync<UserListAgreementAcceptancesParameter, UserListAgreementAcceptancesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-agreementacceptances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListAgreementAcceptancesResponse> UserListAgreementAcceptancesAsync(UserListAgreementAcceptancesParameter parameter)
    {
        return await this.SendAsync<UserListAgreementAcceptancesParameter, UserListAgreementAcceptancesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-agreementacceptances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserListAgreementAcceptancesResponse> UserListAgreementAcceptancesAsync(UserListAgreementAcceptancesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UserListAgreementAcceptancesParameter, UserListAgreementAcceptancesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-agreementacceptances?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AgreementAcceptance> UserListAgreementAcceptancesEnumerateAsync(UserListAgreementAcceptancesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<UserListAgreementAcceptancesParameter, UserListAgreementAcceptancesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<AgreementAcceptance>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
