using Volo.Abp.Modularity;

namespace Synapse;

/* Inherit from this class for your domain layer tests. */
public abstract class SynapseDomainTestBase<TStartupModule> : SynapseTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
