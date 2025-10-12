using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Net;
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
        public OrganizationAuditLogQueryParameter QueryParameter { get; set; } = new OrganizationAuditLogQueryParameter();

        string IRestApiParameter.GetApiPath()
        {
            return $"/organization/audit_logs";
        }
        public override object GetRequestBody()
        {
            return EmptyParameter;
        }
    }
    public class OrganizationAuditLogQueryParameter : IQueryParameter
    {
        /// <summary>
        /// Return only events performed by users with these emails.
        /// </summary>
        public List<string>? Actor_Emails { get; set; }
        /// <summary>
        /// Return only events performed by these actors. Can be a user ID, a service account ID, or an api key tracking ID.
        /// </summary>
        public List<string>? Actor_Ids { get; set; }
        /// <summary>
        /// A cursor for use in pagination. after is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, ending with obj_foo, your subsequent call can include after=obj_foo in order to fetch the next page of the list.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// A cursor for use in pagination. before is an object ID that defines your place in the list. For instance, if you make a list request and receive 100 objects, starting with obj_foo, your subsequent call can include before=obj_foo in order to fetch the previous page of the list.
        /// </summary>
        public string? Before { get; set; }
        /// <summary>
        /// Return only events whose effective_at (Unix seconds) is in this range.
        /// </summary>
        public object? Effective_At { get; set; }
        /// <summary>
        /// Return only events with a type in one of these values. For example, project.created. For all options, see the documentation for the audit log object.
        /// </summary>
        public List<string>? Event_Types { get; set; }
        /// <summary>
        /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the default is 20.
        /// </summary>
        public int? Limit { get; set; }
        /// <summary>
        /// Return only events for these projects.
        /// </summary>
        public List<string>? Project_Ids { get; set; }
        /// <summary>
        /// Return only events performed on these targets. For example, a project ID updated.
        /// </summary>
        public List<string>? Resource_Ids { get; set; }

        string IQueryParameter.GetQueryString()
        {
            var sb = new StringBuilder();
            if (this.Actor_Emails != null)
            {
                foreach (var item in this.Actor_Emails)
                {
                    sb.Append($"actor_emails[]={item}&");
                }
            }
            if (this.Actor_Ids != null)
            {
                foreach (var item in this.Actor_Ids)
                {
                    sb.Append($"actor_ids[]={item}&");
                }
            }
            if (this.After != null)
            {
                sb.Append($"after={WebUtility.UrlEncode(this.After)}&");
            }
            if (this.Before != null)
            {
                sb.Append($"before={WebUtility.UrlEncode(this.Before)}&");
            }
            if (this.Effective_At != null)
            {
                sb.Append($"effective_at={this.Effective_At}&");
            }
            if (this.Event_Types != null)
            {
                foreach (var item in this.Event_Types)
                {
                    sb.Append($"event_types[]={item}&");
                }
            }
            if (this.Limit != null)
            {
                sb.Append($"limit={this.Limit}&");
            }
            if (this.Project_Ids != null)
            {
                foreach (var item in this.Project_Ids)
                {
                    sb.Append($"project_ids[]={item}&");
                }
            }
            if (this.Resource_Ids != null)
            {
                foreach (var item in this.Resource_Ids)
                {
                    sb.Append($"resource_ids[]={item}&");
                }
            }
            return sb.ToString().TrimEnd('&');
        }
    }
    public partial class OrganizationAuditLogResponse : RestApiDataResponse<List<AuditLogObject>>
    {
    }
    public partial class OpenAIClient
    {
        public async ValueTask<OrganizationAuditLogResponse> OrganizationAuditLogAsync()
        {
            return await this.SendJsonAsync<OrganizationAuditLogParameter, OrganizationAuditLogResponse>(OrganizationAuditLogParameter.Empty, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationAuditLogResponse> OrganizationAuditLogAsync(CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationAuditLogParameter, OrganizationAuditLogResponse>(OrganizationAuditLogParameter.Empty, cancellationToken);
        }
        public async ValueTask<OrganizationAuditLogResponse> OrganizationAuditLogAsync(OrganizationAuditLogParameter parameter)
        {
            return await this.SendJsonAsync<OrganizationAuditLogParameter, OrganizationAuditLogResponse>(parameter, System.Threading.CancellationToken.None);
        }
        public async ValueTask<OrganizationAuditLogResponse> OrganizationAuditLogAsync(OrganizationAuditLogParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendJsonAsync<OrganizationAuditLogParameter, OrganizationAuditLogResponse>(parameter, cancellationToken);
        }
    }
}
