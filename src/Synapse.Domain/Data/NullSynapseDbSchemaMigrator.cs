using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Synapse.Data;

/* This is used if database provider does't define
 * ISynapseDbSchemaMigrator implementation.
 */
public class NullSynapseDbSchemaMigrator : ISynapseDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
