using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-list-taughtclasses?view=graph-rest-1.0
    /// </summary>
    public partial class EducationUserListTaughtclassesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EducationUserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Me_TaughtClasses: return $"/education/me/taughtClasses";
                    case ApiPath.Education_Users_EducationUserId_TaughtClasses: return $"/education/users/{EducationUserId}/taughtClasses";
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Groups: return $"/ttps://graph.microsoft.com/v1.0/groups";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ClassCode,
            CreatedBy,
            Description,
            DisplayName,
            ExternalId,
            ExternalSource,
            ExternalSourceDetail,
            ExternalName,
            Grade,
            Id,
            MailNickname,
            Term,
            Assignments,
            AssignmentCategories,
            AssignmentDefaults,
            AssignmentSettings,
            Group,
            Members,
            Schools,
            Teachers,
        }
        public enum ApiPath
        {
            Education_Me_TaughtClasses,
            Education_Users_EducationUserId_TaughtClasses,
            Ttps__Graphmicrosoftcom_V10_Groups,
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
    public partial class EducationUserListTaughtclassesResponse : RestApiResponse
    {
        public EducationClass[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationuser-list-taughtclasses?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationuser-list-taughtclasses?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationUserListTaughtclassesResponse> EducationUserListTaughtclassesAsync()
        {
            var p = new EducationUserListTaughtclassesParameter();
            return await this.SendAsync<EducationUserListTaughtclassesParameter, EducationUserListTaughtclassesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationuser-list-taughtclasses?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationUserListTaughtclassesResponse> EducationUserListTaughtclassesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationUserListTaughtclassesParameter();
            return await this.SendAsync<EducationUserListTaughtclassesParameter, EducationUserListTaughtclassesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationuser-list-taughtclasses?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationUserListTaughtclassesResponse> EducationUserListTaughtclassesAsync(EducationUserListTaughtclassesParameter parameter)
        {
            return await this.SendAsync<EducationUserListTaughtclassesParameter, EducationUserListTaughtclassesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationuser-list-taughtclasses?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationUserListTaughtclassesResponse> EducationUserListTaughtclassesAsync(EducationUserListTaughtclassesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationUserListTaughtclassesParameter, EducationUserListTaughtclassesResponse>(parameter, cancellationToken);
        }
    }
}
