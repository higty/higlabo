using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationschoolDeleteUsersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Schools_Id_Users_UserId_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Schools_Id_Users_UserId_ref: return $"/education/schools/{Id}/users/{UserId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
        public string UserId { get; set; }
    }
    public partial class EducationschoolDeleteUsersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delete-users?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolDeleteUsersResponse> EducationschoolDeleteUsersAsync()
        {
            var p = new EducationschoolDeleteUsersParameter();
            return await this.SendAsync<EducationschoolDeleteUsersParameter, EducationschoolDeleteUsersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delete-users?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolDeleteUsersResponse> EducationschoolDeleteUsersAsync(CancellationToken cancellationToken)
        {
            var p = new EducationschoolDeleteUsersParameter();
            return await this.SendAsync<EducationschoolDeleteUsersParameter, EducationschoolDeleteUsersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delete-users?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolDeleteUsersResponse> EducationschoolDeleteUsersAsync(EducationschoolDeleteUsersParameter parameter)
        {
            return await this.SendAsync<EducationschoolDeleteUsersParameter, EducationschoolDeleteUsersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delete-users?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolDeleteUsersResponse> EducationschoolDeleteUsersAsync(EducationschoolDeleteUsersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationschoolDeleteUsersParameter, EducationschoolDeleteUsersResponse>(parameter, cancellationToken);
        }
    }
}
