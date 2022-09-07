﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryDeleteditemsListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Directory_Deleteditems_Microsoftgraphapplication: return $"/directory/deleteditems/microsoft.graph.application";
                    case ApiPath.Directory_DeletedItems_Microsoftgraphgroup: return $"/directory/deletedItems/microsoft.graph.group";
                    case ApiPath.Directory_DeletedItems_Microsoftgraphuser: return $"/directory/deletedItems/microsoft.graph.user";
                    case ApiPath.Directory_DeletedItems_Microsoftgraphdevice: return $"/directory/deletedItems/microsoft.graph.device";
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
            Directory_Deleteditems_Microsoftgraphapplication,
            Directory_DeletedItems_Microsoftgraphgroup,
            Directory_DeletedItems_Microsoftgraphuser,
            Directory_DeletedItems_Microsoftgraphdevice,
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
    public partial class DirectoryDeleteditemsListResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsListResponse> DirectoryDeleteditemsListAsync()
        {
            var p = new DirectoryDeleteditemsListParameter();
            return await this.SendAsync<DirectoryDeleteditemsListParameter, DirectoryDeleteditemsListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsListResponse> DirectoryDeleteditemsListAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryDeleteditemsListParameter();
            return await this.SendAsync<DirectoryDeleteditemsListParameter, DirectoryDeleteditemsListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsListResponse> DirectoryDeleteditemsListAsync(DirectoryDeleteditemsListParameter parameter)
        {
            return await this.SendAsync<DirectoryDeleteditemsListParameter, DirectoryDeleteditemsListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directory-deleteditems-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryDeleteditemsListResponse> DirectoryDeleteditemsListAsync(DirectoryDeleteditemsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryDeleteditemsListParameter, DirectoryDeleteditemsListResponse>(parameter, cancellationToken);
        }
    }
}