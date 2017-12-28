using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Text;
using DAL.Model;

namespace EF360CodeOnly.Concurrency
{
    public class ConcurrencyHelperClass
    {
        public ConcurrencyResolutionType ConcurrencyResolutionTypeValue { get; set; }
        public DbContext Context;

        public void SaveChangesWithConcurrency(EF360Context ctx)
        {
            try
            {
                ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ResolveConcurrencyConflicts(ex);
                SaveChangesWithConcurrency(ctx);
            }
        }

        public void ResolveConcurrencyConflicts(DbUpdateConcurrencyException ex)
        {
            var concurrencyResolutionStrategy =
                ConcurrencyResolutionStrategy.SelectResolution(ConcurrencyResolutionTypeValue);

            foreach (var entry in ex.Entries)
            {
                concurrencyResolutionStrategy.Resolve(entry);
            }
        }
    }
}