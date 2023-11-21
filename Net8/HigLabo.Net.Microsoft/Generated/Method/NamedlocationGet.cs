using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/namedlocation-get?view=graph-rest-1.0
    /// </summary>
    public partial class NamedLocationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_ConditionalAccess_NamedLocations_Id: return $"/identity/conditionalAccess/namedLocations/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedDateTime,
            DisplayName,
            Id,
            ModifiedDateTime,
        }
        public enum ApiPath
        {
            Identity_ConditionalAccess_NamedLocations_Id,
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
    public partial class NamedLocationGetResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/namedlocation-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/namedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<NamedLocationGetResponse> NamedLocationGetAsync()
        {
            var p = new NamedLocationGetParameter();
            return await this.SendAsync<NamedLocationGetParameter, NamedLocationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/namedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<NamedLocationGetResponse> NamedLocationGetAsync(CancellationToken cancellationToken)
        {
            var p = new NamedLocationGetParameter();
            return await this.SendAsync<NamedLocationGetParameter, NamedLocationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/namedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<NamedLocationGetResponse> NamedLocationGetAsync(NamedLocationGetParameter parameter)
        {
            return await this.SendAsync<NamedLocationGetParameter, NamedLocationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/namedlocation-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<NamedLocationGetResponse> NamedLocationGetAsync(NamedLocationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<NamedLocationGetParameter, NamedLocationGetResponse>(parameter, cancellationToken);
        }
    }
}
