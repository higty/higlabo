using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/outlookcategory-update?view=graph-rest-1.0
    /// </summary>
    public partial class OutlookcategoryUpdateParameter : IRestApiParameter
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
    public partial class OutlookcategoryUpdateResponse : RestApiResponse
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
        public async Task<OutlookcategoryUpdateResponse> OutlookcategoryUpdateAsync()
        {
            var p = new OutlookcategoryUpdateParameter();
            return await this.SendAsync<OutlookcategoryUpdateParameter, OutlookcategoryUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookcategory-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookcategoryUpdateResponse> OutlookcategoryUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new OutlookcategoryUpdateParameter();
            return await this.SendAsync<OutlookcategoryUpdateParameter, OutlookcategoryUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookcategory-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookcategoryUpdateResponse> OutlookcategoryUpdateAsync(OutlookcategoryUpdateParameter parameter)
        {
            return await this.SendAsync<OutlookcategoryUpdateParameter, OutlookcategoryUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/outlookcategory-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookcategoryUpdateResponse> OutlookcategoryUpdateAsync(OutlookcategoryUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OutlookcategoryUpdateParameter, OutlookcategoryUpdateResponse>(parameter, cancellationToken);
        }
    }
}
