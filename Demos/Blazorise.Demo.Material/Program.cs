﻿#region Using directives
using System.Net.Http;
using System.Threading.Tasks;
using Blazorise.Demo.Data;
using Blazorise.Icons.Material;
using Blazorise.Material;
using Blazorise.RichTextEdit;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
#endregion

namespace Blazorise.Demo.Material
{
    public class Program
    {
        public static async Task Main( string[] args )
        {
            var builder = WebAssemblyHostBuilder.CreateDefault( args );

            builder.Services
                .AddBlazorise( options =>
                {
                    options.ChangeTextOnKeyPress = true;
                } )
                .AddBlazoriseRichTextEdit( options =>
                {
                    options.UseBubbleTheme = true;
                    options.UseShowTheme = true;
                } )
                .AddMaterialProviders()
                .AddMaterialIcons();

            builder.Services.AddMemoryCache();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<EmployeeData>();

            builder.RootComponents.Add<App>( "#app" );

            var host = builder.Build();

            await host.RunAsync();
        }
    }
}