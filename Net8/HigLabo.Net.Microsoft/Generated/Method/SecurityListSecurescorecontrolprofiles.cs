using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-list-securescorecontrolprofiles?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityListSecureScorecontrolprofilesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_SecureScoreControlProfiles: return $"/security/secureScoreControlProfiles";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_SecureScoreControlProfiles,
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
    public partial class SecurityListSecureScorecontrolprofilesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-list-securescorecontrolprofiles?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-list-securescorecontrolprofiles?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityListSecureScorecontrolprofilesResponse> SecurityListSecureScorecontrolprofilesAsync()
        {
            var p = new SecurityListSecureScorecontrolprofilesParameter();
            return await this.SendAsync<SecurityListSecureScorecontrolprofilesParameter, SecurityListSecureScorecontrolprofilesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-list-securescorecontrolprofiles?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityListSecureScorecontrolprofilesResponse> SecurityListSecureScorecontrolprofilesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityListSecureScorecontrolprofilesParameter();
            return await this.SendAsync<SecurityListSecureScorecontrolprofilesParameter, SecurityListSecureScorecontrolprofilesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-list-securescorecontrolprofiles?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityListSecureScorecontrolprofilesResponse> SecurityListSecureScorecontrolprofilesAsync(SecurityListSecureScorecontrolprofilesParameter parameter)
        {
            return await this.SendAsync<SecurityListSecureScorecontrolprofilesParameter, SecurityListSecureScorecontrolprofilesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-list-securescorecontrolprofiles?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityListSecureScorecontrolprofilesResponse> SecurityListSecureScorecontrolprofilesAsync(SecurityListSecureScorecontrolprofilesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityListSecureScorecontrolprofilesParameter, SecurityListSecureScorecontrolprofilesResponse>(parameter, cancellationToken);
        }
    }
}
