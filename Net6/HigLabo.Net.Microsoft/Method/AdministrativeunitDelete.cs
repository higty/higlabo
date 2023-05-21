using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete?view=graph-rest-1.0
    /// </summary>
    public partial class AdministrativeunitDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Directory_AdministrativeUnits_Id: return $"/directory/administrativeUnits/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Directory_AdministrativeUnits_Id,
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
    public partial class AdministrativeunitDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteResponse> AdministrativeunitDeleteAsync()
        {
            var p = new AdministrativeunitDeleteParameter();
            return await this.SendAsync<AdministrativeunitDeleteParameter, AdministrativeunitDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteResponse> AdministrativeunitDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new AdministrativeunitDeleteParameter();
            return await this.SendAsync<AdministrativeunitDeleteParameter, AdministrativeunitDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteResponse> AdministrativeunitDeleteAsync(AdministrativeunitDeleteParameter parameter)
        {
            return await this.SendAsync<AdministrativeunitDeleteParameter, AdministrativeunitDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteResponse> AdministrativeunitDeleteAsync(AdministrativeunitDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdministrativeunitDeleteParameter, AdministrativeunitDeleteResponse>(parameter, cancellationToken);
        }
    }
}
