using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/shift-put?view=graph-rest-1.0
    /// </summary>
    public partial class ShiftPutParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? ShiftId { get; set; }

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
        string IRestApiParameter.HttpMethod { get; } = "PUT";
    }
    public partial class ShiftPutResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public ShiftItem? DraftShift { get; set; }
        public string? Id { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? SchedulingGroupId { get; set; }
        public ShiftItem? SharedShift { get; set; }
        public string? UserId { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/shift-put?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/shift-put?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ShiftPutResponse> ShiftPutAsync()
        {
            var p = new ShiftPutParameter();
            return await this.SendAsync<ShiftPutParameter, ShiftPutResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/shift-put?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ShiftPutResponse> ShiftPutAsync(CancellationToken cancellationToken)
        {
            var p = new ShiftPutParameter();
            return await this.SendAsync<ShiftPutParameter, ShiftPutResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/shift-put?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ShiftPutResponse> ShiftPutAsync(ShiftPutParameter parameter)
        {
            return await this.SendAsync<ShiftPutParameter, ShiftPutResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/shift-put?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ShiftPutResponse> ShiftPutAsync(ShiftPutParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ShiftPutParameter, ShiftPutResponse>(parameter, cancellationToken);
        }
    }
}
