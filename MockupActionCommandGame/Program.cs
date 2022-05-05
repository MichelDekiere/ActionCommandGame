using ActionCommandGame.Sdk;
using ActionCommandGame.Sdk.Abstractions;
using ActionCommandGame.Sdk.Extensions;
using ActionCommandGame.Ui.WebApp.Settings;
using ActionCommandGame.Ui.WebApp.Stores;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

var appSettings = new AppSettings();

//--------------------------------------------------------------------------------

builder.Configuration.GetSection(nameof(appSettings)).Bind(appSettings);

builder.Services.AddHttpClient("ActionCommandGame", httpClient =>
{
    httpClient.BaseAddress = new Uri(appSettings.ApiBaseUrl);
});

builder.Services.AddTransient<IdentityApi>();
builder.Services.AddScoped<ITokenStore, TokenStore>();

//--------------------------------------------------------------------------------
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config => {
        config.LoginPath = appSettings.SignInUrl;
        config.AccessDeniedPath = appSettings.SignInUrl;
        
        config.Cookie.HttpOnly = true;
        config.ExpireTimeSpan = TimeSpan.FromMinutes(5);
        config.AccessDeniedPath = "/Home/LoginPage";
        config.SlidingExpiration = true;
    });

//--------------------------------------------------------------------------------


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
