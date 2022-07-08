using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/sortfield?view=graph-rest-1.0
    /// </summary>
    public partial class SortField
    {
        public enum SortFieldstring
        {
            Normal,
            TextAsNumber,
        }

        public bool? Ascending { get; set; }
        public string? Color { get; set; }
        public SortFieldstring DataOption { get; set; }
        public int? Key { get; set; }
        public SortFieldstring SortOn { get; set; }
        public Icon? Icon { get; set; }
    }
}
