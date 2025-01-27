using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddAuthorizationCore();
builder.Services.AddAuthenticationStateDeserialization();

await builder.Build().RunAsync();
