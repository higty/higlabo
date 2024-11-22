using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/outlookuser-post-mastercategories?view=graph-rest-1.0
/// </summary>
public partial class OutlookUserPostMasterCategoriesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Outlook_MasterCategories: return $"/me/outlook/masterCategories";
                case ApiPath.Users_IdOruserPrincipalName_Outlook_MasterCategories: return $"/users/{IdOrUserPrincipalName}/outlook/masterCategories";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_Outlook_MasterCategories,
        Users_IdOruserPrincipalName_Outlook_MasterCategories,
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
    public string? Color { get; set; }
    public string? DisplayName { get; set; }
}
public partial class OutlookUserPostMasterCategoriesResponse : RestApiResponse
{
    public string? Color { get; set; }
    public string? DisplayName { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/outlookuser-post-mastercategories?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-post-mastercategories?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OutlookUserPostMasterCategoriesResponse> OutlookUserPostMasterCategoriesAsync()
    {
        var p = new OutlookUserPostMasterCategoriesParameter();
        return await this.SendAsync<OutlookUserPostMasterCategoriesParameter, OutlookUserPostMasterCategoriesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-post-mastercategories?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OutlookUserPostMasterCategoriesResponse> OutlookUserPostMasterCategoriesAsync(CancellationToken cancellationToken)
    {
        var p = new OutlookUserPostMasterCategoriesParameter();
        return await this.SendAsync<OutlookUserPostMasterCategoriesParameter, OutlookUserPostMasterCategoriesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-post-mastercategories?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OutlookUserPostMasterCategoriesResponse> OutlookUserPostMasterCategoriesAsync(OutlookUserPostMasterCategoriesParameter parameter)
    {
        return await this.SendAsync<OutlookUserPostMasterCategoriesParameter, OutlookUserPostMasterCategoriesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-post-mastercategories?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OutlookUserPostMasterCategoriesResponse> OutlookUserPostMasterCategoriesAsync(OutlookUserPostMasterCategoriesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<OutlookUserPostMasterCategoriesParameter, OutlookUserPostMasterCategoriesResponse>(parameter, cancellationToken);
    }
}
