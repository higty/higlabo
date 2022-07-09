using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DriveitemGetContentFormatParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Me_Drive_Items_ItemId_Content: return $"/me/drive/items/{ItemId}/content";
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
            Me_Drive_Items_ItemId_Content,
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
    public partial class DriveitemGetContentFormatResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-get-content-format?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemGetContentFormatResponse> DriveitemGetContentFormatAsync()
        {
            var p = new DriveitemGetContentFormatParameter();
            return await this.SendAsync<DriveitemGetContentFormatParameter, DriveitemGetContentFormatResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-get-content-format?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemGetContentFormatResponse> DriveitemGetContentFormatAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemGetContentFormatParameter();
            return await this.SendAsync<DriveitemGetContentFormatParameter, DriveitemGetContentFormatResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-get-content-format?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemGetContentFormatResponse> DriveitemGetContentFormatAsync(DriveitemGetContentFormatParameter parameter)
        {
            return await this.SendAsync<DriveitemGetContentFormatParameter, DriveitemGetContentFormatResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-get-content-format?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemGetContentFormatResponse> DriveitemGetContentFormatAsync(DriveitemGetContentFormatParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemGetContentFormatParameter, DriveitemGetContentFormatResponse>(parameter, cancellationToken);
        }
    }
}
