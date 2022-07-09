using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupValidatepropertiesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_ValidateProperties: return $"/groups/{Id}/validateProperties";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Groups_Id_ValidateProperties,
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
        public string? MailNickname { get; set; }
        public Guid? OnBehalfOfUserId { get; set; }
    }
    public partial class GroupValidatepropertiesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-validateproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupValidatepropertiesResponse> GroupValidatepropertiesAsync()
        {
            var p = new GroupValidatepropertiesParameter();
            return await this.SendAsync<GroupValidatepropertiesParameter, GroupValidatepropertiesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-validateproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupValidatepropertiesResponse> GroupValidatepropertiesAsync(CancellationToken cancellationToken)
        {
            var p = new GroupValidatepropertiesParameter();
            return await this.SendAsync<GroupValidatepropertiesParameter, GroupValidatepropertiesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-validateproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupValidatepropertiesResponse> GroupValidatepropertiesAsync(GroupValidatepropertiesParameter parameter)
        {
            return await this.SendAsync<GroupValidatepropertiesParameter, GroupValidatepropertiesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-validateproperties?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupValidatepropertiesResponse> GroupValidatepropertiesAsync(GroupValidatepropertiesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupValidatepropertiesParameter, GroupValidatepropertiesResponse>(parameter, cancellationToken);
        }
    }
}
