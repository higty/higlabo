using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-getuserownedobjects?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryDeleteditemsGetUserownedobjectsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Directory_DeletedItems_GetUserOwnedObjects: return $"/directory/deletedItems/getUserOwnedObjects";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Directory_DeletedItems_GetUserOwnedObjects,
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
        public string? UserId { get; set; }
        public string? Type { get; set; }
        public string? Id { get; set; }
        public AdministrativeUnit[]? AdministrativeUnits { get; set; }
        public DirectoryObject[]? DeletedItems { get; set; }
        public IdentityProviderBase[]? FederationConfigurations { get; set; }
        public OnPremisesDirectorySynchronization? OnPremisesSynchronization { get; set; }
    }
    public partial class DirectoryDeleteditemsGetUserownedobjectsResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public AdministrativeUnit[]? AdministrativeUnits { get; set; }
        public DirectoryObject[]? DeletedItems { get; set; }
        public IdentityProviderBase[]? FederationConfigurations { get; set; }
        public OnPremisesDirectorySynchronization? OnPremisesSynchronization { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-getuserownedobjects?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-getuserownedobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsGetUserownedobjectsResponse> DirectoryDeleteditemsGetUserownedobjectsAsync()
        {
            var p = new DirectoryDeleteditemsGetUserownedobjectsParameter();
            return await this.SendAsync<DirectoryDeleteditemsGetUserownedobjectsParameter, DirectoryDeleteditemsGetUserownedobjectsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-getuserownedobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsGetUserownedobjectsResponse> DirectoryDeleteditemsGetUserownedobjectsAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryDeleteditemsGetUserownedobjectsParameter();
            return await this.SendAsync<DirectoryDeleteditemsGetUserownedobjectsParameter, DirectoryDeleteditemsGetUserownedobjectsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-getuserownedobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsGetUserownedobjectsResponse> DirectoryDeleteditemsGetUserownedobjectsAsync(DirectoryDeleteditemsGetUserownedobjectsParameter parameter)
        {
            return await this.SendAsync<DirectoryDeleteditemsGetUserownedobjectsParameter, DirectoryDeleteditemsGetUserownedobjectsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-getuserownedobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsGetUserownedobjectsResponse> DirectoryDeleteditemsGetUserownedobjectsAsync(DirectoryDeleteditemsGetUserownedobjectsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryDeleteditemsGetUserownedobjectsParameter, DirectoryDeleteditemsGetUserownedobjectsResponse>(parameter, cancellationToken);
        }
    }
}
