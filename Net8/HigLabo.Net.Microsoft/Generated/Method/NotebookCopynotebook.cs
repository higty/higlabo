using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/notebook-copynotebook?view=graph-rest-1.0
    /// </summary>
    public partial class NotebookCopynotebookParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? GroupsId { get; set; }
            public string? NotebooksId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Onenote_Notebooks_Id_CopyNotebook: return $"/me/onenote/notebooks/{Id}/copyNotebook";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Notebooks_Id_CopyNotebook: return $"/users/{IdOrUserPrincipalName}/onenote/notebooks/{Id}/copyNotebook";
                    case ApiPath.Groups_Id_Onenote_Notebooks_Id_CopyNotebook: return $"/groups/{GroupsId}/onenote/notebooks/{NotebooksId}/copyNotebook";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Onenote_Notebooks_Id_CopyNotebook,
            Users_IdOrUserPrincipalName_Onenote_Notebooks_Id_CopyNotebook,
            Groups_Id_Onenote_Notebooks_Id_CopyNotebook,
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
        public string? GroupId { get; set; }
        public string? RenameAs { get; set; }
    }
    public partial class NotebookCopynotebookResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/notebook-copynotebook?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/notebook-copynotebook?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<NotebookCopynotebookResponse> NotebookCopynotebookAsync()
        {
            var p = new NotebookCopynotebookParameter();
            return await this.SendAsync<NotebookCopynotebookParameter, NotebookCopynotebookResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/notebook-copynotebook?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<NotebookCopynotebookResponse> NotebookCopynotebookAsync(CancellationToken cancellationToken)
        {
            var p = new NotebookCopynotebookParameter();
            return await this.SendAsync<NotebookCopynotebookParameter, NotebookCopynotebookResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/notebook-copynotebook?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<NotebookCopynotebookResponse> NotebookCopynotebookAsync(NotebookCopynotebookParameter parameter)
        {
            return await this.SendAsync<NotebookCopynotebookParameter, NotebookCopynotebookResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/notebook-copynotebook?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<NotebookCopynotebookResponse> NotebookCopynotebookAsync(NotebookCopynotebookParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<NotebookCopynotebookParameter, NotebookCopynotebookResponse>(parameter, cancellationToken);
        }
    }
}
