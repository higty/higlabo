using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class InviteObject
{
    public string Id { get; set; } = "";
    public string Object { get; set; } = "";
    public string Email { get; set; } = "";
    public string Role { get; set; } = "";
    public string Status { get; set; } = "";
    public Int64 Invited_At { get; set; }
    public DateTimeOffset InviteTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Invited_At), TimeSpan.Zero);
        }
    }
    public Int64 Expired_At { get; set; }
    public DateTimeOffset ExpireTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expired_At), TimeSpan.Zero);
        }
    }
    public Int64 Accepted_At { get; set; }
    public DateTimeOffset AcceptTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Accepted_At), TimeSpan.Zero);
        }
    }
}
public class InviteObjectResponse: RestApiResponse
{
    public string Id { get; set; } = "";
    public string Email { get; set; } = "";
    public string Role { get; set; } = "";
    public string Status { get; set; } = "";
    public Int64 Invited_At { get; set; }
    public DateTimeOffset InviteTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Invited_At), TimeSpan.Zero);
        }
    }
    public Int64 Expired_At { get; set; }
    public DateTimeOffset ExpireTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Expired_At), TimeSpan.Zero);
        }
    }
    public Int64 Accepted_At { get; set; }
    public DateTimeOffset AcceptTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Accepted_At), TimeSpan.Zero);
        }
    }
}
