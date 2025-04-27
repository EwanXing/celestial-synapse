using Volo.Abp.Modularity;

namespace Synapse;

public abstract class SynapseApplicationTestBase<TStartupModule> : SynapseTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
