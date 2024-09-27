namespace HigLabo.Web.Htmx.SampleWebSite.Entity
{
    public class Department
    {
        public string Name { get; set; } = "";
        public List<Department>? Departments { get; set; } 
    }
}
