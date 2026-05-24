using System.Threading.Tasks;

namespace task.ecommerce.Data;

public interface IecommerceDbSchemaMigrator
{
    Task MigrateAsync();
}
