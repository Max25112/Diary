using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Diary.Web.Models;
namespace Diary.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        //public DbSet<Schedule> Schedules { get; set; }
        //public DbSet<Homework> Homeworks { get; set; }
        //public DbSet<Answer> Answers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
    }

    /*protected internal virtual void OnModelCreating
    {
        modelBuilder
            .Entity<ApplicationUser>()
            .HasOne(u => u.Teacher)
            .WithOne(p => p.User)
            .HasForeignKey<Teacher>(p => p.UserKey);
    }*/
    /*public class Schedule
    {
        [Required()]
        public int Id { get; set; }
        [Required()]
        public int TeacherId { get; set; }
        [Required()]
        public int Grade { get; set; }
        public int Day { get; set; }
        public int Order { get; set; }
    }
    */
    //public class Homework
    //{
    //    public int Id { get; set; }
    //    [Required()]
    //    public int TeacherId { get; set; }
    //    [Required()]
    //    public int Grade { get; set; }
    //    public string Title { get; set; }
    //    public string TaskText { get; set; }
    //    // public File {get;set;}
    //}
    //public class Answer
    //{

    //    public int Id { get; set; }
    //    [Required()]
    //    public int TeacherId { get; set; }
    //    [Required()]
    //    public int Grade { get; set; }
    //    public string Title { get; set; }
    //    // public File {get;set;}
    //}
}
