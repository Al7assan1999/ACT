using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ACT.Data
{
    /* This is used if database provider does't define
     * IACTDbSchemaMigrator implementation.
     */
    public class NullACTDbSchemaMigrator : IACTDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}