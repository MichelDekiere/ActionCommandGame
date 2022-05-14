using ActionCommandGame.Repository;
using ActionCommandGame.Sdk;
using ActionCommandGame.Sdk.Abstractions;
using ActionCommandGame.Sdk.Extensions;
using ActionCommandGame.Services.Model.Results;
using ActionCommandGame.Ui.WebApp.Settings;
using ActionCommandGame.Ui.WebApp.Stores;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

var appSettings = new AppSettings();

builder.Configuration.GetSection(nameof(appSettings)).Bind(appSettings);

builder.Services.AddApi(appSettings.ApiBaseUrl);
builder.Services.AddScoped<ITokenStore, TokenStore>();

//-------------------------------------------------------------
builder.Services.AddTransient<PlayerResult>(); // zodat playerResult bijgehouden wordt in de shop, zodat playerId niet meegegeven moet worden
                                               // in model voor Buy()
//-------------------------------------------------------------

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
    {
        config.LoginPath = appSettings.SignInUrl;
        config.AccessDeniedPath = appSettings.SignInUrl;
        config.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    });


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();    // wie ben je?
app.UseAuthorization();     // ben je toegelaten?

app.UseCookiePolicy();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=LoginPage}/{id?}");

app.Run();
