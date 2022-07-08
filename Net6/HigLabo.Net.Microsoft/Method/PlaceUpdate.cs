using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PlaceUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string IdOrEmailAddress { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Places_IdOrEmailAddress: return $"/places/{IdOrEmailAddress}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum PlaceUpdateParameterBookingType
        {
            Standard,
            Reserved,
        }
        public enum ApiPath
        {
            Places_IdOrEmailAddress,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public PhysicalAddress? Address { get; set; }
        public string? AudioDeviceName { get; set; }
        public PlaceUpdateParameterBookingType BookingType { get; set; }
        public string? Building { get; set; }
        public Int32? Capacity { get; set; }
        public string? DisplayDeviceName { get; set; }
        public string? FloorLabel { get; set; }
        public Int32? FloorNumber { get; set; }
        public OutlookGeoCoordinates? GeoCoordinates { get; set; }
        public bool? IsWheelChairAccessible { get; set; }
        public string? Label { get; set; }
        public string? Nickname { get; set; }
        public string? Phone { get; set; }
        public String[]? Tags { get; set; }
        public string? VideoDeviceName { get; set; }
    }
    public partial class PlaceUpdateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/place-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlaceUpdateResponse> PlaceUpdateAsync()
        {
            var p = new PlaceUpdateParameter();
            return await this.SendAsync<PlaceUpdateParameter, PlaceUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/place-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlaceUpdateResponse> PlaceUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new PlaceUpdateParameter();
            return await this.SendAsync<PlaceUpdateParameter, PlaceUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/place-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlaceUpdateResponse> PlaceUpdateAsync(PlaceUpdateParameter parameter)
        {
            return await this.SendAsync<PlaceUpdateParameter, PlaceUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/place-update?view=graph-rest-1.0
        /// </summary>
        public async Task<PlaceUpdateResponse> PlaceUpdateAsync(PlaceUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PlaceUpdateParameter, PlaceUpdateResponse>(parameter, cancellationToken);
        }
    }
}
