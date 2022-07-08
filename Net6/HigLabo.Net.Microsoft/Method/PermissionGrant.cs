using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PermissionGrantParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string EncodedSharingUrl { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Shares_EncodedSharingUrl_Permission_Grant: return $"/shares/{EncodedSharingUrl}/permission/grant";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Shares_EncodedSharingUrl_Permission_Grant,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public DriveRecipient[]? Recipients { get; set; }
        public String[]? Roles { get; set; }
    }
    public partial class PermissionGrantResponse : RestApiResponse
    {
        public Permission[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permission-grant?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissionGrantResponse> PermissionGrantAsync()
        {
            var p = new PermissionGrantParameter();
            return await this.SendAsync<PermissionGrantParameter, PermissionGrantResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permission-grant?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissionGrantResponse> PermissionGrantAsync(CancellationToken cancellationToken)
        {
            var p = new PermissionGrantParameter();
            return await this.SendAsync<PermissionGrantParameter, PermissionGrantResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permission-grant?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissionGrantResponse> PermissionGrantAsync(PermissionGrantParameter parameter)
        {
            return await this.SendAsync<PermissionGrantParameter, PermissionGrantResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/permission-grant?view=graph-rest-1.0
        /// </summary>
        public async Task<PermissionGrantResponse> PermissionGrantAsync(PermissionGrantParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PermissionGrantParameter, PermissionGrantResponse>(parameter, cancellationToken);
        }
    }
}
