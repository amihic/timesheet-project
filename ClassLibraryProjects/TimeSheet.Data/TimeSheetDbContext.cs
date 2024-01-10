using System;
using System.Collections.Generic;
using System.Linq;
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

        public DbSet<Category> Categories {get; set; }

    }
}