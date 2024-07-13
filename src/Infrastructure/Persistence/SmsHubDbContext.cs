using Microsoft.EntityFrameworkCore;
using SmsHub.Core.Domain.Comman;
using SmsHub.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Infrastructure.Persistence
{
    public class SmsHubDbContext(DbContextOptions<SmsHubDbContext> options) : DbContext(options)
    {
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SmsHubDbContext).Assembly);

            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                Name = "John Egbert Live",              
                Date = DateTime.Now.AddMonths(6)                
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
          
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
