using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryobject-getavailableextensionproperties?view=graph-rest-1.0
/// </summary>
public partial class DirectoryObjectGetavailableExtensionpropertiesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.DirectoryObjects_GetAvailableExtensionProperties: return $"/directoryObjects/getAvailableExtensionProperties";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        DirectoryObjects_GetAvailableExtensionProperties,
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
    public bool? IsSyncedFromOnPremises { get; set; }
}
public partial class DirectoryObjectGetavailableExtensionpropertiesResponse : RestApiResponse<ExtensionProperty>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryobject-getavailableextensionproperties?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-getavailableextensionproperties?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryObjectGetavailableExtensionpropertiesResponse> DirectoryObjectGetavailableExtensionpropertiesAsync()
    {
        var p = new DirectoryObjectGetavailableExtensionpropertiesParameter();
        return await this.SendAsync<DirectoryObjectGetavailableExtensionpropertiesParameter, DirectoryObjectGetavailableExtensionpropertiesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-getavailableextensionproperties?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryObjectGetavailableExtensionpropertiesResponse> DirectoryObjectGetavailableExtensionpropertiesAsync(CancellationToken cancellationToken)
    {
        var p = new DirectoryObjectGetavailableExtensionpropertiesParameter();
        return await this.SendAsync<DirectoryObjectGetavailableExtensionpropertiesParameter, DirectoryObjectGetavailableExtensionpropertiesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-getavailableextensionproperties?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryObjectGetavailableExtensionpropertiesResponse> DirectoryObjectGetavailableExtensionpropertiesAsync(DirectoryObjectGetavailableExtensionpropertiesParameter parameter)
    {
        return await this.SendAsync<DirectoryObjectGetavailableExtensionpropertiesParameter, DirectoryObjectGetavailableExtensionpropertiesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-getavailableextensionproperties?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryObjectGetavailableExtensionpropertiesResponse> DirectoryObjectGetavailableExtensionpropertiesAsync(DirectoryObjectGetavailableExtensionpropertiesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DirectoryObjectGetavailableExtensionpropertiesParameter, DirectoryObjectGetavailableExtensionpropertiesResponse>(parameter, cancellationToken);
    }
}
