using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delete-acceptedsenders?view=graph-rest-1.0
    /// </summary>
    public partial class GroupDeleteAcceptedsendersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_AcceptedSenders_ref: return $"/groups/{Id}/acceptedSenders/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Groups_Id_AcceptedSenders_ref,
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
    public partial class GroupDeleteAcceptedsendersResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delete-acceptedsenders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delete-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupDeleteAcceptedsendersResponse> GroupDeleteAcceptedsendersAsync()
        {
            var p = new GroupDeleteAcceptedsendersParameter();
            return await this.SendAsync<GroupDeleteAcceptedsendersParameter, GroupDeleteAcceptedsendersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delete-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupDeleteAcceptedsendersResponse> GroupDeleteAcceptedsendersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupDeleteAcceptedsendersParameter();
            return await this.SendAsync<GroupDeleteAcceptedsendersParameter, GroupDeleteAcceptedsendersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delete-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupDeleteAcceptedsendersResponse> GroupDeleteAcceptedsendersAsync(GroupDeleteAcceptedsendersParameter parameter)
        {
            return await this.SendAsync<GroupDeleteAcceptedsendersParameter, GroupDeleteAcceptedsendersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delete-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupDeleteAcceptedsendersResponse> GroupDeleteAcceptedsendersAsync(GroupDeleteAcceptedsendersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupDeleteAcceptedsendersParameter, GroupDeleteAcceptedsendersResponse>(parameter, cancellationToken);
        }
    }
}
