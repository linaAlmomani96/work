using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Task1MVC.Data
{
    public class HRContext:IdentityDbContext<ApplictionUser>
    {
        IConfiguration configuration;
        public HRContext(IConfiguration _configuration)
        {
            configuration = _configuration;

        }
        public DbSet<Employee> employee { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<Country> country { get; set; }
        public DbSet<City> city { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("HrConnection"));
            base.OnConfiguring(optionsBuilder);

        }

        //coposite key
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Employee>().HasKey(e => new
        //    {
        //        e.city,
        //        e.photo
        //    });
        //    base.OnModelCreating(builder);
        //}
    }
}
