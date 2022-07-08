using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorkbookRefreshsessionParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string ItemPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_RefreshSession: return $"/me/drive/items/{Id}/workbook/refreshSession";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_RefreshSession: return $"/me/drive/root:/{ItemPath}:/workbook/refreshSession";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_RefreshSession,
            Me_Drive_Root_ItemPath_Workbook_RefreshSession,
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
    }
    public partial class WorkbookRefreshsessionResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-refreshsession?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookRefreshsessionResponse> WorkbookRefreshsessionAsync()
        {
            var p = new WorkbookRefreshsessionParameter();
            return await this.SendAsync<WorkbookRefreshsessionParameter, WorkbookRefreshsessionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-refreshsession?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookRefreshsessionResponse> WorkbookRefreshsessionAsync(CancellationToken cancellationToken)
        {
            var p = new WorkbookRefreshsessionParameter();
            return await this.SendAsync<WorkbookRefreshsessionParameter, WorkbookRefreshsessionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-refreshsession?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookRefreshsessionResponse> WorkbookRefreshsessionAsync(WorkbookRefreshsessionParameter parameter)
        {
            return await this.SendAsync<WorkbookRefreshsessionParameter, WorkbookRefreshsessionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-refreshsession?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookRefreshsessionResponse> WorkbookRefreshsessionAsync(WorkbookRefreshsessionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkbookRefreshsessionParameter, WorkbookRefreshsessionResponse>(parameter, cancellationToken);
        }
    }
}
