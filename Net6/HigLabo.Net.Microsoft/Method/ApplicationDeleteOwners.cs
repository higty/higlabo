using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationDeleteOwnersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Applications_Id_Owners_Id_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Applications_Id_Owners_Id_ref: return $"/applications/{ApplicationsId}/owners/{OwnersId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ApplicationsId { get; set; }
        public string OwnersId { get; set; }
    }
    public partial class ApplicationDeleteOwnersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteOwnersResponse> ApplicationDeleteOwnersAsync()
        {
            var p = new ApplicationDeleteOwnersParameter();
            return await this.SendAsync<ApplicationDeleteOwnersParameter, ApplicationDeleteOwnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteOwnersResponse> ApplicationDeleteOwnersAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationDeleteOwnersParameter();
            return await this.SendAsync<ApplicationDeleteOwnersParameter, ApplicationDeleteOwnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteOwnersResponse> ApplicationDeleteOwnersAsync(ApplicationDeleteOwnersParameter parameter)
        {
            return await this.SendAsync<ApplicationDeleteOwnersParameter, ApplicationDeleteOwnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteOwnersResponse> ApplicationDeleteOwnersAsync(ApplicationDeleteOwnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationDeleteOwnersParameter, ApplicationDeleteOwnersResponse>(parameter, cancellationToken);
        }
    }
}
