using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list-federatedidentitycredentials?view=graph-rest-1.0
    /// </summary>
    public partial class ApplicationListFederatedidentitycredentialsParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            Audiences,
            Description,
            Id,
            Issuer,
            Name,
            Subject,
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class ApplicationListFederatedidentitycredentialsResponse : RestApiResponse
    {
        public FederatedIdentityCredential[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list-federatedidentitycredentials?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-list-federatedidentitycredentials?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListFederatedidentitycredentialsResponse> ApplicationListFederatedidentitycredentialsAsync()
        {
            var p = new ApplicationListFederatedidentitycredentialsParameter();
            return await this.SendAsync<ApplicationListFederatedidentitycredentialsParameter, ApplicationListFederatedidentitycredentialsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-list-federatedidentitycredentials?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListFederatedidentitycredentialsResponse> ApplicationListFederatedidentitycredentialsAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationListFederatedidentitycredentialsParameter();
            return await this.SendAsync<ApplicationListFederatedidentitycredentialsParameter, ApplicationListFederatedidentitycredentialsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-list-federatedidentitycredentials?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListFederatedidentitycredentialsResponse> ApplicationListFederatedidentitycredentialsAsync(ApplicationListFederatedidentitycredentialsParameter parameter)
        {
            return await this.SendAsync<ApplicationListFederatedidentitycredentialsParameter, ApplicationListFederatedidentitycredentialsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-list-federatedidentitycredentials?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListFederatedidentitycredentialsResponse> ApplicationListFederatedidentitycredentialsAsync(ApplicationListFederatedidentitycredentialsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationListFederatedidentitycredentialsParameter, ApplicationListFederatedidentitycredentialsResponse>(parameter, cancellationToken);
        }
    }
}
