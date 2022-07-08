using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamsappDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string AppId { get; set; }
            public string AppDefinitionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.AppCatalogs_TeamsApps_Id: return $"/appCatalogs/teamsApps/{Id}";
                    case ApiPath.PpCatalogs_TeamsApps_AppId_AppDefinitions_AppDefinitionId: return $"/ppCatalogs/teamsApps/{AppId}/appDefinitions/{AppDefinitionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            AppCatalogs_TeamsApps_Id,
            PpCatalogs_TeamsApps_AppId_AppDefinitions_AppDefinitionId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class TeamsappDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/teamsapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamsappDeleteResponse> TeamsappDeleteAsync()
        {
            var p = new TeamsappDeleteParameter();
            return await this.SendAsync<TeamsappDeleteParameter, TeamsappDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/teamsapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamsappDeleteResponse> TeamsappDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TeamsappDeleteParameter();
            return await this.SendAsync<TeamsappDeleteParameter, TeamsappDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/teamsapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamsappDeleteResponse> TeamsappDeleteAsync(TeamsappDeleteParameter parameter)
        {
            return await this.SendAsync<TeamsappDeleteParameter, TeamsappDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/teamsapp-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamsappDeleteResponse> TeamsappDeleteAsync(TeamsappDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamsappDeleteParameter, TeamsappDeleteResponse>(parameter, cancellationToken);
        }
    }
}
