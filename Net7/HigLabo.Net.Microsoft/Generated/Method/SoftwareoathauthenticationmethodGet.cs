using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethod-get?view=graph-rest-1.0
    /// </summary>
    public partial class SoftwareoathauthenticationmethodGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Authentication_SoftwareOathMethods_Id: return $"/me/authentication/softwareOathMethods/{Id}";
                    case ApiPath.Users_IdOrUserPrincipalName_Authentication_SoftwareOathMethods_Id: return $"/users/{IdOrUserPrincipalName}/authentication/softwareOathMethods/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Authentication_SoftwareOathMethods_Id,
            Users_IdOrUserPrincipalName_Authentication_SoftwareOathMethods_Id,
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
    public partial class SoftwareoathauthenticationmethodGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? SecretKey { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethod-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodGetResponse> SoftwareoathauthenticationmethodGetAsync()
        {
            var p = new SoftwareoathauthenticationmethodGetParameter();
            return await this.SendAsync<SoftwareoathauthenticationmethodGetParameter, SoftwareoathauthenticationmethodGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodGetResponse> SoftwareoathauthenticationmethodGetAsync(CancellationToken cancellationToken)
        {
            var p = new SoftwareoathauthenticationmethodGetParameter();
            return await this.SendAsync<SoftwareoathauthenticationmethodGetParameter, SoftwareoathauthenticationmethodGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodGetResponse> SoftwareoathauthenticationmethodGetAsync(SoftwareoathauthenticationmethodGetParameter parameter)
        {
            return await this.SendAsync<SoftwareoathauthenticationmethodGetParameter, SoftwareoathauthenticationmethodGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethod-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodGetResponse> SoftwareoathauthenticationmethodGetAsync(SoftwareoathauthenticationmethodGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SoftwareoathauthenticationmethodGetParameter, SoftwareoathauthenticationmethodGetResponse>(parameter, cancellationToken);
        }
    }
}
