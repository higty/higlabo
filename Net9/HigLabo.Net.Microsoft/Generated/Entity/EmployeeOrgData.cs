using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/employeeorgdata?view=graph-rest-1.0
/// </summary>
public partial class EmployeeOrgData
{
    public string? Division { get; set; }
    public string? CostCenter { get; set; }
}
