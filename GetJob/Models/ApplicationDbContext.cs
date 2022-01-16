using GetJob.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetJob.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userStudentRoleName = "userStudent";
            string userTeacherRoleName = "userTeacher";
            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userStudentRole = new Role { Id = 2, Name = userStudentRoleName };
            Role userTeacherRole = new Role { Id = 3, Name = userTeacherRoleName };
            Users adminUser = new Users { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userStudentRole,userTeacherRole });
            modelBuilder.Entity<Users>().HasData(new Users[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
