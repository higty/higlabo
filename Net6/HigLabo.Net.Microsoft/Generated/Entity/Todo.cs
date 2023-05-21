using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/todo?view=graph-rest-1.0
    /// </summary>
    public partial class Todo
    {
        public TodoTaskList[]? Lists { get; set; }
    }
}
