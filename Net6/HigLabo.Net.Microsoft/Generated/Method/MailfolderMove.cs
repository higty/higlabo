﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-move?view=graph-rest-1.0
    /// </summary>
    public partial class MailfolderMoveParameter : IRestApiParameter
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
                    case ApiPath.Me_MailFolders_Id_Move: return $"/me/mailFolders/{Id}/move";
                    case ApiPath.Users_IdOrUserPrincipalName_MailFolders_Id_Move: return $"/users/{IdOrUserPrincipalName}/mailFolders/{Id}/move";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_MailFolders_Id_Move,
            Users_IdOrUserPrincipalName_MailFolders_Id_Move,
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
        public string? DestinationId { get; set; }
        public Int32? ChildFolderCount { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsHidden { get; set; }
        public string? ParentFolderId { get; set; }
        public Int32? TotalItemCount { get; set; }
        public Int32? UnreadItemCount { get; set; }
        public MailFolder[]? ChildFolders { get; set; }
        public MessageRule[]? MessageRules { get; set; }
        public Message[]? Messages { get; set; }
        public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
        public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
    }
    public partial class MailfolderMoveResponse : RestApiResponse
    {
        public Int32? ChildFolderCount { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsHidden { get; set; }
        public string? ParentFolderId { get; set; }
        public Int32? TotalItemCount { get; set; }
        public Int32? UnreadItemCount { get; set; }
        public MailFolder[]? ChildFolders { get; set; }
        public MessageRule[]? MessageRules { get; set; }
        public Message[]? Messages { get; set; }
        public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
        public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/mailfolder-move?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-move?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderMoveResponse> MailfolderMoveAsync()
        {
            var p = new MailfolderMoveParameter();
            return await this.SendAsync<MailfolderMoveParameter, MailfolderMoveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-move?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderMoveResponse> MailfolderMoveAsync(CancellationToken cancellationToken)
        {
            var p = new MailfolderMoveParameter();
            return await this.SendAsync<MailfolderMoveParameter, MailfolderMoveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-move?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderMoveResponse> MailfolderMoveAsync(MailfolderMoveParameter parameter)
        {
            return await this.SendAsync<MailfolderMoveParameter, MailfolderMoveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/mailfolder-move?view=graph-rest-1.0
        /// </summary>
        public async Task<MailfolderMoveResponse> MailfolderMoveAsync(MailfolderMoveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MailfolderMoveParameter, MailfolderMoveResponse>(parameter, cancellationToken);
        }
    }
}
