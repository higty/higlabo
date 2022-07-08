using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ProjectromeDeleteActivityParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Activities_Id: return $"/me/activities/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Activities_Id,
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
    public partial class ProjectromeDeleteActivityResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-delete-activity?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromeDeleteActivityResponse> ProjectromeDeleteActivityAsync()
        {
            var p = new ProjectromeDeleteActivityParameter();
            return await this.SendAsync<ProjectromeDeleteActivityParameter, ProjectromeDeleteActivityResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-delete-activity?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromeDeleteActivityResponse> ProjectromeDeleteActivityAsync(CancellationToken cancellationToken)
        {
            var p = new ProjectromeDeleteActivityParameter();
            return await this.SendAsync<ProjectromeDeleteActivityParameter, ProjectromeDeleteActivityResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-delete-activity?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromeDeleteActivityResponse> ProjectromeDeleteActivityAsync(ProjectromeDeleteActivityParameter parameter)
        {
            return await this.SendAsync<ProjectromeDeleteActivityParameter, ProjectromeDeleteActivityResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/projectrome-delete-activity?view=graph-rest-1.0
        /// </summary>
        public async Task<ProjectromeDeleteActivityResponse> ProjectromeDeleteActivityAsync(ProjectromeDeleteActivityParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ProjectromeDeleteActivityParameter, ProjectromeDeleteActivityResponse>(parameter, cancellationToken);
        }
    }
}
