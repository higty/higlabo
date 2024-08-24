using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-addlargegalleryview?view=graph-rest-1.0
    /// </summary>
    public partial class CallAddLargeGalleryviewParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.App_Calls_Id_AddLargeGalleryView: return $"/app/calls/{Id}/addLargeGalleryView";
                    case ApiPath.Communications_Calls_Id_AddLargeGalleryView: return $"/communications/calls/{Id}/addLargeGalleryView";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum AddLargeGalleryViewOperationOperationStatus
        {
            NotStarted,
            Running,
            Completed,
            Failed,
        }
        public enum ApiPath
        {
            App_Calls_Id_AddLargeGalleryView,
            Communications_Calls_Id_AddLargeGalleryView,
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
        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public AddLargeGalleryViewOperationOperationStatus Status { get; set; }
    }
    public partial class CallAddLargeGalleryviewResponse : RestApiResponse
    {
        public enum AddLargeGalleryViewOperationOperationStatus
        {
            NotStarted,
            Running,
            Completed,
            Failed,
        }

        public string? ClientContext { get; set; }
        public string? Id { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public AddLargeGalleryViewOperationOperationStatus Status { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-addlargegalleryview?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-addlargegalleryview?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallAddLargeGalleryviewResponse> CallAddLargeGalleryviewAsync()
        {
            var p = new CallAddLargeGalleryviewParameter();
            return await this.SendAsync<CallAddLargeGalleryviewParameter, CallAddLargeGalleryviewResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-addlargegalleryview?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallAddLargeGalleryviewResponse> CallAddLargeGalleryviewAsync(CancellationToken cancellationToken)
        {
            var p = new CallAddLargeGalleryviewParameter();
            return await this.SendAsync<CallAddLargeGalleryviewParameter, CallAddLargeGalleryviewResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-addlargegalleryview?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallAddLargeGalleryviewResponse> CallAddLargeGalleryviewAsync(CallAddLargeGalleryviewParameter parameter)
        {
            return await this.SendAsync<CallAddLargeGalleryviewParameter, CallAddLargeGalleryviewResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/call-addlargegalleryview?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<CallAddLargeGalleryviewResponse> CallAddLargeGalleryviewAsync(CallAddLargeGalleryviewParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallAddLargeGalleryviewParameter, CallAddLargeGalleryviewResponse>(parameter, cancellationToken);
        }
    }
}
