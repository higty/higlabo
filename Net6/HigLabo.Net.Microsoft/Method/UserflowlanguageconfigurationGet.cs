using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserflowlanguageconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Dentity_B2xUserFlows_Id_Languages_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Dentity_B2xUserFlows_Id_Languages_Id: return $"/dentity/b2xUserFlows/{B2xUserFlowsId}/languages/{LanguagesId}";
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
        public string B2xUserFlowsId { get; set; }
        public string LanguagesId { get; set; }
    }
    public partial class UserflowlanguageconfigurationGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public bool? IsEnabled { get; set; }
        public string? DisplayName { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageconfigurationGetResponse> UserflowlanguageconfigurationGetAsync()
        {
            var p = new UserflowlanguageconfigurationGetParameter();
            return await this.SendAsync<UserflowlanguageconfigurationGetParameter, UserflowlanguageconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageconfigurationGetResponse> UserflowlanguageconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new UserflowlanguageconfigurationGetParameter();
            return await this.SendAsync<UserflowlanguageconfigurationGetParameter, UserflowlanguageconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageconfigurationGetResponse> UserflowlanguageconfigurationGetAsync(UserflowlanguageconfigurationGetParameter parameter)
        {
            return await this.SendAsync<UserflowlanguageconfigurationGetParameter, UserflowlanguageconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userflowlanguageconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UserflowlanguageconfigurationGetResponse> UserflowlanguageconfigurationGetAsync(UserflowlanguageconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserflowlanguageconfigurationGetParameter, UserflowlanguageconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
