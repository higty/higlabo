using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-members?view=graph-rest-1.0
    /// </summary>
    public partial class AdministrativeunitListMembersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Directory_AdministrativeUnits_Id_Members: return $"/directory/administrativeUnits/{Id}/members";
                    case ApiPath.Directory_AdministrativeUnits_Id_Members_ref: return $"/directory/administrativeUnits/{Id}/members/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Directory_AdministrativeUnits_Id_Members,
            Directory_AdministrativeUnits_Id_Members_ref,
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
    public partial class AdministrativeunitListMembersResponse : RestApiResponse<User>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-members?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdministrativeunitListMembersResponse> AdministrativeunitListMembersAsync()
        {
            var p = new AdministrativeunitListMembersParameter();
            return await this.SendAsync<AdministrativeunitListMembersParameter, AdministrativeunitListMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdministrativeunitListMembersResponse> AdministrativeunitListMembersAsync(CancellationToken cancellationToken)
        {
            var p = new AdministrativeunitListMembersParameter();
            return await this.SendAsync<AdministrativeunitListMembersParameter, AdministrativeunitListMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdministrativeunitListMembersResponse> AdministrativeunitListMembersAsync(AdministrativeunitListMembersParameter parameter)
        {
            return await this.SendAsync<AdministrativeunitListMembersParameter, AdministrativeunitListMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdministrativeunitListMembersResponse> AdministrativeunitListMembersAsync(AdministrativeunitListMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdministrativeunitListMembersParameter, AdministrativeunitListMembersResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-members?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<User> AdministrativeunitListMembersEnumerateAsync(AdministrativeunitListMembersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AdministrativeunitListMembersParameter, AdministrativeunitListMembersResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<User>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
