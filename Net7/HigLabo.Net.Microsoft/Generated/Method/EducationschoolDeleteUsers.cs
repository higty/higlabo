using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-delete-users?view=graph-rest-1.0
    /// </summary>
    public partial class EducationSchoolDeleteUsersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Schools_Id_Users_UserId_ref: return $"/education/schools/{Id}/users/{UserId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Schools_Id_Users_UserId_ref,
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
    public partial class EducationSchoolDeleteUsersResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-delete-users?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-delete-users?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolDeleteUsersResponse> EducationSchoolDeleteUsersAsync()
        {
            var p = new EducationSchoolDeleteUsersParameter();
            return await this.SendAsync<EducationSchoolDeleteUsersParameter, EducationSchoolDeleteUsersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-delete-users?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolDeleteUsersResponse> EducationSchoolDeleteUsersAsync(CancellationToken cancellationToken)
        {
            var p = new EducationSchoolDeleteUsersParameter();
            return await this.SendAsync<EducationSchoolDeleteUsersParameter, EducationSchoolDeleteUsersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-delete-users?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolDeleteUsersResponse> EducationSchoolDeleteUsersAsync(EducationSchoolDeleteUsersParameter parameter)
        {
            return await this.SendAsync<EducationSchoolDeleteUsersParameter, EducationSchoolDeleteUsersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-delete-users?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolDeleteUsersResponse> EducationSchoolDeleteUsersAsync(EducationSchoolDeleteUsersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationSchoolDeleteUsersParameter, EducationSchoolDeleteUsersResponse>(parameter, cancellationToken);
        }
    }
}
