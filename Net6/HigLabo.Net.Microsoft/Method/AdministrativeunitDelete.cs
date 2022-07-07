using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AdministrativeunitDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Directory_AdministrativeUnits_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Directory_AdministrativeUnits_Id: return $"/directory/administrativeUnits/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class AdministrativeunitDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteResponse> AdministrativeunitDeleteAsync()
        {
            var p = new AdministrativeunitDeleteParameter();
            return await this.SendAsync<AdministrativeunitDeleteParameter, AdministrativeunitDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteResponse> AdministrativeunitDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new AdministrativeunitDeleteParameter();
            return await this.SendAsync<AdministrativeunitDeleteParameter, AdministrativeunitDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteResponse> AdministrativeunitDeleteAsync(AdministrativeunitDeleteParameter parameter)
        {
            return await this.SendAsync<AdministrativeunitDeleteParameter, AdministrativeunitDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitDeleteResponse> AdministrativeunitDeleteAsync(AdministrativeunitDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdministrativeunitDeleteParameter, AdministrativeunitDeleteResponse>(parameter, cancellationToken);
        }
    }
}
