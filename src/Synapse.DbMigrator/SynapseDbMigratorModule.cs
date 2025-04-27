using Microsoft.Extensions.DependencyInjection;
using Synapse.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Synapse.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SynapseEntityFrameworkCoreModule),
    typeof(SynapseApplicationContractsModule)
)]
public class SynapseDbMigratorModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        configuration["Redis:Configuration"] = configuration["ConnectionStrings:Redis"];
    }
}
