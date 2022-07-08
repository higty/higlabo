using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OutlookcategoryDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string IdOrUserPrincipalName { get; set; }

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
    public partial class OutlookcategoryDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookcategory-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookcategoryDeleteResponse> OutlookcategoryDeleteAsync()
        {
            var p = new OutlookcategoryDeleteParameter();
            return await this.SendAsync<OutlookcategoryDeleteParameter, OutlookcategoryDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookcategory-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookcategoryDeleteResponse> OutlookcategoryDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new OutlookcategoryDeleteParameter();
            return await this.SendAsync<OutlookcategoryDeleteParameter, OutlookcategoryDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookcategory-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookcategoryDeleteResponse> OutlookcategoryDeleteAsync(OutlookcategoryDeleteParameter parameter)
        {
            return await this.SendAsync<OutlookcategoryDeleteParameter, OutlookcategoryDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/outlookcategory-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OutlookcategoryDeleteResponse> OutlookcategoryDeleteAsync(OutlookcategoryDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OutlookcategoryDeleteParameter, OutlookcategoryDeleteResponse>(parameter, cancellationToken);
        }
    }
}
