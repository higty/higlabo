using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class NotebookCopynotebookParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Onenote_Notebooks_Id_CopyNotebook,
            Users_IdOrUserPrincipalName_Onenote_Notebooks_Id_CopyNotebook,
            Groups_Id_Onenote_Notebooks_Id_CopyNotebook,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Onenote_Notebooks_Id_CopyNotebook: return $"/me/onenote/notebooks/{Id}/copyNotebook";
                    case ApiPath.Users_IdOrUserPrincipalName_Onenote_Notebooks_Id_CopyNotebook: return $"/users/{IdOrUserPrincipalName}/onenote/notebooks/{Id}/copyNotebook";
                    case ApiPath.Groups_Id_Onenote_Notebooks_Id_CopyNotebook: return $"/groups/{GroupsId}/onenote/notebooks/{NotebooksId}/copyNotebook";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? GroupId { get; set; }
        public string? RenameAs { get; set; }
        public string Id { get; set; }
        public string IdOrUserPrincipalName { get; set; }
        public string GroupsId { get; set; }
        public string NotebooksId { get; set; }
    }
    public partial class NotebookCopynotebookResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-copynotebook?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookCopynotebookResponse> NotebookCopynotebookAsync()
        {
            var p = new NotebookCopynotebookParameter();
            return await this.SendAsync<NotebookCopynotebookParameter, NotebookCopynotebookResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-copynotebook?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookCopynotebookResponse> NotebookCopynotebookAsync(CancellationToken cancellationToken)
        {
            var p = new NotebookCopynotebookParameter();
            return await this.SendAsync<NotebookCopynotebookParameter, NotebookCopynotebookResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-copynotebook?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookCopynotebookResponse> NotebookCopynotebookAsync(NotebookCopynotebookParameter parameter)
        {
            return await this.SendAsync<NotebookCopynotebookParameter, NotebookCopynotebookResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/notebook-copynotebook?view=graph-rest-1.0
        /// </summary>
        public async Task<NotebookCopynotebookResponse> NotebookCopynotebookAsync(NotebookCopynotebookParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<NotebookCopynotebookParameter, NotebookCopynotebookResponse>(parameter, cancellationToken);
        }
    }
}
