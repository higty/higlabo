using HigLabo.Web;
using HigLabo.Web.Htmx.SampleWebSite.Entity;
using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); 
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<RazorRenderer>();
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", async (HttpContext context, RazorRenderer renderer) => await renderer.WriteHtmlAsync(context, "/Pages/Root.cshtml"));
app.MapPost("/post-data", async (HttpContext context, HtmxPostData setting) => {
    var json = System.Text.Json.JsonSerializer.Serialize(setting, new JsonSerializerOptions
    {
        WriteIndented = true,
    });
    Trace.WriteLine(json);
    await context.Response.WriteAsync(json);
});
app.MapPost("/post-department-data", async (HttpContext context, Department department) => {
    var json = System.Text.Json.JsonSerializer.Serialize(department, new JsonSerializerOptions
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    });
    Trace.WriteLine(json);
    await context.Response.WriteAsync(json);
});
app.UseStaticFiles();

app.Run();
