using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using PCT.Adapter.AzureFunction.Repository;

[assembly: FunctionsStartup(typeof(PCT.Adapter.AzureFunction.StartUp))]

namespace PCT.Adapter.AzureFunction
{
    public class StartUp : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string connectionString = Environment.GetEnvironmentVariable("PostgresConnection");
            builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));
            builder.Services.AddScoped(typeof(Repository<>));
            builder.Services.AddScoped(typeof(ProductRepository));
        }
    }
}
