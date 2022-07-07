using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryobjectCheckmembergroupsParameter : IRestApiParameter
    {
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

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DirectoryObjects_Id_CheckMemberGroups: return $"/directoryObjects/{Id}/checkMemberGroups";
                    case ApiPath.Me_CheckMemberGroups: return $"/me/checkMemberGroups";
                    case ApiPath.Users_IdOrUserPrincipalName_CheckMemberGroups: return $"/users/{IdOrUserPrincipalName}/checkMemberGroups";
                    case ApiPath.Groups_Id_CheckMemberGroups: return $"/groups/{Id}/checkMemberGroups";
                    case ApiPath.ServicePrincipals_Id_CheckMemberGroups: return $"/servicePrincipals/{Id}/checkMemberGroups";
                    case ApiPath.Contacts_Id_CheckMemberGroups: return $"/contacts/{Id}/checkMemberGroups";
                    case ApiPath.Devices_Id_CheckMemberGroups: return $"/devices/{Id}/checkMemberGroups";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public String[]? GroupIds { get; set; }
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class DirectoryobjectCheckmembergroupsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-checkmembergroups?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectCheckmembergroupsResponse> DirectoryobjectCheckmembergroupsAsync()
        {
            var p = new DirectoryobjectCheckmembergroupsParameter();
            return await this.SendAsync<DirectoryobjectCheckmembergroupsParameter, DirectoryobjectCheckmembergroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-checkmembergroups?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectCheckmembergroupsResponse> DirectoryobjectCheckmembergroupsAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryobjectCheckmembergroupsParameter();
            return await this.SendAsync<DirectoryobjectCheckmembergroupsParameter, DirectoryobjectCheckmembergroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-checkmembergroups?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectCheckmembergroupsResponse> DirectoryobjectCheckmembergroupsAsync(DirectoryobjectCheckmembergroupsParameter parameter)
        {
            return await this.SendAsync<DirectoryobjectCheckmembergroupsParameter, DirectoryobjectCheckmembergroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryobject-checkmembergroups?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryobjectCheckmembergroupsResponse> DirectoryobjectCheckmembergroupsAsync(DirectoryobjectCheckmembergroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryobjectCheckmembergroupsParameter, DirectoryobjectCheckmembergroupsResponse>(parameter, cancellationToken);
        }
    }
}
