using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list-tokenlifetimepolicies?view=graph-rest-1.0
    /// </summary>
    public partial class ApplicationListTokenlifetimepoliciesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Id_TokenLifetimePolicies: return $"/applications/{Id}/tokenLifetimePolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Definition,
            Description,
            DisplayName,
            Id,
            IsOrganizationDefault,
            AppliesTo,
        }
        public enum ApiPath
        {
            Applications_Id_TokenLifetimePolicies,
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
    public partial class ApplicationListTokenlifetimepoliciesResponse : RestApiResponse
    {
        public TokenLifetimePolicy[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list-tokenlifetimepolicies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-list-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListTokenlifetimepoliciesResponse> ApplicationListTokenlifetimepoliciesAsync()
        {
            var p = new ApplicationListTokenlifetimepoliciesParameter();
            return await this.SendAsync<ApplicationListTokenlifetimepoliciesParameter, ApplicationListTokenlifetimepoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-list-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListTokenlifetimepoliciesResponse> ApplicationListTokenlifetimepoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationListTokenlifetimepoliciesParameter();
            return await this.SendAsync<ApplicationListTokenlifetimepoliciesParameter, ApplicationListTokenlifetimepoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-list-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListTokenlifetimepoliciesResponse> ApplicationListTokenlifetimepoliciesAsync(ApplicationListTokenlifetimepoliciesParameter parameter)
        {
            return await this.SendAsync<ApplicationListTokenlifetimepoliciesParameter, ApplicationListTokenlifetimepoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-list-tokenlifetimepolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListTokenlifetimepoliciesResponse> ApplicationListTokenlifetimepoliciesAsync(ApplicationListTokenlifetimepoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationListTokenlifetimepoliciesParameter, ApplicationListTokenlifetimepoliciesResponse>(parameter, cancellationToken);
        }
    }
}
