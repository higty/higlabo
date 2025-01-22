using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/outlookuser-supportedlanguages?view=graph-rest-1.0
/// </summary>
public partial class OutlookUserSupportedlanguagesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Outlook_SupportedLanguages: return $"/me/outlook/supportedLanguages";
                case ApiPath.Users_IdOruserPrincipalName_Outlook_SupportedLanguages: return $"/users/{IdOrUserPrincipalName}/outlook/supportedLanguages";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Outlook_SupportedLanguages,
        Users_IdOruserPrincipalName_Outlook_SupportedLanguages,
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
public partial class OutlookUserSupportedlanguagesResponse : RestApiResponse<LocaleInfo>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/outlookuser-supportedlanguages?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-supportedlanguages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OutlookUserSupportedlanguagesResponse> OutlookUserSupportedlanguagesAsync()
    {
        var p = new OutlookUserSupportedlanguagesParameter();
        return await this.SendAsync<OutlookUserSupportedlanguagesParameter, OutlookUserSupportedlanguagesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-supportedlanguages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OutlookUserSupportedlanguagesResponse> OutlookUserSupportedlanguagesAsync(CancellationToken cancellationToken)
    {
        var p = new OutlookUserSupportedlanguagesParameter();
        return await this.SendAsync<OutlookUserSupportedlanguagesParameter, OutlookUserSupportedlanguagesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-supportedlanguages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OutlookUserSupportedlanguagesResponse> OutlookUserSupportedlanguagesAsync(OutlookUserSupportedlanguagesParameter parameter)
    {
        return await this.SendAsync<OutlookUserSupportedlanguagesParameter, OutlookUserSupportedlanguagesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-supportedlanguages?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OutlookUserSupportedlanguagesResponse> OutlookUserSupportedlanguagesAsync(OutlookUserSupportedlanguagesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<OutlookUserSupportedlanguagesParameter, OutlookUserSupportedlanguagesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-supportedlanguages?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<LocaleInfo> OutlookUserSupportedlanguagesEnumerateAsync(OutlookUserSupportedlanguagesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<OutlookUserSupportedlanguagesParameter, OutlookUserSupportedlanguagesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<LocaleInfo>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
