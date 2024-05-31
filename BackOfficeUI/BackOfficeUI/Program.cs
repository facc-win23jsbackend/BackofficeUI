using BackOfficeUI;
using BackOfficeUI.Client.Pages;
using BackOfficeUI.Components;
using BackOfficeUI.Extensions;
using Blazored.Toast;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Net.Http.Headers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCoursesClient().ConfigureHttpClient(async (serviceProvider, c) => {
    var contextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
    var token = await contextAccessor.HttpContext!.GetTokenAsync("access_token");
    c.BaseAddress = new Uri(builder.Configuration["CoursesGraphQL"]!);
    c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
});

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, oidcOptions =>
    {
        oidcOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        oidcOptions.Authority = builder.Configuration["Keycloak:authority"];

        oidcOptions.ClientId = builder.Configuration["Keycloak:credentials:clientId"];
        oidcOptions.ClientSecret = builder.Configuration["Keycloak:credentials:secret"];
        oidcOptions.ResponseType = OpenIdConnectResponseType.Code;

        oidcOptions.MapInboundClaims = false;
        oidcOptions.TokenValidationParameters.NameClaimType = JwtRegisteredClaimNames.Name;
        oidcOptions.TokenValidationParameters.RoleClaimType = "role";
        oidcOptions.SaveTokens = true;
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

builder.Services.ConfigureCookieOidcRefresh(CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme);

builder.Services.AddAuthorization(); 

builder.Services.AddScoped<AuthenticationStateProvider, PersistingAuthenticationStateProvider>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddBlazoredToast();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.MapGroup("/authentication").MapLoginAndLogout();
app.Run();