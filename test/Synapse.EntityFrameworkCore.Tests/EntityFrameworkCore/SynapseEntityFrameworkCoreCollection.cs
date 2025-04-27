using Xunit;

namespace Synapse.EntityFrameworkCore;

[CollectionDefinition(SynapseTestConsts.CollectionDefinitionName)]
public class SynapseEntityFrameworkCoreCollection : ICollectionFixture<SynapseEntityFrameworkCoreFixture>
{

}
