using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Fitness.Blazor.Client;
using Fitness.Blazor.Client.Services;
using Fitness.Blazor.Client.Pages;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7289/") });

// Register WorkoutService
builder.Services.AddScoped<IWorkoutService, WorkService>();
builder.Services.AddScoped<ILoginService, LoginService>();


await builder.Build().RunAsync();
