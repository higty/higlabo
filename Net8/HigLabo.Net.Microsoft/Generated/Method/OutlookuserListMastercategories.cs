using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-list-mastercategories?view=graph-rest-1.0
    /// </summary>
    public partial class OutlookUserListMastercategoriesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Outlook_MasterCategories: return $"/me/outlook/masterCategories";
                    case ApiPath.Users_IdOruserPrincipalName_Outlook_MasterCategories: return $"/users/{IdOrUserPrincipalName}/outlook/masterCategories";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Color,
            DisplayName,
        }
        public enum ApiPath
        {
            Me_Outlook_MasterCategories,
            Users_IdOruserPrincipalName_Outlook_MasterCategories,
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
    public partial class OutlookUserListMastercategoriesResponse : RestApiResponse
    {
        public OutlookCategory[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookuser-list-mastercategories?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookuser-list-mastercategories?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OutlookUserListMastercategoriesResponse> OutlookUserListMastercategoriesAsync()
        {
            var p = new OutlookUserListMastercategoriesParameter();
            return await this.SendAsync<OutlookUserListMastercategoriesParameter, OutlookUserListMastercategoriesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookuser-list-mastercategories?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OutlookUserListMastercategoriesResponse> OutlookUserListMastercategoriesAsync(CancellationToken cancellationToken)
        {
            var p = new OutlookUserListMastercategoriesParameter();
            return await this.SendAsync<OutlookUserListMastercategoriesParameter, OutlookUserListMastercategoriesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookuser-list-mastercategories?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OutlookUserListMastercategoriesResponse> OutlookUserListMastercategoriesAsync(OutlookUserListMastercategoriesParameter parameter)
        {
            return await this.SendAsync<OutlookUserListMastercategoriesParameter, OutlookUserListMastercategoriesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookuser-list-mastercategories?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OutlookUserListMastercategoriesResponse> OutlookUserListMastercategoriesAsync(OutlookUserListMastercategoriesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OutlookUserListMastercategoriesParameter, OutlookUserListMastercategoriesResponse>(parameter, cancellationToken);
        }
    }
}
