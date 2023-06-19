using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public partial class SoftwareoathauthenticationmethodDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class SoftwareoathauthenticationmethodDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodDeleteResponse> SoftwareoathauthenticationmethodDeleteAsync()
        {
            var p = new SoftwareoathauthenticationmethodDeleteParameter();
            return await this.SendAsync<SoftwareoathauthenticationmethodDeleteParameter, SoftwareoathauthenticationmethodDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodDeleteResponse> SoftwareoathauthenticationmethodDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new SoftwareoathauthenticationmethodDeleteParameter();
            return await this.SendAsync<SoftwareoathauthenticationmethodDeleteParameter, SoftwareoathauthenticationmethodDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodDeleteResponse> SoftwareoathauthenticationmethodDeleteAsync(SoftwareoathauthenticationmethodDeleteParameter parameter)
        {
            return await this.SendAsync<SoftwareoathauthenticationmethodDeleteParameter, SoftwareoathauthenticationmethodDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/softwareoathauthenticationmethod-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SoftwareoathauthenticationmethodDeleteResponse> SoftwareoathauthenticationmethodDeleteAsync(SoftwareoathauthenticationmethodDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SoftwareoathauthenticationmethodDeleteParameter, SoftwareoathauthenticationmethodDeleteResponse>(parameter, cancellationToken);
        }
    }
}
