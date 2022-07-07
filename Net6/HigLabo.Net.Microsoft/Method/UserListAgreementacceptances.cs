using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListAgreementacceptancesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_AgreementAcceptances,
            Users_IdOrUserPrincipalName_AgreementAcceptances,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_AgreementAcceptances: return $"/me/agreementAcceptances";
                    case ApiPath.Users_IdOrUserPrincipalName_AgreementAcceptances: return $"/users/{IdOrUserPrincipalName}/agreementAcceptances";
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
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class UserListAgreementacceptancesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/agreementacceptance?view=graph-rest-1.0
        /// </summary>
        public partial class AgreementAcceptance
        {
            public enum AgreementAcceptancestring
            {
                Accepted,
                Declined,
            }

            public string? AgreementFileId { get; set; }
            public string? AgreementId { get; set; }
            public string? DeviceDisplayName { get; set; }
            public string? DeviceId { get; set; }
            public string? DeviceOSType { get; set; }
            public string? DeviceOSVersion { get; set; }
            public DateTimeOffset? ExpirationDateTime { get; set; }
            public string? Id { get; set; }
            public DateTimeOffset? RecordedDateTime { get; set; }
            public AgreementAcceptancestring State { get; set; }
            public string? UserDisplayName { get; set; }
            public string? UserEmail { get; set; }
            public string? UserId { get; set; }
            public string? UserPrincipalName { get; set; }
        }

        public AgreementAcceptance[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-agreementacceptances?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListAgreementacceptancesResponse> UserListAgreementacceptancesAsync()
        {
            var p = new UserListAgreementacceptancesParameter();
            return await this.SendAsync<UserListAgreementacceptancesParameter, UserListAgreementacceptancesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-agreementacceptances?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListAgreementacceptancesResponse> UserListAgreementacceptancesAsync(CancellationToken cancellationToken)
        {
            var p = new UserListAgreementacceptancesParameter();
            return await this.SendAsync<UserListAgreementacceptancesParameter, UserListAgreementacceptancesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-agreementacceptances?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListAgreementacceptancesResponse> UserListAgreementacceptancesAsync(UserListAgreementacceptancesParameter parameter)
        {
            return await this.SendAsync<UserListAgreementacceptancesParameter, UserListAgreementacceptancesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-agreementacceptances?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListAgreementacceptancesResponse> UserListAgreementacceptancesAsync(UserListAgreementacceptancesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListAgreementacceptancesParameter, UserListAgreementacceptancesResponse>(parameter, cancellationToken);
        }
    }
}
