using Synapse.Localization;
using Volo.Abp.Application.Services;

namespace Synapse;

/* Inherit your application services from this class.
 */
public abstract class SynapseAppService : ApplicationService
{
    protected SynapseAppService()
    {
        LocalizationResource = typeof(SynapseResource);
    }
}
