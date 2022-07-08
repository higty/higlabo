using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityproviderbaseDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_IdentityProviders_Id: return $"/identity/identityProviders/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Identity_IdentityProviders_Id,
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
    public partial class IdentityproviderbaseDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityproviderbase-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseDeleteResponse> IdentityproviderbaseDeleteAsync()
        {
            var p = new IdentityproviderbaseDeleteParameter();
            return await this.SendAsync<IdentityproviderbaseDeleteParameter, IdentityproviderbaseDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityproviderbase-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseDeleteResponse> IdentityproviderbaseDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityproviderbaseDeleteParameter();
            return await this.SendAsync<IdentityproviderbaseDeleteParameter, IdentityproviderbaseDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityproviderbase-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseDeleteResponse> IdentityproviderbaseDeleteAsync(IdentityproviderbaseDeleteParameter parameter)
        {
            return await this.SendAsync<IdentityproviderbaseDeleteParameter, IdentityproviderbaseDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityproviderbase-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseDeleteResponse> IdentityproviderbaseDeleteAsync(IdentityproviderbaseDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityproviderbaseDeleteParameter, IdentityproviderbaseDeleteResponse>(parameter, cancellationToken);
        }
    }
}
