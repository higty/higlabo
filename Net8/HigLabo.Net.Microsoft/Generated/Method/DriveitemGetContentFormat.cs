using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-get-content-format?view=graph-rest-1.0
    /// </summary>
    public partial class DriveItemGetContentFormatParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ItemId { get; set; }
            public string? PathAndFilename { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Drive_Items_ItemId_Content: return $"/drive/items/{ItemId}/content";
                    case ApiPath.Drive_Root_PathAndFilename_Content: return $"/drive/root:/{PathAndFilename}:/content";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Drive_Items_ItemId_Content,
            Drive_Root_PathAndFilename_Content,
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
    public partial class DriveItemGetContentFormatResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-get-content-format?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-get-content-format?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemGetContentFormatResponse> DriveItemGetContentFormatAsync()
        {
            var p = new DriveItemGetContentFormatParameter();
            return await this.SendAsync<DriveItemGetContentFormatParameter, DriveItemGetContentFormatResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-get-content-format?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemGetContentFormatResponse> DriveItemGetContentFormatAsync(CancellationToken cancellationToken)
        {
            var p = new DriveItemGetContentFormatParameter();
            return await this.SendAsync<DriveItemGetContentFormatParameter, DriveItemGetContentFormatResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-get-content-format?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemGetContentFormatResponse> DriveItemGetContentFormatAsync(DriveItemGetContentFormatParameter parameter)
        {
            return await this.SendAsync<DriveItemGetContentFormatParameter, DriveItemGetContentFormatResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/driveitem-get-content-format?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DriveItemGetContentFormatResponse> DriveItemGetContentFormatAsync(DriveItemGetContentFormatParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveItemGetContentFormatParameter, DriveItemGetContentFormatResponse>(parameter, cancellationToken);
        }
    }
}
