using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-getmemberobjects?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryObjectGetMemberObjectsParameter : IRestApiParameter
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
                    case ApiPath.DirectoryObjects_Id_GetMemberObjects: return $"/directoryObjects/{Id}/getMemberObjects";
                    case ApiPath.Me_GetMemberObjects: return $"/me/getMemberObjects";
                    case ApiPath.Users_IdOrUserPrincipalName_GetMemberObjects: return $"/users/{IdOrUserPrincipalName}/getMemberObjects";
                    case ApiPath.Groups_Id_GetMemberObjects: return $"/groups/{Id}/getMemberObjects";
                    case ApiPath.ServicePrincipals_Id_GetMemberObjects: return $"/servicePrincipals/{Id}/getMemberObjects";
                    case ApiPath.Contacts_Id_GetMemberObjects: return $"/contacts/{Id}/getMemberObjects";
                    case ApiPath.Devices_Id_GetMemberObjects: return $"/devices/{Id}/getMemberObjects";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            DirectoryObjects_Id_GetMemberObjects,
            Me_GetMemberObjects,
            Users_IdOrUserPrincipalName_GetMemberObjects,
            Groups_Id_GetMemberObjects,
            ServicePrincipals_Id_GetMemberObjects,
            Contacts_Id_GetMemberObjects,
            Devices_Id_GetMemberObjects,
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
        public bool? SecurityEnabledOnly { get; set; }
    }
    public partial class DirectoryObjectGetMemberObjectsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryobject-getmemberobjects?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-getmemberobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryObjectGetMemberObjectsResponse> DirectoryObjectGetMemberObjectsAsync()
        {
            var p = new DirectoryObjectGetMemberObjectsParameter();
            return await this.SendAsync<DirectoryObjectGetMemberObjectsParameter, DirectoryObjectGetMemberObjectsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-getmemberobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryObjectGetMemberObjectsResponse> DirectoryObjectGetMemberObjectsAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryObjectGetMemberObjectsParameter();
            return await this.SendAsync<DirectoryObjectGetMemberObjectsParameter, DirectoryObjectGetMemberObjectsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-getmemberobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryObjectGetMemberObjectsResponse> DirectoryObjectGetMemberObjectsAsync(DirectoryObjectGetMemberObjectsParameter parameter)
        {
            return await this.SendAsync<DirectoryObjectGetMemberObjectsParameter, DirectoryObjectGetMemberObjectsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryobject-getmemberobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryObjectGetMemberObjectsResponse> DirectoryObjectGetMemberObjectsAsync(DirectoryObjectGetMemberObjectsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryObjectGetMemberObjectsParameter, DirectoryObjectGetMemberObjectsResponse>(parameter, cancellationToken);
        }
    }
}
