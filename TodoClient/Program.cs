using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TodoClient.Services;
using System;
using System.Net.Http;

namespace TodoClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Configura el cliente HTTP para conectarse a la API
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5193/") });
            builder.Services.AddScoped<ApiService>();

            await builder.Build().RunAsync();
        }
    }
}
