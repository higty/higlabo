using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/page-copytosection?view=graph-rest-1.0
/// </summary>
public partial class PageCopytosectionParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? IdOrUserPrincipalName { get; set; }
        public string? GroupsId { get; set; }
        public string? PagesId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Onenote_Pages_Id_CopyToSection: return $"/me/onenote/pages/{Id}/copyToSection";
                case ApiPath.Users_IdOrUserPrincipalName_Onenote_Pages_Id_CopyToSection: return $"/users/{IdOrUserPrincipalName}/onenote/pages/{Id}/copyToSection";
                case ApiPath.Groups_Id_Onenote_Pages_Id_CopyToSection: return $"/groups/{GroupsId}/onenote/pages/{PagesId}/copyToSection";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_Onenote_Pages_Id_CopyToSection,
        Users_IdOrUserPrincipalName_Onenote_Pages_Id_CopyToSection,
        Groups_Id_Onenote_Pages_Id_CopyToSection,
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
    public string? GroupId { get; set; }
    public string? Id { get; set; }
}
public partial class PageCopytosectionResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/page-copytosection?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/page-copytosection?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PageCopytosectionResponse> PageCopytosectionAsync()
    {
        var p = new PageCopytosectionParameter();
        return await this.SendAsync<PageCopytosectionParameter, PageCopytosectionResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/page-copytosection?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PageCopytosectionResponse> PageCopytosectionAsync(CancellationToken cancellationToken)
    {
        var p = new PageCopytosectionParameter();
        return await this.SendAsync<PageCopytosectionParameter, PageCopytosectionResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/page-copytosection?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PageCopytosectionResponse> PageCopytosectionAsync(PageCopytosectionParameter parameter)
    {
        return await this.SendAsync<PageCopytosectionParameter, PageCopytosectionResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/page-copytosection?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PageCopytosectionResponse> PageCopytosectionAsync(PageCopytosectionParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PageCopytosectionParameter, PageCopytosectionResponse>(parameter, cancellationToken);
    }
}
