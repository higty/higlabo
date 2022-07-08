using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AdministrativeunitPostMembersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Directory_AdministrativeUnits_Id_Members_ref: return $"/directory/administrativeUnits/{Id}/members/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Directory_AdministrativeUnits_Id_Members_ref,
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
    public partial class AdministrativeunitPostMembersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitPostMembersResponse> AdministrativeunitPostMembersAsync()
        {
            var p = new AdministrativeunitPostMembersParameter();
            return await this.SendAsync<AdministrativeunitPostMembersParameter, AdministrativeunitPostMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitPostMembersResponse> AdministrativeunitPostMembersAsync(CancellationToken cancellationToken)
        {
            var p = new AdministrativeunitPostMembersParameter();
            return await this.SendAsync<AdministrativeunitPostMembersParameter, AdministrativeunitPostMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitPostMembersResponse> AdministrativeunitPostMembersAsync(AdministrativeunitPostMembersParameter parameter)
        {
            return await this.SendAsync<AdministrativeunitPostMembersParameter, AdministrativeunitPostMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/administrativeunit-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<AdministrativeunitPostMembersResponse> AdministrativeunitPostMembersAsync(AdministrativeunitPostMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdministrativeunitPostMembersParameter, AdministrativeunitPostMembersResponse>(parameter, cancellationToken);
        }
    }
}
