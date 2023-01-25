using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models;

namespace MinimalAPI.Data
{
    public class MinimalContextDb : DbContext
    {
        public MinimalContextDb(DbContextOptions<MinimalContextDb> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);

            modelBuilder.Entity<User>().Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<User>().Property(e => e.Username)
                .IsRequired()
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<User>().Property(e => e.Password)
                .IsRequired()
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<User>().Property(e => e.BirthDate)
                .IsRequired()
                .HasColumnType("DATE");

            modelBuilder.Entity<User>().Property(e => e.City)
                .IsRequired()
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<User>().Property(e => e.Phone)
               .IsRequired()
               .HasColumnType("varchar(15)");

            base.OnModelCreating(modelBuilder);

        }
    }
}
