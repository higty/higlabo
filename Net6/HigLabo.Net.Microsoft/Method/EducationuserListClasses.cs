using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationUserListClassesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Me_Classes: return $"/education/me/classes";
                    case ApiPath.Education_Users_Id_Classes: return $"/education/users/{Id}/classes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            DisplayName,
            MailNickname,
            Description,
            CreatedBy,
            ClassCode,
            ExternalName,
            ExternalId,
            ExternalSource,
            ExternalSourceDetail,
            Grade,
            Term,
            Assignments,
            Group,
            Members,
            Schools,
            Teachers,
            AssignmentCategories,
            AssignmentDefaults,
            AssignmentSettings,
        }
        public enum ApiPath
        {
            Education_Me_Classes,
            Education_Users_Id_Classes,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class EducationUserListClassesResponse : RestApiResponse
    {
        public EducationClass[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserListClassesResponse> EducationUserListClassesAsync()
        {
            var p = new EducationUserListClassesParameter();
            return await this.SendAsync<EducationUserListClassesParameter, EducationUserListClassesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserListClassesResponse> EducationUserListClassesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationUserListClassesParameter();
            return await this.SendAsync<EducationUserListClassesParameter, EducationUserListClassesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserListClassesResponse> EducationUserListClassesAsync(EducationUserListClassesParameter parameter)
        {
            return await this.SendAsync<EducationUserListClassesParameter, EducationUserListClassesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-list-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserListClassesResponse> EducationUserListClassesAsync(EducationUserListClassesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationUserListClassesParameter, EducationUserListClassesResponse>(parameter, cancellationToken);
        }
    }
}
