using DataLayer.Entityes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class _ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<NameTrade> NameTrades { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Preparation> Preparations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public _ApplicationContext(DbContextOptions<_ApplicationContext>options) : 
            
            base(options) 
        {
            Database.EnsureCreated();
        }
    }
}
