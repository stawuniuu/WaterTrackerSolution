 using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WaterTracker.Web;
using WaterTracker.Web.Services;
using WaterTracker.Web.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7283/") });

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWaterIntakeService, WaterIntakeService>();

await builder.Build().RunAsync();
