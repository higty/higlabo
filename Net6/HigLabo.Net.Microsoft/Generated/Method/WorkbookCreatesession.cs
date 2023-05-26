using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workbook-createsession?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookCreatesessionParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? ItemPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Drive_Items_Id_Workbook_CreateSession: return $"/me/drive/items/{Id}/workbook/createSession";
                    case ApiPath.Me_Drive_Root_ItemPath_Workbook_CreateSession: return $"/me/drive/root:/{ItemPath}:/workbook/createSession";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Drive_Items_Id_Workbook_CreateSession,
            Me_Drive_Root_ItemPath_Workbook_CreateSession,
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
        public string? Id { get; set; }
        public bool? PersistChanges { get; set; }
    }
    public partial class WorkbookCreatesessionResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public bool? PersistChanges { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workbook-createsession?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbook-createsession?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookCreatesessionResponse> WorkbookCreatesessionAsync()
        {
            var p = new WorkbookCreatesessionParameter();
            return await this.SendAsync<WorkbookCreatesessionParameter, WorkbookCreatesessionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbook-createsession?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookCreatesessionResponse> WorkbookCreatesessionAsync(CancellationToken cancellationToken)
        {
            var p = new WorkbookCreatesessionParameter();
            return await this.SendAsync<WorkbookCreatesessionParameter, WorkbookCreatesessionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbook-createsession?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookCreatesessionResponse> WorkbookCreatesessionAsync(WorkbookCreatesessionParameter parameter)
        {
            return await this.SendAsync<WorkbookCreatesessionParameter, WorkbookCreatesessionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/workbook-createsession?view=graph-rest-1.0
        /// </summary>
        public async Task<WorkbookCreatesessionResponse> WorkbookCreatesessionAsync(WorkbookCreatesessionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<WorkbookCreatesessionParameter, WorkbookCreatesessionResponse>(parameter, cancellationToken);
        }
    }
}
