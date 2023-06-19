using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamsapp-update?view=graph-rest-1.0
    /// </summary>
    public partial class TeamsappUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.AppCatalogs_TeamsApps_Id_AppDefinitions: return $"/appCatalogs/teamsApps/{Id}/appDefinitions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            AppCatalogs_TeamsApps_Id_AppDefinitions,
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
    }
    public partial class TeamsappUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamsapp-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamsapp-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamsappUpdateResponse> TeamsappUpdateAsync()
        {
            var p = new TeamsappUpdateParameter();
            return await this.SendAsync<TeamsappUpdateParameter, TeamsappUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamsapp-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamsappUpdateResponse> TeamsappUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new TeamsappUpdateParameter();
            return await this.SendAsync<TeamsappUpdateParameter, TeamsappUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamsapp-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamsappUpdateResponse> TeamsappUpdateAsync(TeamsappUpdateParameter parameter)
        {
            return await this.SendAsync<TeamsappUpdateParameter, TeamsappUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamsapp-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamsappUpdateResponse> TeamsappUpdateAsync(TeamsappUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamsappUpdateParameter, TeamsappUpdateResponse>(parameter, cancellationToken);
        }
    }
}
