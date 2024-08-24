using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/profilephoto-update?view=graph-rest-1.0
    /// </summary>
    public partial class ProfilePhotoUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? ContactFolderId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Contacts_Id_Photo_value: return $"/me/contacts/{Id}/photo/$value";
                    case ApiPath.Users_IdOrUserPrincipalName_Contacts_Id_Photo_value: return $"/users/{IdOrUserPrincipalName}/contacts/{Id}/photo/$value";
                    case ApiPath.Me_Contactfolders_ContactFolderId_Contacts_Id_Photo_value: return $"/me/contactfolders/{ContactFolderId}/contacts/{Id}/photo/$value";
                    case ApiPath.Users_IdOrUserPrincipalName_Contactfolders_ContactFolderId_Contacts_Id_Photo_value: return $"/users/{IdOrUserPrincipalName}/contactfolders/{ContactFolderId}/contacts/{Id}/photo/$value";
                    case ApiPath.Groups_Id_Photo_value: return $"/groups/{Id}/photo/$value";
                    case ApiPath.Team_Id_Photo_value: return $"/team/{Id}/photo/$value";
                    case ApiPath.Me_Photo_value: return $"/me/photo/$value";
                    case ApiPath.Users_IdOrUserPrincipalName_Photo_value: return $"/users/{IdOrUserPrincipalName}/photo/$value";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Contacts_Id_Photo_value,
            Users_IdOrUserPrincipalName_Contacts_Id_Photo_value,
            Me_Contactfolders_ContactFolderId_Contacts_Id_Photo_value,
            Users_IdOrUserPrincipalName_Contactfolders_ContactFolderId_Contacts_Id_Photo_value,
            Groups_Id_Photo_value,
            Team_Id_Photo_value,
            Me_Photo_value,
            Users_IdOrUserPrincipalName_Photo_value,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
    }
    public partial class ProfilePhotoUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/profilephoto-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/profilephoto-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProfilePhotoUpdateResponse> ProfilePhotoUpdateAsync()
        {
            var p = new ProfilePhotoUpdateParameter();
            return await this.SendAsync<ProfilePhotoUpdateParameter, ProfilePhotoUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/profilephoto-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProfilePhotoUpdateResponse> ProfilePhotoUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new ProfilePhotoUpdateParameter();
            return await this.SendAsync<ProfilePhotoUpdateParameter, ProfilePhotoUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/profilephoto-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProfilePhotoUpdateResponse> ProfilePhotoUpdateAsync(ProfilePhotoUpdateParameter parameter)
        {
            return await this.SendAsync<ProfilePhotoUpdateParameter, ProfilePhotoUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/profilephoto-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ProfilePhotoUpdateResponse> ProfilePhotoUpdateAsync(ProfilePhotoUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ProfilePhotoUpdateParameter, ProfilePhotoUpdateResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/profilephoto-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<Stream> ProfilePhotoUpdateStreamAsync(ProfilePhotoUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.DownloadStreamAsync(parameter, cancellationToken);
        }
    }
}
