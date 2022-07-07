using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListLicensedetailsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_LicenseDetails,
            Users_Id_LicenseDetails,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_LicenseDetails: return $"/me/licenseDetails";
                    case ApiPath.Users_Id_LicenseDetails: return $"/users/{Id}/licenseDetails";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string Id { get; set; }
    }
    public partial class UserListLicensedetailsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/licensedetails?view=graph-rest-1.0
        /// </summary>
        public partial class LicenseDetails
        {
            public string? Id { get; set; }
            public ServicePlanInfo[]? ServicePlans { get; set; }
            public Guid? SkuId { get; set; }
            public string? SkuPartNumber { get; set; }
        }

        public LicenseDetails[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-licensedetails?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListLicensedetailsResponse> UserListLicensedetailsAsync()
        {
            var p = new UserListLicensedetailsParameter();
            return await this.SendAsync<UserListLicensedetailsParameter, UserListLicensedetailsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-licensedetails?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListLicensedetailsResponse> UserListLicensedetailsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListLicensedetailsParameter();
            return await this.SendAsync<UserListLicensedetailsParameter, UserListLicensedetailsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-licensedetails?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListLicensedetailsResponse> UserListLicensedetailsAsync(UserListLicensedetailsParameter parameter)
        {
            return await this.SendAsync<UserListLicensedetailsParameter, UserListLicensedetailsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-licensedetails?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListLicensedetailsResponse> UserListLicensedetailsAsync(UserListLicensedetailsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListLicensedetailsParameter, UserListLicensedetailsResponse>(parameter, cancellationToken);
        }
    }
}
