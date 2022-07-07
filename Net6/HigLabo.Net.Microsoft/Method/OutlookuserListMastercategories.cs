using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OutlookuserListMastercategoriesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Outlook_MasterCategories,
            Users_IdOruserPrincipalName_Outlook_MasterCategories,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Outlook_MasterCategories: return $"/me/outlook/masterCategories";
                    case ApiPath.Users_IdOruserPrincipalName_Outlook_MasterCategories: return $"/users/{IdOrUserPrincipalName}/outlook/masterCategories";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class OutlookuserListMastercategoriesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/outlookcategory?view=graph-rest-1.0
        /// </summary>
        public partial class OutlookCategory
        {
            public string? DisplayName { get; set; }
            public string? Color { get; set; }
        }

        public OutlookCategory[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-list-mastercategories?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookuserListMastercategoriesResponse> OutlookuserListMastercategoriesAsync()
        {
            var p = new OutlookuserListMastercategoriesParameter();
            return await this.SendAsync<OutlookuserListMastercategoriesParameter, OutlookuserListMastercategoriesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-list-mastercategories?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookuserListMastercategoriesResponse> OutlookuserListMastercategoriesAsync(CancellationToken cancellationToken)
        {
            var p = new OutlookuserListMastercategoriesParameter();
            return await this.SendAsync<OutlookuserListMastercategoriesParameter, OutlookuserListMastercategoriesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-list-mastercategories?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookuserListMastercategoriesResponse> OutlookuserListMastercategoriesAsync(OutlookuserListMastercategoriesParameter parameter)
        {
            return await this.SendAsync<OutlookuserListMastercategoriesParameter, OutlookuserListMastercategoriesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-list-mastercategories?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookuserListMastercategoriesResponse> OutlookuserListMastercategoriesAsync(OutlookuserListMastercategoriesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OutlookuserListMastercategoriesParameter, OutlookuserListMastercategoriesResponse>(parameter, cancellationToken);
        }
    }
}
