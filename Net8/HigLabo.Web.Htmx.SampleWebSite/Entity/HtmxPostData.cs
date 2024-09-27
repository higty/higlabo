namespace HigLabo.Web.Htmx.SampleWebSite.Entity
{
    public class HtmxPostData
    {
        public List<string> Permissions { get; set; } = new();
        public List<PermissionSettings> PermissionObjects { get; set; } = new();
        public List<Person> Persons { get; set; } = new();
    }
    public class PermissionSettings
    {
        public string Name { get; set; } = "";
        public string Value { get; set; } = "";
        public bool Checked { get; set; }
    }
    public class Person
    {
        public string Name { get; set; } = "";
        public int Age { get; set; } 
        public bool IsAdmin { get; set; }
    }
}
