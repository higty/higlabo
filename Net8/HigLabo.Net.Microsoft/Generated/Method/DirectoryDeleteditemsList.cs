using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-list?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryDeletedItemsListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Directory_Deleteditems_Microsoftgraphapplication: return $"/directory/deleteditems/microsoft.graph.application";
                    case ApiPath.Directory_Deleteditems_MicrosoftgraphservicePrincipal: return $"/directory/deleteditems/microsoft.graph.servicePrincipal";
                    case ApiPath.Directory_DeletedItems_Microsoftgraphgroup: return $"/directory/deletedItems/microsoft.graph.group";
                    case ApiPath.Directory_DeletedItems_Microsoftgraphuser: return $"/directory/deletedItems/microsoft.graph.user";
                    case ApiPath.Directory_DeletedItems_MicrosoftgraphadministrativeUnit: return $"/directory/deletedItems/microsoft.graph.administrativeUnit";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Directory_Deleteditems_Microsoftgraphapplication,
            Directory_Deleteditems_MicrosoftgraphservicePrincipal,
            Directory_DeletedItems_Microsoftgraphgroup,
            Directory_DeletedItems_Microsoftgraphuser,
            Directory_DeletedItems_MicrosoftgraphadministrativeUnit,
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
    public partial class DirectoryDeletedItemsListResponse : RestApiResponse<DirectoryObject>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryDeletedItemsListResponse> DirectoryDeletedItemsListAsync()
        {
            var p = new DirectoryDeletedItemsListParameter();
            return await this.SendAsync<DirectoryDeletedItemsListParameter, DirectoryDeletedItemsListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryDeletedItemsListResponse> DirectoryDeletedItemsListAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryDeletedItemsListParameter();
            return await this.SendAsync<DirectoryDeletedItemsListParameter, DirectoryDeletedItemsListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryDeletedItemsListResponse> DirectoryDeletedItemsListAsync(DirectoryDeletedItemsListParameter parameter)
        {
            return await this.SendAsync<DirectoryDeletedItemsListParameter, DirectoryDeletedItemsListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryDeletedItemsListResponse> DirectoryDeletedItemsListAsync(DirectoryDeletedItemsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryDeletedItemsListParameter, DirectoryDeletedItemsListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directory-deleteditems-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DirectoryObject> DirectoryDeletedItemsListEnumerateAsync(DirectoryDeletedItemsListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<DirectoryDeletedItemsListParameter, DirectoryDeletedItemsListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DirectoryObject>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
