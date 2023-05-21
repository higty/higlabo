using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/attachment-createuploadsession?view=graph-rest-1.0
    /// </summary>
    public partial class AttachmentCreateuploadsessionParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Events_Id_Attachments_CreateUploadSession: return $"/me/events/{Id}/attachments/createUploadSession";
                    case ApiPath.Users_IdOrUserPrincipalName_Events_Id_Attachments_CreateUploadSession: return $"/users/{IdOrUserPrincipalName}/events/{Id}/attachments/createUploadSession";
                    case ApiPath.Me_Messages_Id_Attachments_CreateUploadSession: return $"/me/messages/{Id}/attachments/createUploadSession";
                    case ApiPath.Users_IdOrUserPrincipalName_Messages_Id_Attachments_CreateUploadSession: return $"/users/{IdOrUserPrincipalName}/messages/{Id}/attachments/createUploadSession";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Events_Id_Attachments_CreateUploadSession,
            Users_IdOrUserPrincipalName_Events_Id_Attachments_CreateUploadSession,
            Me_Messages_Id_Attachments_CreateUploadSession,
            Users_IdOrUserPrincipalName_Messages_Id_Attachments_CreateUploadSession,
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
        public AttachmentItem? AttachmentItem { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public String[]? NextExpectedRanges { get; set; }
        public string? UploadUrl { get; set; }
    }
    public partial class AttachmentCreateuploadsessionResponse : RestApiResponse
    {
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public String[]? NextExpectedRanges { get; set; }
        public string? UploadUrl { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/attachment-createuploadsession?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attachment-createuploadsession?view=graph-rest-1.0
        /// </summary>
        public async Task<AttachmentCreateuploadsessionResponse> AttachmentCreateuploadsessionAsync()
        {
            var p = new AttachmentCreateuploadsessionParameter();
            return await this.SendAsync<AttachmentCreateuploadsessionParameter, AttachmentCreateuploadsessionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attachment-createuploadsession?view=graph-rest-1.0
        /// </summary>
        public async Task<AttachmentCreateuploadsessionResponse> AttachmentCreateuploadsessionAsync(CancellationToken cancellationToken)
        {
            var p = new AttachmentCreateuploadsessionParameter();
            return await this.SendAsync<AttachmentCreateuploadsessionParameter, AttachmentCreateuploadsessionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attachment-createuploadsession?view=graph-rest-1.0
        /// </summary>
        public async Task<AttachmentCreateuploadsessionResponse> AttachmentCreateuploadsessionAsync(AttachmentCreateuploadsessionParameter parameter)
        {
            return await this.SendAsync<AttachmentCreateuploadsessionParameter, AttachmentCreateuploadsessionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/attachment-createuploadsession?view=graph-rest-1.0
        /// </summary>
        public async Task<AttachmentCreateuploadsessionResponse> AttachmentCreateuploadsessionAsync(AttachmentCreateuploadsessionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AttachmentCreateuploadsessionParameter, AttachmentCreateuploadsessionResponse>(parameter, cancellationToken);
        }
    }
}
