using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-list-securescorecontrolprofiles?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityListSecurescorecontrolprofilesParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class SecurityListSecurescorecontrolprofilesResponse : RestApiResponse
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
        public async ValueTask<SecurityListSecurescorecontrolprofilesResponse> SecurityListSecurescorecontrolprofilesAsync()
        {
            var p = new SecurityListSecurescorecontrolprofilesParameter();
            return await this.SendAsync<SecurityListSecurescorecontrolprofilesParameter, SecurityListSecurescorecontrolprofilesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-list-securescorecontrolprofiles?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityListSecurescorecontrolprofilesResponse> SecurityListSecurescorecontrolprofilesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityListSecurescorecontrolprofilesParameter();
            return await this.SendAsync<SecurityListSecurescorecontrolprofilesParameter, SecurityListSecurescorecontrolprofilesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-list-securescorecontrolprofiles?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityListSecurescorecontrolprofilesResponse> SecurityListSecurescorecontrolprofilesAsync(SecurityListSecurescorecontrolprofilesParameter parameter)
        {
            return await this.SendAsync<SecurityListSecurescorecontrolprofilesParameter, SecurityListSecurescorecontrolprofilesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-list-securescorecontrolprofiles?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityListSecurescorecontrolprofilesResponse> SecurityListSecurescorecontrolprofilesAsync(SecurityListSecurescorecontrolprofilesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityListSecurescorecontrolprofilesParameter, SecurityListSecurescorecontrolprofilesResponse>(parameter, cancellationToken);
        }
    }
}
