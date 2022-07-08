using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ProfilephotoUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string IdOrUserPrincipalName { get; set; }
            public string Id { get; set; }
            public string ContactFolderId { get; set; }

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
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
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
    public partial class ProfilephotoUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/profilephoto-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ProfilephotoUpdateResponse> ProfilephotoUpdateAsync()
        {
            var p = new ProfilephotoUpdateParameter();
            return await this.SendAsync<ProfilephotoUpdateParameter, ProfilephotoUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/profilephoto-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ProfilephotoUpdateResponse> ProfilephotoUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new ProfilephotoUpdateParameter();
            return await this.SendAsync<ProfilephotoUpdateParameter, ProfilephotoUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/profilephoto-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ProfilephotoUpdateResponse> ProfilephotoUpdateAsync(ProfilephotoUpdateParameter parameter)
        {
            return await this.SendAsync<ProfilephotoUpdateParameter, ProfilephotoUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/profilephoto-update?view=graph-rest-1.0
        /// </summary>
        public async Task<ProfilephotoUpdateResponse> ProfilephotoUpdateAsync(ProfilephotoUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ProfilephotoUpdateParameter, ProfilephotoUpdateResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/profilephoto-update?view=graph-rest-1.0
        /// </summary>
        public async Task<Stream> ProfilephotoUpdateStreamAsync(ProfilephotoUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.DownloadStreamAsync(parameter, cancellationToken);
        }
    }
}
