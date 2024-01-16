using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Data.Entities;
using TimeSheet.Domain;
using TimeSheet.Domain.Model;

namespace TimeSheet.Data
{
    public class TimeSheetDbContext : DbContext
    {
        public TimeSheetDbContext(DbContextOptions<TimeSheetDbContext> options) : base(options)
        {

        }

        public DbSet<CategoryEntity> Categories {get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>()
                .HasQueryFilter(GetGeneralCategoryFilter())
                .Property(e => e.Id)
                .UseIdentityByDefaultColumn()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ClientEntity>()
                .HasQueryFilter(GetGeneralClientFilter())
                .Property(e => e.Id)
                .UseIdentityByDefaultColumn()
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserEntity>()
                .HasQueryFilter(GetGeneralUserFilter())
                .Property(e => e.Id)
                .UseIdentityByDefaultColumn()
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }

        private Expression<Func<CategoryEntity, bool>> GetGeneralCategoryFilter()
        {
            return category => !category.IsDeleted;
        }

        private Expression<Func<ClientEntity, bool>> GetGeneralClientFilter()
        {
            return client => !client.IsDeleted;
        }

        private Expression<Func<UserEntity, bool>> GetGeneralUserFilter()
        {
            return user => !user.IsDeleted;
        }



    }
}