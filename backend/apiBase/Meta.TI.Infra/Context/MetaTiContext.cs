using System.Linq;
using Meta.TI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meta.TI.Infra.Context
{
    public class MetaTiContext : DbContext
    {
        public MetaTiContext(DbContextOptions<MetaTiContext> options)
            : base(options)
        {
            this.Seed();
        }
        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hospital>().ToTable("Hospital");
            modelBuilder.Entity<Hospital>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Hospital>().Property(x => x.Name).HasMaxLength(120).HasColumnType("varchar(120)");

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<User>().Property(x => x.Name).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<User>().Property(x => x.Password).HasMaxLength(120).HasColumnType("varchar(120)");

        }
        public void Seed()
        {
            if (!this.Hospital.Where(x => x.Id == 1).Any())
            {
                this.Hospital.Add(new Hospital
                {
                    Id = 1,
                    Name = "Hospital 1"
                });
            }
            if (!this.Hospital.Where(x => x.Id == 2).Any())
            {
                this.Hospital.Add(new Hospital
                {
                    Id = 2,
                    Name = "Hospital 2"
                });
            }

            if (!this.User.Where(x => x.Id == 1).Any())
            {
                this.User.Add(new User
                {
                    Name = "Igor Walace Cuevas",
                    Email = "igor@email.com",
                    Password = "123456"
                });
            }
            this.SaveChanges();
        }
    }
}