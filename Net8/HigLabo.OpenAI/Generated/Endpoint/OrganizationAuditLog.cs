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
    public partial class OrganizationAuditLogParameter : RestApiParameter, IRestApiParameter, IQueryParameterProperty
    {
        internal static readonly OrganizationAuditLogParameter Empty = new OrganizationAuditLogParameter();

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
    public partial class OrganizationAuditLogResponse : RestApiDataResponse<List<AuditLogObject>>
    {
        public string First_Id { get; set; } = "";
        public string Last_Id { get; set; } = "";
        public bool Has_More { get; set; }
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationAuditLogResponse> OrganizationAuditLogAsync()
        {
            return await this.SendJsonAsync<OrganizationAuditLogParameter, OrganizationAuditLogResponse>(OrganizationAuditLogParameter.Empty, CancellationToken.None);
        }
        public async ValueTask<OrganizationAuditLogResponse> OrganizationAuditLogAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationAuditLogParameter, OrganizationAuditLogResponse>(OrganizationAuditLogParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationAuditLogResponse> OrganizationAuditLogAsync(OrganizationAuditLogParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationAuditLogParameter, OrganizationAuditLogResponse>(parameter, CancellationToken.None);
        }
        public async ValueTask<OrganizationAuditLogResponse> OrganizationAuditLogAsync(OrganizationAuditLogParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationAuditLogParameter, OrganizationAuditLogResponse>(parameter, cancellationToken);
        }
    }
}
