using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// 直接使用连接字符串（不通过 Aspire 管理）
var postgresConnection = builder.Configuration.GetConnectionString("postgres");
var redisConnection = builder.Configuration.GetConnectionString("redis");

// DbMigrator
if (builder.Environment.IsDevelopment())
{
    builder
        .AddProject<Projects.Synapse_DbMigrator>("Synapse-DbMigrator")
        .WithEnvironment("ConnectionStrings__Default", postgresConnection)
        .WithEnvironment("ConnectionStrings__Redis", redisConnection)
        .WithReplicas(1);
}

var httpApiHostLaunchProfile = "Synapse.HttpApi.Host";
/*var httpApiHostLaunchProfile = builder.Environment.IsDevelopment()
    ? "Synapse.HttpApi.Host"
    : null;*/
builder
    .AddProject<Projects.Synapse_HttpApi_Host>("httpapihost", launchProfileName: httpApiHostLaunchProfile)
    .WithExternalHttpEndpoints()
    .WithEnvironment("ConnectionStrings__Default", postgresConnection)
    .WithEnvironment("ConnectionStrings__Redis", redisConnection);

builder.Build().Run();