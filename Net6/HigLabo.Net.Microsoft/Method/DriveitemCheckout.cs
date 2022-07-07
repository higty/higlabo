using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DriveitemCheckoutParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Drives_DriveId_Items_ItemId_Checkout,
            Groups_GroupId_Drive_Items_ItemId_Checkout,
            Me_Drive_Items_ItemId_Checkout,
            Sites_SiteId_Drive_Items_ItemId_Checkout,
            Users_UserId_Drive_Items_ItemId_Checkout,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Drives_DriveId_Items_ItemId_Checkout: return $"/drives/{DriveId}/items/{ItemId}/checkout";
                    case ApiPath.Groups_GroupId_Drive_Items_ItemId_Checkout: return $"/groups/{GroupId}/drive/items/{ItemId}/checkout";
                    case ApiPath.Me_Drive_Items_ItemId_Checkout: return $"/me/drive/items/{ItemId}/checkout";
                    case ApiPath.Sites_SiteId_Drive_Items_ItemId_Checkout: return $"/sites/{SiteId}/drive/items/{ItemId}/checkout";
                    case ApiPath.Users_UserId_Drive_Items_ItemId_Checkout: return $"/users/{UserId}/drive/items/{ItemId}/checkout";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string DriveId { get; set; }
        public string ItemId { get; set; }
        public string GroupId { get; set; }
        public string SiteId { get; set; }
        public string UserId { get; set; }
    }
    public partial class DriveitemCheckoutResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-checkout?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemCheckoutResponse> DriveitemCheckoutAsync()
        {
            var p = new DriveitemCheckoutParameter();
            return await this.SendAsync<DriveitemCheckoutParameter, DriveitemCheckoutResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-checkout?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemCheckoutResponse> DriveitemCheckoutAsync(CancellationToken cancellationToken)
        {
            var p = new DriveitemCheckoutParameter();
            return await this.SendAsync<DriveitemCheckoutParameter, DriveitemCheckoutResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-checkout?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemCheckoutResponse> DriveitemCheckoutAsync(DriveitemCheckoutParameter parameter)
        {
            return await this.SendAsync<DriveitemCheckoutParameter, DriveitemCheckoutResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/driveitem-checkout?view=graph-rest-1.0
        /// </summary>
        public async Task<DriveitemCheckoutResponse> DriveitemCheckoutAsync(DriveitemCheckoutParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DriveitemCheckoutParameter, DriveitemCheckoutResponse>(parameter, cancellationToken);
        }
    }
}
