using Synapse.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Synapse.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SynapseController : AbpControllerBase
{
    protected SynapseController()
    {
        LocalizationResource = typeof(SynapseResource);
    }
}
