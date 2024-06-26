﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-update?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityproviderbaseUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? DisplayName { get; set; }
    }
    public partial class IdentityproviderbaseUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseUpdateResponse> IdentityproviderbaseUpdateAsync()
        {
            var p = new IdentityproviderbaseUpdateParameter();
            return await this.SendAsync<IdentityproviderbaseUpdateParameter, IdentityproviderbaseUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseUpdateResponse> IdentityproviderbaseUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityproviderbaseUpdateParameter();
            return await this.SendAsync<IdentityproviderbaseUpdateParameter, IdentityproviderbaseUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseUpdateResponse> IdentityproviderbaseUpdateAsync(IdentityproviderbaseUpdateParameter parameter)
        {
            return await this.SendAsync<IdentityproviderbaseUpdateParameter, IdentityproviderbaseUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityproviderbaseUpdateResponse> IdentityproviderbaseUpdateAsync(IdentityproviderbaseUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityproviderbaseUpdateParameter, IdentityproviderbaseUpdateResponse>(parameter, cancellationToken);
        }
    }
}
