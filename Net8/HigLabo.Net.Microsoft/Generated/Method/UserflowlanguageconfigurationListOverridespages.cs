using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-overridespages?view=graph-rest-1.0
/// </summary>
public partial class UserflowlanguageConfigurationListOverridesPagesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? B2xUserFlowsId { get; set; }
        public string? LanguagesId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Identity_B2xUserFlows_Id_Languages_Id_OverridesPages: return $"/identity/b2xUserFlows/{B2xUserFlowsId}/languages/{LanguagesId}/overridesPages";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Identity_B2xUserFlows_Id_Languages_Id_OverridesPages,
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
public partial class UserflowlanguageConfigurationListOverridesPagesResponse : RestApiResponse<UserFlowLanguagePage>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-overridespages?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-overridespages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserflowlanguageConfigurationListOverridesPagesResponse> UserflowlanguageConfigurationListOverridesPagesAsync()
    {
        var p = new UserflowlanguageConfigurationListOverridesPagesParameter();
        return await this.SendAsync<UserflowlanguageConfigurationListOverridesPagesParameter, UserflowlanguageConfigurationListOverridesPagesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-overridespages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserflowlanguageConfigurationListOverridesPagesResponse> UserflowlanguageConfigurationListOverridesPagesAsync(CancellationToken cancellationToken)
    {
        var p = new UserflowlanguageConfigurationListOverridesPagesParameter();
        return await this.SendAsync<UserflowlanguageConfigurationListOverridesPagesParameter, UserflowlanguageConfigurationListOverridesPagesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-overridespages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserflowlanguageConfigurationListOverridesPagesResponse> UserflowlanguageConfigurationListOverridesPagesAsync(UserflowlanguageConfigurationListOverridesPagesParameter parameter)
    {
        return await this.SendAsync<UserflowlanguageConfigurationListOverridesPagesParameter, UserflowlanguageConfigurationListOverridesPagesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-overridespages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserflowlanguageConfigurationListOverridesPagesResponse> UserflowlanguageConfigurationListOverridesPagesAsync(UserflowlanguageConfigurationListOverridesPagesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UserflowlanguageConfigurationListOverridesPagesParameter, UserflowlanguageConfigurationListOverridesPagesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-list-overridespages?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<UserFlowLanguagePage> UserflowlanguageConfigurationListOverridesPagesEnumerateAsync(UserflowlanguageConfigurationListOverridesPagesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<UserflowlanguageConfigurationListOverridesPagesParameter, UserflowlanguageConfigurationListOverridesPagesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<UserFlowLanguagePage>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
