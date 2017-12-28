using System.Data.Entity.Infrastructure;

namespace EF360CodeOnly.Concurrency
{
    public interface IConcurrencyResolution
    {
        void Resolve(DbEntityEntry entry);
    }
}