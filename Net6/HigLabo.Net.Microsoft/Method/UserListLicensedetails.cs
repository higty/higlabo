using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-licensedetails?view=graph-rest-1.0
    /// </summary>
    public partial class UserListLicensedetailsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_LicenseDetails: return $"/me/licenseDetails";
                    case ApiPath.Users_Id_LicenseDetails: return $"/users/{Id}/licenseDetails";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_LicenseDetails,
            Users_Id_LicenseDetails,
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
    public partial class UserListLicensedetailsResponse : RestApiResponse
    {
        public LicenseDetails[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-licensedetails?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-licensedetails?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListLicensedetailsResponse> UserListLicensedetailsAsync()
        {
            var p = new UserListLicensedetailsParameter();
            return await this.SendAsync<UserListLicensedetailsParameter, UserListLicensedetailsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-licensedetails?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListLicensedetailsResponse> UserListLicensedetailsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListLicensedetailsParameter();
            return await this.SendAsync<UserListLicensedetailsParameter, UserListLicensedetailsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-licensedetails?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListLicensedetailsResponse> UserListLicensedetailsAsync(UserListLicensedetailsParameter parameter)
        {
            return await this.SendAsync<UserListLicensedetailsParameter, UserListLicensedetailsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-licensedetails?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListLicensedetailsResponse> UserListLicensedetailsAsync(UserListLicensedetailsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListLicensedetailsParameter, UserListLicensedetailsResponse>(parameter, cancellationToken);
        }
    }
}
