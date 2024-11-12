using BookManagement.Entity;
using BookManagement.Repositorys.Deployment;
using BookManagement.Repositorys.Interfaces;
using BookManagement.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace BookManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider serviceProvider;

        public App()
        {
            // Set up DI container
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            // Build the service provider
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<MainWindowViewModel>();
            //services.AddTransient<WAREHOUSEBOOKEntities>();
            services.AddSingleton<IBookGenreRepository, BookGenreRepository>(); // Example registration
            // Register your services and dependencies here
            // services.AddSingleton<ITestingService, TestingService>(); // Example registration
        }
    }
}