using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WPF_task1.Models
{
    class WifiDbContext : DbContext
    {
        public DbSet<Network> Networks { get; set; } = null!;

        public WifiDbContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Networks.db");
        }
    }
}
