using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securescore-get?view=graph-rest-1.0
    /// </summary>
    public partial class SecureScoreGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_SecureScores_Id: return $"/security/secureScores/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_SecureScores_Id,
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
    public partial class SecureScoreGetResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securescore-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securescore-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecureScoreGetResponse> SecureScoreGetAsync()
        {
            var p = new SecureScoreGetParameter();
            return await this.SendAsync<SecureScoreGetParameter, SecureScoreGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securescore-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecureScoreGetResponse> SecureScoreGetAsync(CancellationToken cancellationToken)
        {
            var p = new SecureScoreGetParameter();
            return await this.SendAsync<SecureScoreGetParameter, SecureScoreGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securescore-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecureScoreGetResponse> SecureScoreGetAsync(SecureScoreGetParameter parameter)
        {
            return await this.SendAsync<SecureScoreGetParameter, SecureScoreGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/securescore-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecureScoreGetResponse> SecureScoreGetAsync(SecureScoreGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecureScoreGetParameter, SecureScoreGetResponse>(parameter, cancellationToken);
        }
    }
}
