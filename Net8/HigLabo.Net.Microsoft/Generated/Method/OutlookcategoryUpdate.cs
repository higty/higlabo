using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookcategory-update?view=graph-rest-1.0
    /// </summary>
    public partial class OutlookCategoryUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? Color { get; set; }
    }
    public partial class OutlookCategoryUpdateResponse : RestApiResponse
    {
        public string? Color { get; set; }
        public string? DisplayName { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookcategory-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookcategory-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OutlookCategoryUpdateResponse> OutlookCategoryUpdateAsync()
        {
            var p = new OutlookCategoryUpdateParameter();
            return await this.SendAsync<OutlookCategoryUpdateParameter, OutlookCategoryUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookcategory-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OutlookCategoryUpdateResponse> OutlookCategoryUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new OutlookCategoryUpdateParameter();
            return await this.SendAsync<OutlookCategoryUpdateParameter, OutlookCategoryUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookcategory-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OutlookCategoryUpdateResponse> OutlookCategoryUpdateAsync(OutlookCategoryUpdateParameter parameter)
        {
            return await this.SendAsync<OutlookCategoryUpdateParameter, OutlookCategoryUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookcategory-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OutlookCategoryUpdateResponse> OutlookCategoryUpdateAsync(OutlookCategoryUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OutlookCategoryUpdateParameter, OutlookCategoryUpdateResponse>(parameter, cancellationToken);
        }
    }
}
