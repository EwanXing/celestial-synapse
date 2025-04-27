using Volo.Abp.Modularity;

namespace Synapse;

[DependsOn(
    typeof(SynapseDomainModule),
    typeof(SynapseTestBaseModule)
)]
public class SynapseDomainTestModule : AbpModule
{

}
