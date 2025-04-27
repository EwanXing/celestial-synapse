using System.Threading.Tasks;

namespace Synapse.Data;

public interface ISynapseDbSchemaMigrator
{
    Task MigrateAsync();
}
