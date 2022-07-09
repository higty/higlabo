using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlaceGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Places_Id: return $"/places/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Address,
            DisplayName,
            GeoCoordinates,
            Id,
            Phone,
        }
        public enum ApiPath
        {
            Places_Id,
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
    public partial class PlaceGetResponse : RestApiResponse
    {
        public PhysicalAddress? Address { get; set; }
        public string? DisplayName { get; set; }
        public OutlookGeoCoordinates? GeoCoordinates { get; set; }
        public string? Id { get; set; }
        public string? Phone { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/place-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlaceGetResponse> PlaceGetAsync()
        {
            var p = new PlaceGetParameter();
            return await this.SendAsync<PlaceGetParameter, PlaceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/place-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlaceGetResponse> PlaceGetAsync(CancellationToken cancellationToken)
        {
            var p = new PlaceGetParameter();
            return await this.SendAsync<PlaceGetParameter, PlaceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/place-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlaceGetResponse> PlaceGetAsync(PlaceGetParameter parameter)
        {
            return await this.SendAsync<PlaceGetParameter, PlaceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/place-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PlaceGetResponse> PlaceGetAsync(PlaceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlaceGetParameter, PlaceGetResponse>(parameter, cancellationToken);
        }
    }
}
