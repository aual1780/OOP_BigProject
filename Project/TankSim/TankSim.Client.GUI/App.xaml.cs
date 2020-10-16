﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using TankSim.Client.GUI.Controls;
using TankSim.Client.GUI.ViewModels;
using TankSim.Client.OperatorModules;
using TankSim.Config;

namespace TankSim.Client.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private IServiceProvider ServiceProvider { get; set; }
        private IConfiguration Configuration { get; set; }
        private IConfigurationSection ArdNetConfiguration { get; set; }

        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            var configBuilder =
                new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("config.json", optional: false, reloadOnChange: true);
            var config = configBuilder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, config);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            using (var scope = ServiceProvider.CreateScope())
            {
                var mainWindow = scope.ServiceProvider.GetRequiredService<MainWindow>();
                _ = mainWindow.ShowDialog();
            }
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            //setup keybinding configs
            _ = services
                .AddKeyBindings(config.GetSection(nameof(KeyBindingConfig)));
            //setup game services
            _ = services
                .AddGameIDService()
                .AddScoped<IOperatorModuleFactory, OperatorModuleFactory>();
            //setup ArdNet
            _ = services
                .AddMessageHubSingleton()
                .AddIpResolver()
                .AddArdNet(config.GetSection("ArdNet"))
                .AddClientScoped()
                .AddTankSimConfig()
                .AutoRestart();
            //setup main window
            _ = services
                .AddTransient<MainWindow>()
                .AddTransient<MainWindowVM>()
                .AddTransient<GameScopeControl>()
                .AddTransient<GameScopeControlVM>()
                .AddTransient<ClientNameControl>()
                .AddTransient<ClientNameControlVM>()
                .AddTransient<OperatorModuleControl>()
                .AddTransient<OperatorModuleControlVM>()
            ;

        }
    }
}
