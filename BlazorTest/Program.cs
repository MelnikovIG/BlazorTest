﻿using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using ColorGame.Component;
using ColorGameComponent;

namespace BlazorTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(services =>
            {
                // ColorGame services
                services.RegisterColorGameServices();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
