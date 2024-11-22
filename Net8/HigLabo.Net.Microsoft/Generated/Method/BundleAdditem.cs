using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bundle-additem?view=graph-rest-1.0
/// </summary>
public partial class BundleAddItemParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? BundleId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Drive_Bundles_BundleId_Children: return $"/drive/bundles/{BundleId}/children";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Drive_Bundles_BundleId_Children,
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
public partial class BundleAddItemResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bundle-additem?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bundle-additem?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BundleAddItemResponse> BundleAddItemAsync()
    {
        var p = new BundleAddItemParameter();
        return await this.SendAsync<BundleAddItemParameter, BundleAddItemResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bundle-additem?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BundleAddItemResponse> BundleAddItemAsync(CancellationToken cancellationToken)
    {
        var p = new BundleAddItemParameter();
        return await this.SendAsync<BundleAddItemParameter, BundleAddItemResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bundle-additem?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BundleAddItemResponse> BundleAddItemAsync(BundleAddItemParameter parameter)
    {
        return await this.SendAsync<BundleAddItemParameter, BundleAddItemResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bundle-additem?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BundleAddItemResponse> BundleAddItemAsync(BundleAddItemParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BundleAddItemParameter, BundleAddItemResponse>(parameter, cancellationToken);
    }
}
