using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationassignmentdefaults-get?view=graph-rest-1.0
/// </summary>
public partial class EducationAssignmentdefaultsGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Education_Classes_Id_AssignmentDefaults: return $"/education/classes/{Id}/assignmentDefaults";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Education_Classes_Id_AssignmentDefaults,
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
public partial class EducationAssignmentdefaultsGetResponse : RestApiResponse
{
    public enum EducationAssignmentDefaultsEducationAddedStudentAction
    {
        None,
        AssignIfOpen,
    }
    public enum EducationAssignmentDefaultsEducationAddToCalendarOptions
    {
        None,
        StudentsAndPublisher,
        StudentsAndTeamOwners,
        UnknownFutureValue,
        StudentsOnly,
    }

    public EducationAssignmentDefaultsEducationAddedStudentAction AddedStudentAction { get; set; }
    public EducationAssignmentDefaultsEducationAddToCalendarOptions AddToCalendarAction { get; set; }
    public TimeOnly? DueTime { get; set; }
    public string? Id { get; set; }
    public string? NotificationChannelUrl { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/educationassignmentdefaults-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignmentdefaults-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentdefaultsGetResponse> EducationAssignmentdefaultsGetAsync()
    {
        var p = new EducationAssignmentdefaultsGetParameter();
        return await this.SendAsync<EducationAssignmentdefaultsGetParameter, EducationAssignmentdefaultsGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignmentdefaults-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentdefaultsGetResponse> EducationAssignmentdefaultsGetAsync(CancellationToken cancellationToken)
    {
        var p = new EducationAssignmentdefaultsGetParameter();
        return await this.SendAsync<EducationAssignmentdefaultsGetParameter, EducationAssignmentdefaultsGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignmentdefaults-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentdefaultsGetResponse> EducationAssignmentdefaultsGetAsync(EducationAssignmentdefaultsGetParameter parameter)
    {
        return await this.SendAsync<EducationAssignmentdefaultsGetParameter, EducationAssignmentdefaultsGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignmentdefaults-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<EducationAssignmentdefaultsGetResponse> EducationAssignmentdefaultsGetAsync(EducationAssignmentdefaultsGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<EducationAssignmentdefaultsGetParameter, EducationAssignmentdefaultsGetResponse>(parameter, cancellationToken);
    }
}
