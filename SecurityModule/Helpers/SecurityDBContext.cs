
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SecurityModule.Entities;
using SecurityModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityModule.Helpers
{
    public class SecurityDBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public SecurityDBContext()
        {

        }
        public SecurityDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SecurityDBContext(DbContextOptions<SecurityDBContext> options)
            : base(options){ }
        public virtual DbSet<Screen> Screens { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleWiseScreenPermission> RoleWiseScreenPermission { get; set; }
        //public virtual DbSet<Screen> Screen { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<UserRegistration> UserRegistration { get; set; }

        public virtual DbSet<EmployeeLogin> EmployeeLogin { get; set; }
        public virtual DbSet<EmployeeRegistration> EmployeeRegistration { get; set; }

        //public virtual DbSet<UserWiseProjectPermission> UserWiseProjectPermission { get; set; }
        public virtual DbSet<UserWiseProjectRolePermission> UserWiseProjectRolePermission { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleWiseScreenPermission>().HasNoKey();
            modelBuilder.Entity<UserWiseProjectPermission>().HasNoKey();
            //modelBuilder.Entity<UserWiseProjectRolePermission>().HasNoKey();

            //modelBuilder
            //.Entity<UserWiseProjectRolePermission>(eb =>
            //{
            //    eb.HasNoKey();
            //});
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
