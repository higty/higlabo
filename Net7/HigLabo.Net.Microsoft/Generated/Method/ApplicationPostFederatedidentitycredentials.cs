using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-post-federatedidentitycredentials?view=graph-rest-1.0
    /// </summary>
    public partial class ApplicationPostFederatedidentitycredentialsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Id_FederatedIdentityCredentials: return $"/applications/{Id}/federatedIdentityCredentials";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Applications_Id_FederatedIdentityCredentials,
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
        public String[]? Audiences { get; set; }
        public string? Issuer { get; set; }
        public string? Name { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
    }
    public partial class ApplicationPostFederatedidentitycredentialsResponse : RestApiResponse
    {
        public String[]? Audiences { get; set; }
        public string? Description { get; set; }
        public string? Id { get; set; }
        public string? Issuer { get; set; }
        public string? Name { get; set; }
        public string? Subject { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-post-federatedidentitycredentials?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-federatedidentitycredentials?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationPostFederatedidentitycredentialsResponse> ApplicationPostFederatedidentitycredentialsAsync()
        {
            var p = new ApplicationPostFederatedidentitycredentialsParameter();
            return await this.SendAsync<ApplicationPostFederatedidentitycredentialsParameter, ApplicationPostFederatedidentitycredentialsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-federatedidentitycredentials?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationPostFederatedidentitycredentialsResponse> ApplicationPostFederatedidentitycredentialsAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationPostFederatedidentitycredentialsParameter();
            return await this.SendAsync<ApplicationPostFederatedidentitycredentialsParameter, ApplicationPostFederatedidentitycredentialsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-federatedidentitycredentials?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationPostFederatedidentitycredentialsResponse> ApplicationPostFederatedidentitycredentialsAsync(ApplicationPostFederatedidentitycredentialsParameter parameter)
        {
            return await this.SendAsync<ApplicationPostFederatedidentitycredentialsParameter, ApplicationPostFederatedidentitycredentialsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-post-federatedidentitycredentials?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationPostFederatedidentitycredentialsResponse> ApplicationPostFederatedidentitycredentialsAsync(ApplicationPostFederatedidentitycredentialsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationPostFederatedidentitycredentialsParameter, ApplicationPostFederatedidentitycredentialsResponse>(parameter, cancellationToken);
        }
    }
}
