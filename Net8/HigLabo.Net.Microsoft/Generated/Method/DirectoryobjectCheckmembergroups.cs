using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryobject-checkmembergroups?view=graph-rest-1.0
/// </summary>
public partial class DirectoryObjectCheckMemberGroupsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.DirectoryObjects_Id_CheckMemberGroups: return $"/directoryObjects/{Id}/checkMemberGroups";
                case ApiPath.Me_CheckMemberGroups: return $"/me/checkMemberGroups";
                case ApiPath.Users_IdOrUserPrincipalName_CheckMemberGroups: return $"/users/{IdOrUserPrincipalName}/checkMemberGroups";
                case ApiPath.Groups_Id_CheckMemberGroups: return $"/groups/{Id}/checkMemberGroups";
                case ApiPath.ServicePrincipals_Id_CheckMemberGroups: return $"/servicePrincipals/{Id}/checkMemberGroups";
                case ApiPath.Contacts_Id_CheckMemberGroups: return $"/contacts/{Id}/checkMemberGroups";
                case ApiPath.Devices_Id_CheckMemberGroups: return $"/devices/{Id}/checkMemberGroups";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        DirectoryObjects_Id_CheckMemberGroups,
        Me_CheckMemberGroups,
        Users_IdOrUserPrincipalName_CheckMemberGroups,
        Groups_Id_CheckMemberGroups,
        ServicePrincipals_Id_CheckMemberGroups,
        Contacts_Id_CheckMemberGroups,
        Devices_Id_CheckMemberGroups,
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
    public String[]? GroupIds { get; set; }
}
public partial class DirectoryObjectCheckMemberGroupsResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/directoryobject-checkmembergroups?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-checkmembergroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryObjectCheckMemberGroupsResponse> DirectoryObjectCheckMemberGroupsAsync()
    {
        var p = new DirectoryObjectCheckMemberGroupsParameter();
        return await this.SendAsync<DirectoryObjectCheckMemberGroupsParameter, DirectoryObjectCheckMemberGroupsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-checkmembergroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryObjectCheckMemberGroupsResponse> DirectoryObjectCheckMemberGroupsAsync(CancellationToken cancellationToken)
    {
        var p = new DirectoryObjectCheckMemberGroupsParameter();
        return await this.SendAsync<DirectoryObjectCheckMemberGroupsParameter, DirectoryObjectCheckMemberGroupsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-checkmembergroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryObjectCheckMemberGroupsResponse> DirectoryObjectCheckMemberGroupsAsync(DirectoryObjectCheckMemberGroupsParameter parameter)
    {
        return await this.SendAsync<DirectoryObjectCheckMemberGroupsParameter, DirectoryObjectCheckMemberGroupsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-checkmembergroups?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryObjectCheckMemberGroupsResponse> DirectoryObjectCheckMemberGroupsAsync(DirectoryObjectCheckMemberGroupsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DirectoryObjectCheckMemberGroupsParameter, DirectoryObjectCheckMemberGroupsResponse>(parameter, cancellationToken);
    }
}
