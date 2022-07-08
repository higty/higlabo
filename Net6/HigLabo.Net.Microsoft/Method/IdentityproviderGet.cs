using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityproviderGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProviders_Id: return $"/identityProviders/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityProviders_Id,
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
    public partial class IdentityproviderGetResponse : RestApiResponse
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderGetResponse> IdentityproviderGetAsync()
        {
            var p = new IdentityproviderGetParameter();
            return await this.SendAsync<IdentityproviderGetParameter, IdentityproviderGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderGetResponse> IdentityproviderGetAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityproviderGetParameter();
            return await this.SendAsync<IdentityproviderGetParameter, IdentityproviderGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderGetResponse> IdentityproviderGetAsync(IdentityproviderGetParameter parameter)
        {
            return await this.SendAsync<IdentityproviderGetParameter, IdentityproviderGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityprovider-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderGetResponse> IdentityproviderGetAsync(IdentityproviderGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityproviderGetParameter, IdentityproviderGetResponse>(parameter, cancellationToken);
        }
    }
}
