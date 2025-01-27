using Microsoft.AspNetCore.Authentication.Negotiate;
using WindowsAuthenticationExample.Components;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorComponents()
                 .AddInteractiveServerComponents()
                 .AddInteractiveWebAssemblyComponents()
                 .AddAuthenticationStateSerialization(options => options.SerializeAllClaims = true);


builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
                       .AddNegotiate();

builder.Services.AddAuthenticationStateDeserialization();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(WindowsAuthenticationExample.Client._Imports).Assembly);

app.Run();
