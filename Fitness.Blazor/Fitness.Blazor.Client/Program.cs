using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Fitness.Blazor.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register the root component (App component)
//builder.RootComponents.Add<App>("#app");

// Register HttpClient with the base address of the Blazor WebAssembly app
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Register WorkoutService
builder.Services.AddScoped<IWorkoutService, WorkService>();

await builder.Build().RunAsync();
