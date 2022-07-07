using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryobjectCheckmemberobjectsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DirectoryObjects_Id_CheckMemberObjects,
            Me_CheckMemberObjects,
            Users_IdOrUserPrincipalName_CheckMemberObjects,
            Groups_Id_CheckMemberObjects,
            ServicePrincipals_Id_CheckMemberObjects,
            Contacts_Id_CheckMemberObjects,
            Devices_Id_CheckMemberObjects,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DirectoryObjects_Id_CheckMemberObjects: return $"/directoryObjects/{Id}/checkMemberObjects";
                    case ApiPath.Me_CheckMemberObjects: return $"/me/checkMemberObjects";
                    case ApiPath.Users_IdOrUserPrincipalName_CheckMemberObjects: return $"/users/{IdOrUserPrincipalName}/checkMemberObjects";
                    case ApiPath.Groups_Id_CheckMemberObjects: return $"/groups/{Id}/checkMemberObjects";
                    case ApiPath.ServicePrincipals_Id_CheckMemberObjects: return $"/servicePrincipals/{Id}/checkMemberObjects";
                    case ApiPath.Contacts_Id_CheckMemberObjects: return $"/contacts/{Id}/checkMemberObjects";
                    case ApiPath.Devices_Id_CheckMemberObjects: return $"/devices/{Id}/checkMemberObjects";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public String[]? Ids { get; set; }
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class DirectoryobjectCheckmemberobjectsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-checkmemberobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectCheckmemberobjectsResponse> DirectoryobjectCheckmemberobjectsAsync()
        {
            var p = new DirectoryobjectCheckmemberobjectsParameter();
            return await this.SendAsync<DirectoryobjectCheckmemberobjectsParameter, DirectoryobjectCheckmemberobjectsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-checkmemberobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectCheckmemberobjectsResponse> DirectoryobjectCheckmemberobjectsAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryobjectCheckmemberobjectsParameter();
            return await this.SendAsync<DirectoryobjectCheckmemberobjectsParameter, DirectoryobjectCheckmemberobjectsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-checkmemberobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectCheckmemberobjectsResponse> DirectoryobjectCheckmemberobjectsAsync(DirectoryobjectCheckmemberobjectsParameter parameter)
        {
            return await this.SendAsync<DirectoryobjectCheckmemberobjectsParameter, DirectoryobjectCheckmemberobjectsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-checkmemberobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectCheckmemberobjectsResponse> DirectoryobjectCheckmemberobjectsAsync(DirectoryobjectCheckmemberobjectsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryobjectCheckmemberobjectsParameter, DirectoryobjectCheckmemberobjectsResponse>(parameter, cancellationToken);
        }
    }
}
