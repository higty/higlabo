using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OutlookUserPostMastercategoriesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string IdOrUserPrincipalName { get; set; }

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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? Color { get; set; }
    }
    public partial class OutlookUserPostMastercategoriesResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Color { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-post-mastercategories?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookUserPostMastercategoriesResponse> OutlookUserPostMastercategoriesAsync()
        {
            var p = new OutlookUserPostMastercategoriesParameter();
            return await this.SendAsync<OutlookUserPostMastercategoriesParameter, OutlookUserPostMastercategoriesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-post-mastercategories?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookUserPostMastercategoriesResponse> OutlookUserPostMastercategoriesAsync(CancellationToken cancellationToken)
        {
            var p = new OutlookUserPostMastercategoriesParameter();
            return await this.SendAsync<OutlookUserPostMastercategoriesParameter, OutlookUserPostMastercategoriesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-post-mastercategories?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookUserPostMastercategoriesResponse> OutlookUserPostMastercategoriesAsync(OutlookUserPostMastercategoriesParameter parameter)
        {
            return await this.SendAsync<OutlookUserPostMastercategoriesParameter, OutlookUserPostMastercategoriesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookuser-post-mastercategories?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookUserPostMastercategoriesResponse> OutlookUserPostMastercategoriesAsync(OutlookUserPostMastercategoriesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OutlookUserPostMastercategoriesParameter, OutlookUserPostMastercategoriesResponse>(parameter, cancellationToken);
        }
    }
}
