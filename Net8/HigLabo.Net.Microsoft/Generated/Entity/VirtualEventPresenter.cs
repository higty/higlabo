using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/virtualeventpresenter?view=graph-rest-1.0
    /// </summary>
    public partial class VirtualEventPresenter
    {
        public string? Email { get; set; }
        public string? Id { get; set; }
        public Identity? Identity { get; set; }
        public VirtualEventPresenterDetails? PresenterDetails { get; set; }
    }
}
