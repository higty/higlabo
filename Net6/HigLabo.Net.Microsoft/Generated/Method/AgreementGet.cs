using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-get?view=graph-rest-1.0
    /// </summary>
    public partial class AgreementGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_TermsOfUse_Agreements_Id: return $"/identityGovernance/termsOfUse/agreements/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DisplayName,
            Id,
            IsPerDeviceAcceptanceRequired,
            IsViewingBeforeAcceptanceRequired,
            TermsExpiration,
            UserReacceptRequiredFrequency,
            Acceptances,
            File,
            Files,
        }
        public enum ApiPath
        {
            IdentityGovernance_TermsOfUse_Agreements_Id,
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
    public partial class AgreementGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsPerDeviceAcceptanceRequired { get; set; }
        public bool? IsViewingBeforeAcceptanceRequired { get; set; }
        public TermsExpiration? TermsExpiration { get; set; }
        public string? UserReacceptRequiredFrequency { get; set; }
        public AgreementAcceptance[]? Acceptances { get; set; }
        public AgreementFile? File { get; set; }
        public AgreementFileLocalization[]? Files { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/agreement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementGetResponse> AgreementGetAsync()
        {
            var p = new AgreementGetParameter();
            return await this.SendAsync<AgreementGetParameter, AgreementGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/agreement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementGetResponse> AgreementGetAsync(CancellationToken cancellationToken)
        {
            var p = new AgreementGetParameter();
            return await this.SendAsync<AgreementGetParameter, AgreementGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/agreement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementGetResponse> AgreementGetAsync(AgreementGetParameter parameter)
        {
            return await this.SendAsync<AgreementGetParameter, AgreementGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/agreement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementGetResponse> AgreementGetAsync(AgreementGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AgreementGetParameter, AgreementGetResponse>(parameter, cancellationToken);
        }
    }
}
