using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/extensionproperty-delete?view=graph-rest-1.0
/// </summary>
public partial class ExtensionpropertyDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ApplicationObjectId { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Applications_ApplicationObjectId_ExtensionProperties_Id: return $"/applications/{ApplicationObjectId}/extensionProperties/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Applications_ApplicationObjectId_ExtensionProperties_Id,
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
public partial class ExtensionpropertyDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/extensionproperty-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/extensionproperty-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ExtensionpropertyDeleteResponse> ExtensionpropertyDeleteAsync()
    {
        var p = new ExtensionpropertyDeleteParameter();
        return await this.SendAsync<ExtensionpropertyDeleteParameter, ExtensionpropertyDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/extensionproperty-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ExtensionpropertyDeleteResponse> ExtensionpropertyDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new ExtensionpropertyDeleteParameter();
        return await this.SendAsync<ExtensionpropertyDeleteParameter, ExtensionpropertyDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/extensionproperty-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ExtensionpropertyDeleteResponse> ExtensionpropertyDeleteAsync(ExtensionpropertyDeleteParameter parameter)
    {
        return await this.SendAsync<ExtensionpropertyDeleteParameter, ExtensionpropertyDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/extensionproperty-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ExtensionpropertyDeleteResponse> ExtensionpropertyDeleteAsync(ExtensionpropertyDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ExtensionpropertyDeleteParameter, ExtensionpropertyDeleteResponse>(parameter, cancellationToken);
    }
}
