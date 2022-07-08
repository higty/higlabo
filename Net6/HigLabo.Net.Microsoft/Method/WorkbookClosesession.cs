using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class WorkbookClosesessionParameter : IRestApiParameter
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
                    case ApiPath.Me_Drive_Items_Id_Workbook_CloseSession: return $"/me/drive/items/{Id}/workbook/closeSession";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_CloseSession: return $"/me/drive/root:/{ItemPath}:/workbook/closeSession";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_CloseSession,
            Me_Drive_Root_ItemPath_Workbook_CloseSession,
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
    public partial class WorkbookClosesessionResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-closesession?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookClosesessionResponse> WorkbookClosesessionAsync()
        {
            var p = new WorkbookClosesessionParameter();
            return await this.SendAsync<WorkbookClosesessionParameter, WorkbookClosesessionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-closesession?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookClosesessionResponse> WorkbookClosesessionAsync(CancellationToken cancellationToken)
        {
            var p = new WorkbookClosesessionParameter();
            return await this.SendAsync<WorkbookClosesessionParameter, WorkbookClosesessionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-closesession?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookClosesessionResponse> WorkbookClosesessionAsync(WorkbookClosesessionParameter parameter)
        {
            return await this.SendAsync<WorkbookClosesessionParameter, WorkbookClosesessionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/workbook-closesession?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookClosesessionResponse> WorkbookClosesessionAsync(WorkbookClosesessionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkbookClosesessionParameter, WorkbookClosesessionResponse>(parameter, cancellationToken);
        }
    }
}
