using HelloWorld;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;

Console.WriteLine("HI TESTER");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<HelloWorldConfig>();

builder.Configuration.GetSection("AppName").Get<HelloWorldConfig>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    options =>
    {
        options.LoginPath = new PathString("/Login"); //���ҤJ�f
        options.AccessDeniedPath = new PathString("/403.html"); //���ҥ��ѾɦV
    });



builder.Services.AddMvc().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

var app = builder.Build();

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Join(app.Environment.ContentRootPath, "UploadFile")),
    RequestPath = "/UploadFile"
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HelloWorld}/{action=CodeMonkey}/{id?}");

app.Run();
