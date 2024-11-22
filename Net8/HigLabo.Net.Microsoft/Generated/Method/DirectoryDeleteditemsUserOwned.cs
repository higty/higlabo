using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

public partial class DirectoryDeleteditemsUserOwnedParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Directory_DeletedItems_GetUserOwnedObjects: return $"/directory/deletedItems/getUserOwnedObjects";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Directory_DeletedItems_GetUserOwnedObjects,
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
    public string? UserId { get; set; }
    public string? Type { get; set; }
    public string? Id { get; set; }
    public AdministrativeUnit[]? AdministrativeUnits { get; set; }
    public DirectoryObject[]? DeletedItems { get; set; }
    public IdentityProviderBase[]? FederationConfigurations { get; set; }
}
public partial class DirectoryDeleteditemsUserOwnedResponse : RestApiResponse
{
    public string? Id { get; set; }
    public AdministrativeUnit[]? AdministrativeUnits { get; set; }
    public DirectoryObject[]? DeletedItems { get; set; }
    public IdentityProviderBase[]? FederationConfigurations { get; set; }
}
public partial class MicrosoftClient
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-user-owned?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryDeleteditemsUserOwnedResponse> DirectoryDeleteditemsUserOwnedAsync()
    {
        var p = new DirectoryDeleteditemsUserOwnedParameter();
        return await this.SendAsync<DirectoryDeleteditemsUserOwnedParameter, DirectoryDeleteditemsUserOwnedResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-user-owned?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryDeleteditemsUserOwnedResponse> DirectoryDeleteditemsUserOwnedAsync(CancellationToken cancellationToken)
    {
        var p = new DirectoryDeleteditemsUserOwnedParameter();
        return await this.SendAsync<DirectoryDeleteditemsUserOwnedParameter, DirectoryDeleteditemsUserOwnedResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-user-owned?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryDeleteditemsUserOwnedResponse> DirectoryDeleteditemsUserOwnedAsync(DirectoryDeleteditemsUserOwnedParameter parameter)
    {
        return await this.SendAsync<DirectoryDeleteditemsUserOwnedParameter, DirectoryDeleteditemsUserOwnedResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-user-owned?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DirectoryDeleteditemsUserOwnedResponse> DirectoryDeleteditemsUserOwnedAsync(DirectoryDeleteditemsUserOwnedParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DirectoryDeleteditemsUserOwnedParameter, DirectoryDeleteditemsUserOwnedResponse>(parameter, cancellationToken);
    }
}
