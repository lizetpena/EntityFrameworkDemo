using System.Data.Entity.Infrastructure;

namespace EF360CodeOnly.Concurrency
{
    public class MergeResultStrategy : IConcurrencyResolution
    {
        public void Resolve(DbEntityEntry entry)
        {
            // Fetch current database values
            var databaseValues = entry.GetDatabaseValues();
            // Fetch your values
            var currentValues = entry.CurrentValues;
            // Fetch the original values that you queried            
            var originalValues = entry.OriginalValues;
            // Clone orignal values as a dataSet upon which
            // to build the merged result set
            var result = originalValues.Clone();

            // Resolution algorithm saves any changes you made, and also saves
            // any changes that another user has made during the time you
            // fetched record. In the end, you change wins, but any 'other' 
            // changes made by another user are also preserved.
            foreach (var propertyName in originalValues.PropertyNames)
            {
                // Compare current value to original value to determine is user has changed.
                if (!object.Equals(currentValues[propertyName], originalValues[propertyName]))
                    // if current user has changed value, then copy new value to merged result.
                    result[propertyName] = currentValues[propertyName];
                // Compare database value to orignal value to determine to determine if
                // value was changed after current user retrieved original record.
                else if (!object.Equals(databaseValues[propertyName], originalValues[propertyName]))
                    // if current user has changed value in between, then keep current user's change
                    result[propertyName] = databaseValues[propertyName];
            }

            // Set original values to those of the current database values
            // Doing so sets concurrency token value in your update to that from 
            // database, allowing SaveChanges() to succeed.
            entry.OriginalValues.SetValues(databaseValues);
            // Set current values to the newly merged values
            entry.CurrentValues.SetValues(result);
        }
    }
}