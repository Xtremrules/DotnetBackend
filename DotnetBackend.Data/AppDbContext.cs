using DotnetBackend.Core.Entities;
using DotnetBackend.Core.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DotnetBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.SetCommandTimeout(TimeSpan.FromMinutes(10));
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<LGA> LGAs { get; set; }
        public DbSet<OTP> OTPs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasIndex(x => x.PhoneNumber);
            modelBuilder.Entity<Customer>().HasIndex(x => x.StateId);

            modelBuilder.Entity<OTP>().HasIndex(x => x.Code);

            modelBuilder.Entity<Customer>()
            .HasMany(x => x.OTPs)
            .WithOne(x => x.Customer)
            .HasForeignKey(x => x.CustomerId);

            modelBuilder.Entity<Customer>()
            .HasOne(x => x.State)
            .WithMany(x => x.Customers)
            .HasForeignKey(x => x.StateId);

            modelBuilder.Entity<State>()
                .HasMany(x => x.LGAs)
                .WithOne(x => x.State)
                .HasForeignKey(x => x.StateId);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ImplementAuditableEntity();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ImplementAuditableEntity()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                && x.State == EntityState.Modified);
            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTimeOffset now = DateTimeOffset.Now;

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                }
            }
        }
    }
}
