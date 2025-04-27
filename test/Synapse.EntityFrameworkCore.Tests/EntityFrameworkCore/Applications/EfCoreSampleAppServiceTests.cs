using Synapse.Samples;
using Xunit;

namespace Synapse.EntityFrameworkCore.Applications;

[Collection(SynapseTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<SynapseEntityFrameworkCoreTestModule>
{

}
