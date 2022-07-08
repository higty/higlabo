using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ShiftDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string TeamId { get; set; }
            public string ShiftId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Schedule_Shifts_ShiftId: return $"/teams/{TeamId}/schedule/shifts/{ShiftId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Schedule_Shifts_ShiftId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class ShiftDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/shift-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ShiftDeleteResponse> ShiftDeleteAsync()
        {
            var p = new ShiftDeleteParameter();
            return await this.SendAsync<ShiftDeleteParameter, ShiftDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/shift-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ShiftDeleteResponse> ShiftDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ShiftDeleteParameter();
            return await this.SendAsync<ShiftDeleteParameter, ShiftDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/shift-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ShiftDeleteResponse> ShiftDeleteAsync(ShiftDeleteParameter parameter)
        {
            return await this.SendAsync<ShiftDeleteParameter, ShiftDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/shift-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ShiftDeleteResponse> ShiftDeleteAsync(ShiftDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ShiftDeleteParameter, ShiftDeleteResponse>(parameter, cancellationToken);
        }
    }
}
