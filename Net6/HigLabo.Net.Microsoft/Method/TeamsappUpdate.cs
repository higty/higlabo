using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamsappUpdateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            AppCatalogs_TeamsApps_Id_AppDefinitions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.AppCatalogs_TeamsApps_Id_AppDefinitions: return $"/appCatalogs/teamsApps/{Id}/appDefinitions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class TeamsappUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/teamsapp-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamsappUpdateResponse> TeamsappUpdateAsync()
        {
            var p = new TeamsappUpdateParameter();
            return await this.SendAsync<TeamsappUpdateParameter, TeamsappUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/teamsapp-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamsappUpdateResponse> TeamsappUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new TeamsappUpdateParameter();
            return await this.SendAsync<TeamsappUpdateParameter, TeamsappUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/teamsapp-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamsappUpdateResponse> TeamsappUpdateAsync(TeamsappUpdateParameter parameter)
        {
            return await this.SendAsync<TeamsappUpdateParameter, TeamsappUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/teamsapp-update?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamsappUpdateResponse> TeamsappUpdateAsync(TeamsappUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamsappUpdateParameter, TeamsappUpdateResponse>(parameter, cancellationToken);
        }
    }
}
