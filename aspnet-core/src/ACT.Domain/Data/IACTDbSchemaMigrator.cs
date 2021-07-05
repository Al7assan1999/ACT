using System.Threading.Tasks;

namespace ACT.Data
{
    public interface IACTDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
