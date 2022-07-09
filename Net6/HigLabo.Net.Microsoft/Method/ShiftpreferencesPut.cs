using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ShiftpreferencesPutParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_UserId_Settings_ShiftPreferences: return $"/users/{UserId}/settings/shiftPreferences";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Users_UserId_Settings_ShiftPreferences,
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
    }
    public partial class ShiftpreferencesPutResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/shiftpreferences-put?view=graph-rest-1.0
        /// </summary>
        public async Task<ShiftpreferencesPutResponse> ShiftpreferencesPutAsync()
        {
            var p = new ShiftpreferencesPutParameter();
            return await this.SendAsync<ShiftpreferencesPutParameter, ShiftpreferencesPutResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/shiftpreferences-put?view=graph-rest-1.0
        /// </summary>
        public async Task<ShiftpreferencesPutResponse> ShiftpreferencesPutAsync(CancellationToken cancellationToken)
        {
            var p = new ShiftpreferencesPutParameter();
            return await this.SendAsync<ShiftpreferencesPutParameter, ShiftpreferencesPutResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/shiftpreferences-put?view=graph-rest-1.0
        /// </summary>
        public async Task<ShiftpreferencesPutResponse> ShiftpreferencesPutAsync(ShiftpreferencesPutParameter parameter)
        {
            return await this.SendAsync<ShiftpreferencesPutParameter, ShiftpreferencesPutResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/shiftpreferences-put?view=graph-rest-1.0
        /// </summary>
        public async Task<ShiftpreferencesPutResponse> ShiftpreferencesPutAsync(ShiftpreferencesPutParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ShiftpreferencesPutParameter, ShiftpreferencesPutResponse>(parameter, cancellationToken);
        }
    }
}
