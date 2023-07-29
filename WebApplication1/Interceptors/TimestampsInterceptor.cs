using DoranOfficeBackend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DoranOfficeBackend.Interceptors
{
    public class TimestampInterceptor : SaveChangesInterceptor
    {
        public InterceptionResult<int> updateTimestamp(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.Context is null) return result;

            var entries = eventData.Context.ChangeTracker.Entries().Where(e => {
                Console.WriteLine("123123 " + (e.Entity is ITimestamps).ToString());
                return e.Entity is ITimestamps && (e.State == EntityState.Added || e.State == EntityState.Modified);
            });
            var currentTime = DateTime.Now;

            foreach (var entityEntry in entries)
            {

                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.CurrentValues["CreatedAt"] = currentTime;
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    if (entityEntry.CurrentValues["CreatedAt"] == null)
                    {
                        entityEntry.CurrentValues["CreatedAt"] = currentTime;
                    }
                    entityEntry.CurrentValues["UpdatedAt"] = currentTime;
                }
            }

            return result;
        }
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default(CancellationToken))
        {
            return new ValueTask<InterceptionResult<int>>(updateTimestamp(eventData, result));
        }
        public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
        {
            return updateTimestamp(eventData, result);
        }
    }
}
