﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Synapse.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Synapse;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
             /*   .WriteTo.Async(c => c.File("Logs/logs.txt"))
                .WriteTo.Async(c => c.Console()) */
             .WriteTo.Async(c => c.OpenTelemetry())
            .CreateBootstrapLogger();

        try
        {
            Log.Information("Starting Synapse.HttpApi.Host.");
            var builder = WebApplication.CreateBuilder(args);

            builder.AddServiceDefaults();
            builder.AddRedisClient("redis");
            builder.AddNpgsqlDbContext<SynapseDbContext>("Default",
                options =>
                {
                    options.DisableRetry = true;
                });

            builder.Host
                .AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog((context, services, loggerConfiguration) =>
                {
                    loggerConfiguration
#if DEBUG
                        .MinimumLevel.Debug()
#else
                        .MinimumLevel.Information()
#endif
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                        .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                        .Enrich.FromLogContext()
                        .WriteTo.Async(c => c.File("Logs/logs.txt"))
                        .WriteTo.Async(c => c.Console())
                        .WriteTo.Async(c => c.AbpStudio(services));
                });
            await builder.AddApplicationAsync<SynapseHttpApiHostModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException)
            {
                throw;
            }

            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
