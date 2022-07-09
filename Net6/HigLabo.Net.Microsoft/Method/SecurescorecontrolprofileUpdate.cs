using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SecurescorecontrolprofileUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_SecureScoreControlProfiles_Id: return $"/security/secureScoreControlProfiles/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_SecureScoreControlProfiles_Id,
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
        public string? AssignedTo { get; set; }
        public string? Comment { get; set; }
        public string? State { get; set; }
        public SecurityVendorInformation? VendorInformation { get; set; }
    }
    public partial class SecurescorecontrolprofileUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/securescorecontrolprofile-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurescorecontrolprofileUpdateResponse> SecurescorecontrolprofileUpdateAsync()
        {
            var p = new SecurescorecontrolprofileUpdateParameter();
            return await this.SendAsync<SecurescorecontrolprofileUpdateParameter, SecurescorecontrolprofileUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/securescorecontrolprofile-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurescorecontrolprofileUpdateResponse> SecurescorecontrolprofileUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new SecurescorecontrolprofileUpdateParameter();
            return await this.SendAsync<SecurescorecontrolprofileUpdateParameter, SecurescorecontrolprofileUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/securescorecontrolprofile-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurescorecontrolprofileUpdateResponse> SecurescorecontrolprofileUpdateAsync(SecurescorecontrolprofileUpdateParameter parameter)
        {
            return await this.SendAsync<SecurescorecontrolprofileUpdateParameter, SecurescorecontrolprofileUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/securescorecontrolprofile-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurescorecontrolprofileUpdateResponse> SecurescorecontrolprofileUpdateAsync(SecurescorecontrolprofileUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurescorecontrolprofileUpdateParameter, SecurescorecontrolprofileUpdateResponse>(parameter, cancellationToken);
        }
    }
}
