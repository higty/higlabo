using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/application-list-extensionproperty?view=graph-rest-1.0
/// </summary>
public partial class ApplicationListExtensionpropertyParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ApplicationObjectId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Applications_ApplicationObjectId_ExtensionProperties: return $"/applications/{ApplicationObjectId}/extensionProperties";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Applications_ApplicationObjectId_ExtensionProperties,
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
public partial class ApplicationListExtensionpropertyResponse : RestApiResponse<ExtensionProperty>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/application-list-extensionproperty?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list-extensionproperty?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationListExtensionpropertyResponse> ApplicationListExtensionpropertyAsync()
    {
        var p = new ApplicationListExtensionpropertyParameter();
        return await this.SendAsync<ApplicationListExtensionpropertyParameter, ApplicationListExtensionpropertyResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list-extensionproperty?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationListExtensionpropertyResponse> ApplicationListExtensionpropertyAsync(CancellationToken cancellationToken)
    {
        var p = new ApplicationListExtensionpropertyParameter();
        return await this.SendAsync<ApplicationListExtensionpropertyParameter, ApplicationListExtensionpropertyResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list-extensionproperty?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationListExtensionpropertyResponse> ApplicationListExtensionpropertyAsync(ApplicationListExtensionpropertyParameter parameter)
    {
        return await this.SendAsync<ApplicationListExtensionpropertyParameter, ApplicationListExtensionpropertyResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list-extensionproperty?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationListExtensionpropertyResponse> ApplicationListExtensionpropertyAsync(ApplicationListExtensionpropertyParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ApplicationListExtensionpropertyParameter, ApplicationListExtensionpropertyResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list-extensionproperty?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ExtensionProperty> ApplicationListExtensionpropertyEnumerateAsync(ApplicationListExtensionpropertyParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ApplicationListExtensionpropertyParameter, ApplicationListExtensionpropertyResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ExtensionProperty>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
