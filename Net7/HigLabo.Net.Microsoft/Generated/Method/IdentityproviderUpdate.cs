using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-update?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityproviderUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityProviders_Id: return $"/identityProviders/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? Name { get; set; }
    }
    public partial class IdentityproviderUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprovider-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderUpdateResponse> IdentityproviderUpdateAsync()
        {
            var p = new IdentityproviderUpdateParameter();
            return await this.SendAsync<IdentityproviderUpdateParameter, IdentityproviderUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprovider-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderUpdateResponse> IdentityproviderUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityproviderUpdateParameter();
            return await this.SendAsync<IdentityproviderUpdateParameter, IdentityproviderUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprovider-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderUpdateResponse> IdentityproviderUpdateAsync(IdentityproviderUpdateParameter parameter)
        {
            return await this.SendAsync<IdentityproviderUpdateParameter, IdentityproviderUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityprovider-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderUpdateResponse> IdentityproviderUpdateAsync(IdentityproviderUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityproviderUpdateParameter, IdentityproviderUpdateResponse>(parameter, cancellationToken);
        }
    }
}
