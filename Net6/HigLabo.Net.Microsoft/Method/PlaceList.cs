using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlaceListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Places_Microsoftgraphroom,
            Places_Microsoftgraphroomlist,
            Places_RoomListEmailaddress_Microsoftgraphroomlist_Rooms,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Places_Microsoftgraphroom: return $"/places/microsoft.graph.room";
                    case ApiPath.Places_Microsoftgraphroomlist: return $"/places/microsoft.graph.roomlist";
                    case ApiPath.Places_RoomListEmailaddress_Microsoftgraphroomlist_Rooms: return $"/places/{RoomListEmailaddress}/microsoft.graph.roomlist/rooms";
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
        public string RoomListEmailaddress { get; set; }
    }
    public partial class PlaceListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/place?view=graph-rest-1.0
        /// </summary>
        public partial class Place
        {
            public PhysicalAddress? Address { get; set; }
            public string? DisplayName { get; set; }
            public OutlookGeoCoordinates? GeoCoordinates { get; set; }
            public string? Id { get; set; }
            public string? Phone { get; set; }
        }

        public Place[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/place-list?view=graph-rest-1.0
        /// </summary>
        public async Task<PlaceListResponse> PlaceListAsync()
        {
            var p = new PlaceListParameter();
            return await this.SendAsync<PlaceListParameter, PlaceListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/place-list?view=graph-rest-1.0
        /// </summary>
        public async Task<PlaceListResponse> PlaceListAsync(CancellationToken cancellationToken)
        {
            var p = new PlaceListParameter();
            return await this.SendAsync<PlaceListParameter, PlaceListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/place-list?view=graph-rest-1.0
        /// </summary>
        public async Task<PlaceListResponse> PlaceListAsync(PlaceListParameter parameter)
        {
            return await this.SendAsync<PlaceListParameter, PlaceListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/place-list?view=graph-rest-1.0
        /// </summary>
        public async Task<PlaceListResponse> PlaceListAsync(PlaceListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlaceListParameter, PlaceListResponse>(parameter, cancellationToken);
        }
    }
}
