using Microsoft.EntityFrameworkCore;
using PundoPH.Model;
using System.Collections.Generic;

namespace PundoPH.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } // Example entity
        public DbSet<Contribution> Contributions { get; set; }
        public DbSet<WithdrawModel> Withdraws { get; set; }
    }
}
