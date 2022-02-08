using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using rolesDemoSSD.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace rolesDemoSSD.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define composite primary keys.
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserID, ur.RoleID });

            modelBuilder.Entity<UserRole>()
                .HasOne(u => u.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(fk => new { fk.UserID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<UserRole>()
                .HasOne(r => r.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(fk => new { fk.RoleID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
        }

        public class User
        {
            [Key]
            public int UserID { get; set; }
            public string UserName { get; set; }

            // Navigation properties.
            // Child.
            public virtual ICollection<UserRole>
                UserRoles
            { get; set; }

        }

        public class Role
        { 
            [Key]
            public int RoleID { get; set; }
            public string RoleName { get; set; }

            // Navigation properties.
            // Child.
            public virtual ICollection<UserRole>
                UserRoles
            { get; set; }
        }

        public class UserRole
        {
            [Key, Column(Order = 0)]
            public int UserID { get; set; }
            [Key, Column(Order = 1)]
            public int RoleID { get; set; }
            public int Qty { get; set; }

            // Navigation properties.
            // Parents.
            public virtual User User { get; set; }
            public virtual Role Role { get; set; }
        }
    }

}
