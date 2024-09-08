using Euraylus.Server;
using Euraylus.Server.Core;
using Euraylus.Storage.Core;
using Euraylus.Users.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHostBuilder host_builder = Host.CreateDefaultBuilder();

host_builder.ConfigureServices( services => {
    services.AddSingleton<IApplication, Application>();

    services.AddServerServices();
    services.AddStorageServices();
    services.AddUserServices();
} );

IHost host = host_builder.Build();
host.Services.GetRequiredService<IApplication>().Run();