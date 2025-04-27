using Microsoft.Extensions.Localization;
using Synapse.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Synapse;

[Dependency(ReplaceServices = true)]
public class SynapseBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<SynapseResource> _localizer;

    public SynapseBrandingProvider(IStringLocalizer<SynapseResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
