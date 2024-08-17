using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace HigLabo.OpenAI
{
    /// <summary>
    /// List user actions and configuration changes within this organization.
    /// <seealso href="https://api.openai.com/v1/organization/audit_logs">https://api.openai.com/v1/organization/audit_logs</seealso>
    /// </summary>
    public partial class OrganizationAudit_logsParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationAudit_logsParameter Empty = new OrganizationAudit_logsParameter();

        string IRestApiParameter.HttpMethod { get; } = "GET";
        IQueryParameter IQueryParameterProperty.QueryParameter
        {
            get
            {
                return this.QueryParameter;
            }
        }
        public QueryParameter QueryParameter { get; set; } = new QueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/audit_logs";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public partial class OrganizationAudit_logsResponse : RestApiResponse
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationAudit_logsResponse> OrganizationAudit_logsAsync()
        {
            return await this.SendJsonAsync<OrganizationAudit_logsParameter, OrganizationAudit_logsResponse>(OrganizationAudit_logsParameter.Empty, CancellationToken.None);
        }
        public async ValueTask<OrganizationAudit_logsResponse> OrganizationAudit_logsAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationAudit_logsParameter, OrganizationAudit_logsResponse>(OrganizationAudit_logsParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationAudit_logsResponse> OrganizationAudit_logsAsync(OrganizationAudit_logsParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationAudit_logsParameter, OrganizationAudit_logsResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationAudit_logsResponse> OrganizationAudit_logsAsync(OrganizationAudit_logsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationAudit_logsParameter, OrganizationAudit_logsResponse>(parameter, cancellationToken);
        }
    }
}
