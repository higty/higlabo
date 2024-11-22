using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class ProjectServiceAccountObject
{
    public string Id { get; set; } = "";
    public string Object { get; set; } = "";
    public string Name { get; set; } = "";
    public string Role { get; set; } = "";
    public Int64 Created_At { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
        }
    }
}
public class ProjectServiceAccountObjectResponse : RestApiResponse
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Role { get; set; } = "";
    public Int64 Created_At { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
        }
    }
}
