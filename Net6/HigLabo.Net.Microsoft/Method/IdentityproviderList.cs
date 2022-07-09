using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityproviderListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProviders: return $"/identityProviders";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ClientId,
            ClientSecret,
            Id,
            Name,
            Type,
        }
        public enum ApiPath
        {
            IdentityProviders,
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
    public partial class IdentityproviderListResponse : RestApiResponse
    {
        public IdentityProvider[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderListResponse> IdentityproviderListAsync()
        {
            var p = new IdentityproviderListParameter();
            return await this.SendAsync<IdentityproviderListParameter, IdentityproviderListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderListResponse> IdentityproviderListAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityproviderListParameter();
            return await this.SendAsync<IdentityproviderListParameter, IdentityproviderListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderListResponse> IdentityproviderListAsync(IdentityproviderListParameter parameter)
        {
            return await this.SendAsync<IdentityproviderListParameter, IdentityproviderListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderListResponse> IdentityproviderListAsync(IdentityproviderListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityproviderListParameter, IdentityproviderListResponse>(parameter, cancellationToken);
        }
    }
}
