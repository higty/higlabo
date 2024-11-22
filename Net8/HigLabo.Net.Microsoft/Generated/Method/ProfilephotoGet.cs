using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/profilephoto-get?view=graph-rest-1.0
/// </summary>
public partial class ProfilePhotoGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }
        public string? Id { get; set; }
        public string? ContactFolderId { get; set; }
        public string? Size { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Photo_value: return $"/me/photo/$value";
                case ApiPath.Users_IdOrUserPrincipalName_Photo_value: return $"/users/{IdOrUserPrincipalName}/photo/$value";
                case ApiPath.Groups_Id_Photo_value: return $"/groups/{Id}/photo/$value";
                case ApiPath.Me_Contacts_Id_Photo_value: return $"/me/contacts/{Id}/photo/$value";
                case ApiPath.Users_IdOrUserPrincipalName_Contacts_Id_Photo_value: return $"/users/{IdOrUserPrincipalName}/contacts/{Id}/photo/$value";
                case ApiPath.Me_Contactfolders_ContactFolderId_Contacts_Id_Photo_value: return $"/me/contactfolders/{ContactFolderId}/contacts/{Id}/photo/$value";
                case ApiPath.Users_IdOrUserPrincipalName_Contactfolders_ContactFolderId_Contacts_Id_Photo_value: return $"/users/{IdOrUserPrincipalName}/contactfolders/{ContactFolderId}/contacts/{Id}/photo/$value";
                case ApiPath.Team_Id_Photo_value: return $"/team/{Id}/photo/$value";
                case ApiPath.Me_Photo: return $"/me/photo";
                case ApiPath.Me_Photos: return $"/me/photos";
                case ApiPath.Users_IdOrUserPrincipalName_Photo: return $"/users/{IdOrUserPrincipalName}/photo";
                case ApiPath.Groups_Id_Photo: return $"/groups/{Id}/photo";
                case ApiPath.Me_Contacts_Id_Photo: return $"/me/contacts/{Id}/photo";
                case ApiPath.Users_IdOrUserPrincipalName_Contacts_Id_Photo: return $"/users/{IdOrUserPrincipalName}/contacts/{Id}/photo";
                case ApiPath.Me_Contactfolders_ContactFolderId_Contacts_Id_Photo: return $"/me/contactfolders/{ContactFolderId}/contacts/{Id}/photo";
                case ApiPath.Users_IdOrUserPrincipalName_Contactfolders_ContactFolderId_Contacts_Id_Photo: return $"/users/{IdOrUserPrincipalName}/contactfolders/{ContactFolderId}/contacts/{Id}/photo";
                case ApiPath.Team_Id_Photo: return $"/team/{Id}/photo";
                case ApiPath.Me_Photos_Size: return $"/me/photos/{Size}";
                case ApiPath.Users_IdOrUserPrincipalName_Photos_Size: return $"/users/{IdOrUserPrincipalName}/photos/{Size}";
                case ApiPath.Groups_Id_Photos_Size: return $"/groups/{Id}/photos/{Size}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Photo_value,
        Users_IdOrUserPrincipalName_Photo_value,
        Groups_Id_Photo_value,
        Me_Contacts_Id_Photo_value,
        Users_IdOrUserPrincipalName_Contacts_Id_Photo_value,
        Me_Contactfolders_ContactFolderId_Contacts_Id_Photo_value,
        Users_IdOrUserPrincipalName_Contactfolders_ContactFolderId_Contacts_Id_Photo_value,
        Team_Id_Photo_value,
        Me_Photo,
        Me_Photos,
        Users_IdOrUserPrincipalName_Photo,
        Groups_Id_Photo,
        Me_Contacts_Id_Photo,
        Users_IdOrUserPrincipalName_Contacts_Id_Photo,
        Me_Contactfolders_ContactFolderId_Contacts_Id_Photo,
        Users_IdOrUserPrincipalName_Contactfolders_ContactFolderId_Contacts_Id_Photo,
        Team_Id_Photo,
        Me_Photos_Size,
        Users_IdOrUserPrincipalName_Photos_Size,
        Groups_Id_Photos_Size,
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
public partial class ProfilePhotoGetResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/profilephoto-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/profilephoto-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ProfilePhotoGetResponse> ProfilePhotoGetAsync()
    {
        var p = new ProfilePhotoGetParameter();
        return await this.SendAsync<ProfilePhotoGetParameter, ProfilePhotoGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/profilephoto-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ProfilePhotoGetResponse> ProfilePhotoGetAsync(CancellationToken cancellationToken)
    {
        var p = new ProfilePhotoGetParameter();
        return await this.SendAsync<ProfilePhotoGetParameter, ProfilePhotoGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/profilephoto-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ProfilePhotoGetResponse> ProfilePhotoGetAsync(ProfilePhotoGetParameter parameter)
    {
        return await this.SendAsync<ProfilePhotoGetParameter, ProfilePhotoGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/profilephoto-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ProfilePhotoGetResponse> ProfilePhotoGetAsync(ProfilePhotoGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ProfilePhotoGetParameter, ProfilePhotoGetResponse>(parameter, cancellationToken);
    }
}
