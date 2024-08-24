using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookcategory-delete?view=graph-rest-1.0
    /// </summary>
    public partial class OutlookCategoryDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Outlook_MasterCategories_Id: return $"/me/outlook/masterCategories/{Id}";
                    case ApiPath.Users_IdOruserPrincipalName_Outlook_MasterCategories_Id: return $"/users/{IdOrUserPrincipalName}/outlook/masterCategories/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Outlook_MasterCategories_Id,
            Users_IdOruserPrincipalName_Outlook_MasterCategories_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class OutlookCategoryDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookcategory-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookcategory-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OutlookCategoryDeleteResponse> OutlookCategoryDeleteAsync()
        {
            var p = new OutlookCategoryDeleteParameter();
            return await this.SendAsync<OutlookCategoryDeleteParameter, OutlookCategoryDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookcategory-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OutlookCategoryDeleteResponse> OutlookCategoryDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new OutlookCategoryDeleteParameter();
            return await this.SendAsync<OutlookCategoryDeleteParameter, OutlookCategoryDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookcategory-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OutlookCategoryDeleteResponse> OutlookCategoryDeleteAsync(OutlookCategoryDeleteParameter parameter)
        {
            return await this.SendAsync<OutlookCategoryDeleteParameter, OutlookCategoryDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookcategory-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OutlookCategoryDeleteResponse> OutlookCategoryDeleteAsync(OutlookCategoryDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OutlookCategoryDeleteParameter, OutlookCategoryDeleteResponse>(parameter, cancellationToken);
        }
    }
}
