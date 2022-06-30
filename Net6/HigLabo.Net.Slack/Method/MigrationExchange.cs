﻿
namespace HigLabo.Net.Slack
{
    public partial class MigrationExchangeParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "migration.exchange";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Users { get; set; }
        public string Team_Id { get; set; }
        public bool? To_Old { get; set; }
    }
    public partial class MigrationExchangeResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<MigrationExchangeResponse> MigrationExchangeAsync(string users)
        {
            var p = new MigrationExchangeParameter();
            p.Users = users;
            return await this.SendAsync<MigrationExchangeParameter, MigrationExchangeResponse>(p, CancellationToken.None);
        }
        public async Task<MigrationExchangeResponse> MigrationExchangeAsync(string users, CancellationToken cancellationToken)
        {
            var p = new MigrationExchangeParameter();
            p.Users = users;
            return await this.SendAsync<MigrationExchangeParameter, MigrationExchangeResponse>(p, cancellationToken);
        }
        public async Task<MigrationExchangeResponse> MigrationExchangeAsync(MigrationExchangeParameter parameter)
        {
            return await this.SendAsync<MigrationExchangeParameter, MigrationExchangeResponse>(parameter, CancellationToken.None);
        }
        public async Task<MigrationExchangeResponse> MigrationExchangeAsync(MigrationExchangeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<MigrationExchangeParameter, MigrationExchangeResponse>(parameter, cancellationToken);
        }
    }
}