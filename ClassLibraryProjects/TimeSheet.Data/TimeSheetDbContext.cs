using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Domain;


namespace TimeSheet.Data
{
    public class TimeSheetDbContext : DbContext
    {
        public TimeSheetDbContext(DbContextOptions<TimeSheetDbContext> options) : base(options)
        {

        }

        public DbSet<CategoryEntity> Categories {get; set; }

    }
}