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
            //DbContextOptionsBuilder
            modelBuilder.Entity<Customer>().HasIndex(x => x.PhoneNumber);
            modelBuilder.Entity<Customer>().HasIndex(x => x.LGAId);

            modelBuilder.Entity<OTP>().HasIndex(x => x.HashOTPCode);

            modelBuilder.Entity<Customer>()
            .HasMany(x => x.OTPs)
            .WithOne(x => x.Customer)
            .HasForeignKey(x => x.CustomerId);

            modelBuilder.Entity<Customer>()
            .HasOne(x => x.LGA)
            .WithMany();

            modelBuilder.Entity<State>()
                .HasMany(x => x.LGAs)
                .WithOne(x => x.State)
                .HasForeignKey(x => x.StateId);

            SeeData(modelBuilder);
        }

        private void SeeData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>().HasData(
                new State
                {
                    CreatedBy = Core.Constants.SYSTEM_NAME,
                    Name = "Abia State",
                    Id = 1
                },
                new State
                {
                    CreatedBy = Core.Constants.SYSTEM_NAME,
                    Name = "Lagos State",
                    Id = 2
                },
                new State
                {
                    CreatedBy = Core.Constants.SYSTEM_NAME,
                    Name = "Kaduna State",
                    Id = 3
                },
                new State
                {
                    CreatedBy = Core.Constants.SYSTEM_NAME,
                    Name = "Sokoto State",
                    Id = 4,
                },
                new State
                {
                    CreatedBy = Core.Constants.SYSTEM_NAME,
                    Name = "Ogun State",
                    Id = 5
                },
                new State
                {
                    CreatedBy = Core.Constants.SYSTEM_NAME,
                    Name = "Taraba State",
                    Id = 6
                },
                new State
                {
                    CreatedBy = Core.Constants.SYSTEM_NAME,
                    Name = "Imo State",
                    Id = 7
                },
                new State
                {
                    CreatedBy = Core.Constants.SYSTEM_NAME,
                    Name = "Edo State",
                    Id = 8
                });
            SeedLGAs(modelBuilder);
        }

        private void SeedLGAs(ModelBuilder modelBuilder)
        {
            var lgas = new List<LGA>();
            long n = 1;

            for (int i = 1; i <= 8; i++)
            {
                for(int j = 1; j <= 15; j++)
                {
                    var lga = new LGA { Id = n, StateId = i, CreatedBy = Core.Constants.SYSTEM_NAME, Name = $"LGA {i} + {j}" };
                    lgas.Add(lga);
                    n++;
                }
            }

            modelBuilder.Entity<LGA>().HasData(lgas);
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
                    //string identityName = Thread.CurrentPrincipal.Identity.Name;
                    string identityName = Core.Constants.SYSTEM_NAME;
                    DateTimeOffset now = DateTimeOffset.Now;

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                }
            }
        }
    }
}
