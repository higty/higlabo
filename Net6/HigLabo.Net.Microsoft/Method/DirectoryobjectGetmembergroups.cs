using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryobjectGetmembergroupsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DirectoryObjects_Id_GetMemberGroups,
            Me_GetMemberGroups,
            Users_IdOrUserPrincipalName_GetMemberGroups,
            Groups_Id_GetMemberGroups,
            ServicePrincipals_Id_GetMemberGroups,
            Contacts_Id_GetMemberGroups,
            Devices_Id_GetMemberGroups,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DirectoryObjects_Id_GetMemberGroups: return $"/directoryObjects/{Id}/getMemberGroups";
                    case ApiPath.Me_GetMemberGroups: return $"/me/getMemberGroups";
                    case ApiPath.Users_IdOrUserPrincipalName_GetMemberGroups: return $"/users/{IdOrUserPrincipalName}/getMemberGroups";
                    case ApiPath.Groups_Id_GetMemberGroups: return $"/groups/{Id}/getMemberGroups";
                    case ApiPath.ServicePrincipals_Id_GetMemberGroups: return $"/servicePrincipals/{Id}/getMemberGroups";
                    case ApiPath.Contacts_Id_GetMemberGroups: return $"/contacts/{Id}/getMemberGroups";
                    case ApiPath.Devices_Id_GetMemberGroups: return $"/devices/{Id}/getMemberGroups";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public bool? SecurityEnabledOnly { get; set; }
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class DirectoryobjectGetmembergroupsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-getmembergroups?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetmembergroupsResponse> DirectoryobjectGetmembergroupsAsync()
        {
            var p = new DirectoryobjectGetmembergroupsParameter();
            return await this.SendAsync<DirectoryobjectGetmembergroupsParameter, DirectoryobjectGetmembergroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-getmembergroups?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetmembergroupsResponse> DirectoryobjectGetmembergroupsAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryobjectGetmembergroupsParameter();
            return await this.SendAsync<DirectoryobjectGetmembergroupsParameter, DirectoryobjectGetmembergroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-getmembergroups?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetmembergroupsResponse> DirectoryobjectGetmembergroupsAsync(DirectoryobjectGetmembergroupsParameter parameter)
        {
            return await this.SendAsync<DirectoryobjectGetmembergroupsParameter, DirectoryobjectGetmembergroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-getmembergroups?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectGetmembergroupsResponse> DirectoryobjectGetmembergroupsAsync(DirectoryobjectGetmembergroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryobjectGetmembergroupsParameter, DirectoryobjectGetmembergroupsResponse>(parameter, cancellationToken);
        }
    }
}
