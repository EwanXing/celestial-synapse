using Volo.Abp.Modularity;

namespace Synapse;

[DependsOn(
    typeof(SynapseApplicationModule),
    typeof(SynapseDomainTestModule)
)]
public class SynapseApplicationTestModule : AbpModule
{

}
