using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete-members?view=graph-rest-1.0
/// </summary>
public partial class AdministrativeunitDeleteMembersParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? AdministrativeUnitsId { get; set; }
        public string? MembersId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Directory_AdministrativeUnits_Id_Members_Id_ref: return $"/directory/administrativeUnits/{AdministrativeUnitsId}/members/{MembersId}/$ref";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Directory_AdministrativeUnits_Id_Members_Id_ref,
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
public partial class AdministrativeunitDeleteMembersResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete-members?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AdministrativeunitDeleteMembersResponse> AdministrativeunitDeleteMembersAsync()
    {
        var p = new AdministrativeunitDeleteMembersParameter();
        return await this.SendAsync<AdministrativeunitDeleteMembersParameter, AdministrativeunitDeleteMembersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AdministrativeunitDeleteMembersResponse> AdministrativeunitDeleteMembersAsync(CancellationToken cancellationToken)
    {
        var p = new AdministrativeunitDeleteMembersParameter();
        return await this.SendAsync<AdministrativeunitDeleteMembersParameter, AdministrativeunitDeleteMembersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AdministrativeunitDeleteMembersResponse> AdministrativeunitDeleteMembersAsync(AdministrativeunitDeleteMembersParameter parameter)
    {
        return await this.SendAsync<AdministrativeunitDeleteMembersParameter, AdministrativeunitDeleteMembersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete-members?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AdministrativeunitDeleteMembersResponse> AdministrativeunitDeleteMembersAsync(AdministrativeunitDeleteMembersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AdministrativeunitDeleteMembersParameter, AdministrativeunitDeleteMembersResponse>(parameter, cancellationToken);
    }
}
