using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WPF_task1.Models
{
    class NetworksDbContext : DbContext
    {
        public DbSet<Network> Networks { get; set; }

        public NetworksDbContext(DbContextOptions<NetworksDbContext> options) : base(options) { }
    }
}
