using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/addlargegalleryviewoperation-get?view=graph-rest-1.0
    /// </summary>
    public partial class AddlargegalleryviewOperationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? CallId { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.App_Calls_CallId_Operations_Id: return $"/app/calls/{CallId}/operations/{Id}";
                    case ApiPath.Communications_Calls_CallId_Operations_Id: return $"/communications/calls/{CallId}/operations/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            App_Calls_CallId_Operations_Id,
            Communications_Calls_CallId_Operations_Id,
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
    public partial class AddlargegalleryviewOperationGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/addlargegalleryviewoperation-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/addlargegalleryviewoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AddlargegalleryviewOperationGetResponse> AddlargegalleryviewOperationGetAsync()
        {
            var p = new AddlargegalleryviewOperationGetParameter();
            return await this.SendAsync<AddlargegalleryviewOperationGetParameter, AddlargegalleryviewOperationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/addlargegalleryviewoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AddlargegalleryviewOperationGetResponse> AddlargegalleryviewOperationGetAsync(CancellationToken cancellationToken)
        {
            var p = new AddlargegalleryviewOperationGetParameter();
            return await this.SendAsync<AddlargegalleryviewOperationGetParameter, AddlargegalleryviewOperationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/addlargegalleryviewoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AddlargegalleryviewOperationGetResponse> AddlargegalleryviewOperationGetAsync(AddlargegalleryviewOperationGetParameter parameter)
        {
            return await this.SendAsync<AddlargegalleryviewOperationGetParameter, AddlargegalleryviewOperationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/addlargegalleryviewoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AddlargegalleryviewOperationGetResponse> AddlargegalleryviewOperationGetAsync(AddlargegalleryviewOperationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AddlargegalleryviewOperationGetParameter, AddlargegalleryviewOperationGetResponse>(parameter, cancellationToken);
        }
    }
}
