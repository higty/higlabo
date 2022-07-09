using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryobjectGetmemberobjectsParameter : IRestApiParameter
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
    public partial class DirectoryobjectGetmemberobjectsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-getmemberobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetmemberobjectsResponse> DirectoryobjectGetmemberobjectsAsync()
        {
            var p = new DirectoryobjectGetmemberobjectsParameter();
            return await this.SendAsync<DirectoryobjectGetmemberobjectsParameter, DirectoryobjectGetmemberobjectsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-getmemberobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetmemberobjectsResponse> DirectoryobjectGetmemberobjectsAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryobjectGetmemberobjectsParameter();
            return await this.SendAsync<DirectoryobjectGetmemberobjectsParameter, DirectoryobjectGetmemberobjectsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-getmemberobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetmemberobjectsResponse> DirectoryobjectGetmemberobjectsAsync(DirectoryobjectGetmemberobjectsParameter parameter)
        {
            return await this.SendAsync<DirectoryobjectGetmemberobjectsParameter, DirectoryobjectGetmemberobjectsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-getmemberobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetmemberobjectsResponse> DirectoryobjectGetmemberobjectsAsync(DirectoryobjectGetmemberobjectsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryobjectGetmemberobjectsParameter, DirectoryobjectGetmemberobjectsResponse>(parameter, cancellationToken);
        }
    }
}
