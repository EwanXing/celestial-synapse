using Synapse.Samples;
using Xunit;

namespace Synapse.EntityFrameworkCore.Domains;

[Collection(SynapseTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<SynapseEntityFrameworkCoreTestModule>
{

}
