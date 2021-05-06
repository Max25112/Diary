using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Diary.Web.Data
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Post { get; set; }
        public string Subject { get; set; }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Grade { get; set; }
    }
    

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
    }
    public class ApplicationUser : IdentityUser
    {
        [Required()]
        public string FirstName { get; set; }
        [Required()]
        public string LastName { get; set; }
        [Required()]
        public string MiddleName { get; set; }

    }
}
