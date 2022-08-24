using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Services;
using HR.LeaveManagement.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Custom services
services.AddHttpContextAccessor();
services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

services.AddTransient<IAuthService, AuthService>();

services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("https://localhost:7111"));

services.AddScoped<ILeaveTypeService, LeaveTypeService>();
services.AddScoped<ILeaveRequestService, LeaveRequestService>();
services.AddScoped<ILeaveAllocationService, LeaveAllocationService>();

services.AddSingleton<ILocalStorageService, LocalStorageService>();

// Add services to the container.
services.AddControllersWithViews();
services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCookiePolicy();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
