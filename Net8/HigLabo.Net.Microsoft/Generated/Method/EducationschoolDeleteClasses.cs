using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-delete-classes?view=graph-rest-1.0
    /// </summary>
    public partial class EducationSchoolDeleteClassesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? ClassId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Schools_Id_Classes_ClassId_ref: return $"/education/schools/{Id}/classes/{ClassId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Schools_Id_Classes_ClassId_ref,
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
    public partial class EducationSchoolDeleteClassesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-delete-classes?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-delete-classes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolDeleteClassesResponse> EducationSchoolDeleteClassesAsync()
        {
            var p = new EducationSchoolDeleteClassesParameter();
            return await this.SendAsync<EducationSchoolDeleteClassesParameter, EducationSchoolDeleteClassesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-delete-classes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolDeleteClassesResponse> EducationSchoolDeleteClassesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationSchoolDeleteClassesParameter();
            return await this.SendAsync<EducationSchoolDeleteClassesParameter, EducationSchoolDeleteClassesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-delete-classes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolDeleteClassesResponse> EducationSchoolDeleteClassesAsync(EducationSchoolDeleteClassesParameter parameter)
        {
            return await this.SendAsync<EducationSchoolDeleteClassesParameter, EducationSchoolDeleteClassesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-delete-classes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolDeleteClassesResponse> EducationSchoolDeleteClassesAsync(EducationSchoolDeleteClassesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationSchoolDeleteClassesParameter, EducationSchoolDeleteClassesResponse>(parameter, cancellationToken);
        }
    }
}
