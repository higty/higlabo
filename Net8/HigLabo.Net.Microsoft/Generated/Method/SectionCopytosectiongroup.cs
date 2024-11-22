using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/section-copytosectiongroup?view=graph-rest-1.0
/// </summary>
public partial class SectionCopytosectionGroupParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? IdOrUserPrincipalName { get; set; }
        public string? GroupsId { get; set; }
        public string? SectionsId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Onenote_Sections_Id_CopyToSectionGroup: return $"/me/onenote/sections/{Id}/copyToSectionGroup";
                case ApiPath.Users_IdOrUserPrincipalName_Onenote_Sections_Id_CopyToSectionGroup: return $"/users/{IdOrUserPrincipalName}/onenote/sections/{Id}/copyToSectionGroup";
                case ApiPath.Groups_Id_Onenote_Sections_Id_CopyToSectionGroup: return $"/groups/{GroupsId}/onenote/sections/{SectionsId}/copyToSectionGroup";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_Onenote_Sections_Id_CopyToSectionGroup,
        Users_IdOrUserPrincipalName_Onenote_Sections_Id_CopyToSectionGroup,
        Groups_Id_Onenote_Sections_Id_CopyToSectionGroup,
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
    public string? RenameAs { get; set; }
}
public partial class SectionCopytosectionGroupResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/section-copytosectiongroup?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/section-copytosectiongroup?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SectionCopytosectionGroupResponse> SectionCopytosectionGroupAsync()
    {
        var p = new SectionCopytosectionGroupParameter();
        return await this.SendAsync<SectionCopytosectionGroupParameter, SectionCopytosectionGroupResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/section-copytosectiongroup?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SectionCopytosectionGroupResponse> SectionCopytosectionGroupAsync(CancellationToken cancellationToken)
    {
        var p = new SectionCopytosectionGroupParameter();
        return await this.SendAsync<SectionCopytosectionGroupParameter, SectionCopytosectionGroupResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/section-copytosectiongroup?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SectionCopytosectionGroupResponse> SectionCopytosectionGroupAsync(SectionCopytosectionGroupParameter parameter)
    {
        return await this.SendAsync<SectionCopytosectionGroupParameter, SectionCopytosectionGroupResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/section-copytosectiongroup?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SectionCopytosectionGroupResponse> SectionCopytosectionGroupAsync(SectionCopytosectionGroupParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SectionCopytosectionGroupParameter, SectionCopytosectionGroupResponse>(parameter, cancellationToken);
    }
}
