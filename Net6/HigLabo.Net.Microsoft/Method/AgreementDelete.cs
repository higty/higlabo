using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AgreementDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityGovernance_TermsOfUse_Agreements_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_TermsOfUse_Agreements_Id: return $"/identityGovernance/termsOfUse/agreements/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class AgreementDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/agreement-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementDeleteResponse> AgreementDeleteAsync()
        {
            var p = new AgreementDeleteParameter();
            return await this.SendAsync<AgreementDeleteParameter, AgreementDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/agreement-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementDeleteResponse> AgreementDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new AgreementDeleteParameter();
            return await this.SendAsync<AgreementDeleteParameter, AgreementDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/agreement-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementDeleteResponse> AgreementDeleteAsync(AgreementDeleteParameter parameter)
        {
            return await this.SendAsync<AgreementDeleteParameter, AgreementDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/agreement-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AgreementDeleteResponse> AgreementDeleteAsync(AgreementDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AgreementDeleteParameter, AgreementDeleteResponse>(parameter, cancellationToken);
        }
    }
}
