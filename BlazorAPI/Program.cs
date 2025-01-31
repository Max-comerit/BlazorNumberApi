using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorAPI;
using BlazorAPI.Service;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Gammal registrering av global tjänst för API-key

// string apiKey = builder.Configuration["NumberApiKey"];
// builder.Services.AddSingleton(new ApiKeyHandler(apiKey));


//Skapar en global tjänst (instans av klass NumberService) som tar emot en instans av HTTP, och IConfiguration

builder.Services.AddSingleton(sp => 
{
  var http = new HttpClient();
  var configuration = sp.GetRequiredService<IConfiguration>();
  return new NumberService(http, configuration);
} );


await builder.Build().RunAsync();
