using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/usersimulationdetails-list?view=graph-rest-1.0
    /// </summary>
    public partial class UsersimulationdetailsListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SimulationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_AttackSimulation_Simulations_SimulationId_Report_SimulationUsers: return $"/security/attackSimulation/simulations/{SimulationId}/report/simulationUsers";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_AttackSimulation_Simulations_SimulationId_Report_SimulationUsers,
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
    public partial class UsersimulationdetailsListResponse : RestApiResponse
    {
        public UserSimulationDetails[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/usersimulationdetails-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/usersimulationdetails-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UsersimulationdetailsListResponse> UsersimulationdetailsListAsync()
        {
            var p = new UsersimulationdetailsListParameter();
            return await this.SendAsync<UsersimulationdetailsListParameter, UsersimulationdetailsListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/usersimulationdetails-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UsersimulationdetailsListResponse> UsersimulationdetailsListAsync(CancellationToken cancellationToken)
        {
            var p = new UsersimulationdetailsListParameter();
            return await this.SendAsync<UsersimulationdetailsListParameter, UsersimulationdetailsListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/usersimulationdetails-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UsersimulationdetailsListResponse> UsersimulationdetailsListAsync(UsersimulationdetailsListParameter parameter)
        {
            return await this.SendAsync<UsersimulationdetailsListParameter, UsersimulationdetailsListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/usersimulationdetails-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UsersimulationdetailsListResponse> UsersimulationdetailsListAsync(UsersimulationdetailsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersimulationdetailsListParameter, UsersimulationdetailsListResponse>(parameter, cancellationToken);
        }
    }
}
