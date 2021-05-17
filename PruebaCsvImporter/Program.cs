using BackEnd.CsvImporter.Repository.Database;
using BackEnd.PruebaCsvImporter.Business;
using BackEnd.PruebaCsvImporter.Entities.Interfaces.Business;
using BackEnd.PruebaCsvImporter.Entities.Interfaces.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace PruebaCsvImporter
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Registry builder
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            //Logger Registry
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Hello ACNE CORPORATION The Application Starting");
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    //Business
                    services.AddTransient<ILoadInfoExcelBusiness, LoadInfoExcelBusiness>();
                    //Repository
                    services.AddTransient<ILoadInfoExcelRepository, LoadInfoExcelRepository>();
                })
                .UseSerilog()
                .Build();

            //Create Instance Business
            var svc = ActivatorUtilities.CreateInstance<LoadInfoExcelBusiness>(host.Services);
            _ = svc.LoadDataExcel().Result;
            Log.Logger.Information("Bye Bye The Application Ending");
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }
    }
}
