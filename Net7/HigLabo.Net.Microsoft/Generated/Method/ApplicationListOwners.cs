using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list-owners?view=graph-rest-1.0
    /// </summary>
    public partial class ApplicationListOwnersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Id_Owners: return $"/applications/{Id}/owners";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DeletedDateTime,
            Id,
        }
        public enum ApiPath
        {
            Applications_Id_Owners,
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
    public partial class ApplicationListOwnersResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-list-owners?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListOwnersResponse> ApplicationListOwnersAsync()
        {
            var p = new ApplicationListOwnersParameter();
            return await this.SendAsync<ApplicationListOwnersParameter, ApplicationListOwnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListOwnersResponse> ApplicationListOwnersAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationListOwnersParameter();
            return await this.SendAsync<ApplicationListOwnersParameter, ApplicationListOwnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListOwnersResponse> ApplicationListOwnersAsync(ApplicationListOwnersParameter parameter)
        {
            return await this.SendAsync<ApplicationListOwnersParameter, ApplicationListOwnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/application-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationListOwnersResponse> ApplicationListOwnersAsync(ApplicationListOwnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationListOwnersParameter, ApplicationListOwnersResponse>(parameter, cancellationToken);
        }
    }
}
