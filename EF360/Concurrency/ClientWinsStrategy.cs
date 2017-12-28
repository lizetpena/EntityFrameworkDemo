using System.Data.Entity.Infrastructure;

namespace EF360CodeOnly.Concurrency
{
    public class ClientWinsStrategy : IConcurrencyResolution
    {
        public void Resolve(DbEntityEntry entry)
        {
            // Override database made by someone else with your values.
            // Setting 'Orginal Values' to 'Database Values' retrives current 
            // rowversion value from database. Doing so sets concurrency  
            // token value in your update to that from database, allowing 
            // SaveChanges() to succeed. Doing so also sets any properties as 
            // 'Modified' that have a different value from database.
            entry.OriginalValues.SetValues(entry.GetDatabaseValues());
        }
    }
}