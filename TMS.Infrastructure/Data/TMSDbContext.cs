using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Entities;
using TMS.Core.Requests;

namespace TMS.Infrastructure.Data
{
    public class TMSDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public TMSDbContext(DbContextOptions<TMSDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TMSDbContext).Assembly);           
        }



        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<BusinessUnitCategory> BusinessUnitCategories { get; set; }
        public DbSet<BusinessUnitMember> BusinessUnitMembers { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
