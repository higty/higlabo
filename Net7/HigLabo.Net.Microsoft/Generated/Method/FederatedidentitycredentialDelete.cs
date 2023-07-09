using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-delete?view=graph-rest-1.0
    /// </summary>
    public partial class FederatedidentitycredentialDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? FederatedIdentityCredentialId { get; set; }
            public string? FederatedIdentityCredentialName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Id_FederatedIdentityCredentials_FederatedIdentityCredentialId: return $"/applications/{Id}/federatedIdentityCredentials/{FederatedIdentityCredentialId}";
                    case ApiPath.Applications_Id_FederatedIdentityCredentials_FederatedIdentityCredentialName: return $"/applications/{Id}/federatedIdentityCredentials/{FederatedIdentityCredentialName}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Applications_Id_FederatedIdentityCredentials_FederatedIdentityCredentialId,
            Applications_Id_FederatedIdentityCredentials_FederatedIdentityCredentialName,
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
    public partial class FederatedidentitycredentialDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<FederatedidentitycredentialDeleteResponse> FederatedidentitycredentialDeleteAsync()
        {
            var p = new FederatedidentitycredentialDeleteParameter();
            return await this.SendAsync<FederatedidentitycredentialDeleteParameter, FederatedidentitycredentialDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<FederatedidentitycredentialDeleteResponse> FederatedidentitycredentialDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new FederatedidentitycredentialDeleteParameter();
            return await this.SendAsync<FederatedidentitycredentialDeleteParameter, FederatedidentitycredentialDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<FederatedidentitycredentialDeleteResponse> FederatedidentitycredentialDeleteAsync(FederatedidentitycredentialDeleteParameter parameter)
        {
            return await this.SendAsync<FederatedidentitycredentialDeleteParameter, FederatedidentitycredentialDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/federatedidentitycredential-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<FederatedidentitycredentialDeleteResponse> FederatedidentitycredentialDeleteAsync(FederatedidentitycredentialDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<FederatedidentitycredentialDeleteParameter, FederatedidentitycredentialDeleteResponse>(parameter, cancellationToken);
        }
    }
}
