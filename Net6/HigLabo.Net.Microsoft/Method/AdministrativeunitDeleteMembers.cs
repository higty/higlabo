using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AdministrativeunitDeleteMembersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Directory_AdministrativeUnits_Id_Members_Id_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Directory_AdministrativeUnits_Id_Members_Id_ref: return $"/directory/administrativeUnits/{AdministrativeUnitsId}/members/{MembersId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string AdministrativeUnitsId { get; set; }
        public string MembersId { get; set; }
    }
    public partial class AdministrativeunitDeleteMembersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteMembersResponse> AdministrativeunitDeleteMembersAsync()
        {
            var p = new AdministrativeunitDeleteMembersParameter();
            return await this.SendAsync<AdministrativeunitDeleteMembersParameter, AdministrativeunitDeleteMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteMembersResponse> AdministrativeunitDeleteMembersAsync(CancellationToken cancellationToken)
        {
            var p = new AdministrativeunitDeleteMembersParameter();
            return await this.SendAsync<AdministrativeunitDeleteMembersParameter, AdministrativeunitDeleteMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteMembersResponse> AdministrativeunitDeleteMembersAsync(AdministrativeunitDeleteMembersParameter parameter)
        {
            return await this.SendAsync<AdministrativeunitDeleteMembersParameter, AdministrativeunitDeleteMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteMembersResponse> AdministrativeunitDeleteMembersAsync(AdministrativeunitDeleteMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdministrativeunitDeleteMembersParameter, AdministrativeunitDeleteMembersResponse>(parameter, cancellationToken);
        }
    }
}
