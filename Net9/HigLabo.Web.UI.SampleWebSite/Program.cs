using HigLabo.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<RazorRenderer>();
var app = builder.Build();

app.UseStaticFiles();
app.MapGet("/", async (HttpContext context, RazorRenderer renderer) => await renderer.WriteHtmlAsync(context, "/Pages/Root.cshtml"));

app.Run();
