using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingOnpremisesconditionalaccesssettingsGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_ConditionalAccessSettings,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_ConditionalAccessSettings: return $"/deviceManagement/conditionalAccessSettings";
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
    }
    public partial class IntuneOnboardingOnpremisesconditionalaccesssettingsGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public bool? Enabled { get; set; }
        public Guid[]? IncludedGroups { get; set; }
        public Guid[]? ExcludedGroups { get; set; }
        public bool? OverrideDefaultRule { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-onpremisesconditionalaccesssettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingOnpremisesconditionalaccesssettingsGetResponse> IntuneOnboardingOnpremisesconditionalaccesssettingsGetAsync()
        {
            var p = new IntuneOnboardingOnpremisesconditionalaccesssettingsGetParameter();
            return await this.SendAsync<IntuneOnboardingOnpremisesconditionalaccesssettingsGetParameter, IntuneOnboardingOnpremisesconditionalaccesssettingsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-onpremisesconditionalaccesssettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingOnpremisesconditionalaccesssettingsGetResponse> IntuneOnboardingOnpremisesconditionalaccesssettingsGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingOnpremisesconditionalaccesssettingsGetParameter();
            return await this.SendAsync<IntuneOnboardingOnpremisesconditionalaccesssettingsGetParameter, IntuneOnboardingOnpremisesconditionalaccesssettingsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-onpremisesconditionalaccesssettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingOnpremisesconditionalaccesssettingsGetResponse> IntuneOnboardingOnpremisesconditionalaccesssettingsGetAsync(IntuneOnboardingOnpremisesconditionalaccesssettingsGetParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingOnpremisesconditionalaccesssettingsGetParameter, IntuneOnboardingOnpremisesconditionalaccesssettingsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-onpremisesconditionalaccesssettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingOnpremisesconditionalaccesssettingsGetResponse> IntuneOnboardingOnpremisesconditionalaccesssettingsGetAsync(IntuneOnboardingOnpremisesconditionalaccesssettingsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingOnpremisesconditionalaccesssettingsGetParameter, IntuneOnboardingOnpremisesconditionalaccesssettingsGetResponse>(parameter, cancellationToken);
        }
    }
}
