using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-agreementacceptances?view=graph-rest-1.0
    /// </summary>
    public partial class UserListAgreementacceptancesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_AgreementAcceptances: return $"/me/agreementAcceptances";
                    case ApiPath.Users_IdOrUserPrincipalName_AgreementAcceptances: return $"/users/{IdOrUserPrincipalName}/agreementAcceptances";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AgreementFileId,
            AgreementId,
            DeviceDisplayName,
            DeviceId,
            DeviceOSType,
            DeviceOSVersion,
            ExpirationDateTime,
            Id,
            RecordedDateTime,
            State,
            UserDisplayName,
            UserEmail,
            UserId,
            UserPrincipalName,
        }
        public enum ApiPath
        {
            Me_AgreementAcceptances,
            Users_IdOrUserPrincipalName_AgreementAcceptances,
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
    public partial class UserListAgreementacceptancesResponse : RestApiResponse
    {
        public AgreementAcceptance[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-agreementacceptances?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-agreementacceptances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListAgreementacceptancesResponse> UserListAgreementacceptancesAsync()
        {
            var p = new UserListAgreementacceptancesParameter();
            return await this.SendAsync<UserListAgreementacceptancesParameter, UserListAgreementacceptancesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-agreementacceptances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListAgreementacceptancesResponse> UserListAgreementacceptancesAsync(CancellationToken cancellationToken)
        {
            var p = new UserListAgreementacceptancesParameter();
            return await this.SendAsync<UserListAgreementacceptancesParameter, UserListAgreementacceptancesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-agreementacceptances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListAgreementacceptancesResponse> UserListAgreementacceptancesAsync(UserListAgreementacceptancesParameter parameter)
        {
            return await this.SendAsync<UserListAgreementacceptancesParameter, UserListAgreementacceptancesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-agreementacceptances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListAgreementacceptancesResponse> UserListAgreementacceptancesAsync(UserListAgreementacceptancesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListAgreementacceptancesParameter, UserListAgreementacceptancesResponse>(parameter, cancellationToken);
        }
    }
}
