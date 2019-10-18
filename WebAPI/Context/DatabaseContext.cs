using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebAPI.Models;

namespace WebAPI.Context
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings["ConnectionString"]);
        }

        public DbSet<AccountModel> Account { get; set; }

        public DbSet<NosmallItemModel> NosmalllItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountModel>(entity =>
            {
                entity.HasKey(e => e.AccountId);
            });

            modelBuilder.Entity<NosmallItemModel>(entity =>
            {
                entity.HasKey(e => e.ProductId);
            });
        }
    }
}