using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class AssistantObject
{
    public string Id { get; set; } = "";
    public string Object { get; set; } = "";
    public int Created_At { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
        }
    }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Model { get; set; } = "";
    public string Instructions { get; set; } = "";
    public List<Tool> Tools { get; set; } = new();
    public List<string>? File_Ids { get; set; }
    public object? MetaData { get; set; }

    public override string ToString()
    {
        return $"{this.Id}\r\n{this.Name}\r\n{this.Instructions}";
    }
}
public class AssistantObjectResponse: RestApiResponse
{
    public string Id { get; set; } = "";
    public int Created_At { get; set; }
    public DateTimeOffset CreateTime
    {
        get
        {
            return new DateTimeOffset(DateTime.UnixEpoch.AddSeconds(this.Created_At), TimeSpan.Zero);
        }
    }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Model { get; set; } = "";
    public string Instructions { get; set; } = "";
    public List<Tool> Tools { get; set; } = new();
    public List<string>? File_Ids { get; set; }
    public object? MetaData { get; set; }

    public override string ToString()
    {
        return $"{this.Id}\r\n{this.Name}\r\n{this.Instructions}";
    }
}
