using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AdministrativeunitUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
    }
    public partial class AdministrativeunitUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitUpdateResponse> AdministrativeunitUpdateAsync()
        {
            var p = new AdministrativeunitUpdateParameter();
            return await this.SendAsync<AdministrativeunitUpdateParameter, AdministrativeunitUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitUpdateResponse> AdministrativeunitUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AdministrativeunitUpdateParameter();
            return await this.SendAsync<AdministrativeunitUpdateParameter, AdministrativeunitUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitUpdateResponse> AdministrativeunitUpdateAsync(AdministrativeunitUpdateParameter parameter)
        {
            return await this.SendAsync<AdministrativeunitUpdateParameter, AdministrativeunitUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitUpdateResponse> AdministrativeunitUpdateAsync(AdministrativeunitUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdministrativeunitUpdateParameter, AdministrativeunitUpdateResponse>(parameter, cancellationToken);
        }
    }
}
