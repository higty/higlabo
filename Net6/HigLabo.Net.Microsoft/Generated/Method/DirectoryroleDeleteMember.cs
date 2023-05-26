using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-delete-member?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryroleDeleteMemberParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? RoleId { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.DirectoryRoles_RoleId_Members_Id_ref: return $"/directoryRoles/{RoleId}/members/{Id}/$ref";
                    case ApiPath.DirectoryRoles: return $"/directoryRoles";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            DirectoryRoles_RoleId_Members_Id_ref,
            DirectoryRoles,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class DirectoryroleDeleteMemberResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-delete-member?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryrole-delete-member?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleDeleteMemberResponse> DirectoryroleDeleteMemberAsync()
        {
            var p = new DirectoryroleDeleteMemberParameter();
            return await this.SendAsync<DirectoryroleDeleteMemberParameter, DirectoryroleDeleteMemberResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryrole-delete-member?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleDeleteMemberResponse> DirectoryroleDeleteMemberAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryroleDeleteMemberParameter();
            return await this.SendAsync<DirectoryroleDeleteMemberParameter, DirectoryroleDeleteMemberResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryrole-delete-member?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleDeleteMemberResponse> DirectoryroleDeleteMemberAsync(DirectoryroleDeleteMemberParameter parameter)
        {
            return await this.SendAsync<DirectoryroleDeleteMemberParameter, DirectoryroleDeleteMemberResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryrole-delete-member?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleDeleteMemberResponse> DirectoryroleDeleteMemberAsync(DirectoryroleDeleteMemberParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryroleDeleteMemberParameter, DirectoryroleDeleteMemberResponse>(parameter, cancellationToken);
        }
    }
}
