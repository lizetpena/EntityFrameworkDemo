using System.Data.Entity.Infrastructure;

namespace EF360CodeOnly.Concurrency
{
    public class ServerWinsStrategy : IConcurrencyResolution
    {
        public void Resolve(DbEntityEntry entry)
        {
            // Apply Reload() which requeries database for  
            // current database values thus overriding your
            // changes.
            entry.Reload();
        }
    }
}