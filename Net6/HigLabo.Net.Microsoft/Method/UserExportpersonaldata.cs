using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserExportpersonaldataParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_Id_ExportPersonalData,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_Id_ExportPersonalData: return $"/users/{Id}/exportPersonalData";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? StorageLocation { get; set; }
        public string Id { get; set; }
    }
    public partial class UserExportpersonaldataResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-exportpersonaldata?view=graph-rest-1.0
        /// </summary>
        public async Task<UserExportpersonaldataResponse> UserExportpersonaldataAsync()
        {
            var p = new UserExportpersonaldataParameter();
            return await this.SendAsync<UserExportpersonaldataParameter, UserExportpersonaldataResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-exportpersonaldata?view=graph-rest-1.0
        /// </summary>
        public async Task<UserExportpersonaldataResponse> UserExportpersonaldataAsync(CancellationToken cancellationToken)
        {
            var p = new UserExportpersonaldataParameter();
            return await this.SendAsync<UserExportpersonaldataParameter, UserExportpersonaldataResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-exportpersonaldata?view=graph-rest-1.0
        /// </summary>
        public async Task<UserExportpersonaldataResponse> UserExportpersonaldataAsync(UserExportpersonaldataParameter parameter)
        {
            return await this.SendAsync<UserExportpersonaldataParameter, UserExportpersonaldataResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-exportpersonaldata?view=graph-rest-1.0
        /// </summary>
        public async Task<UserExportpersonaldataResponse> UserExportpersonaldataAsync(UserExportpersonaldataParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserExportpersonaldataParameter, UserExportpersonaldataResponse>(parameter, cancellationToken);
        }
    }
}
