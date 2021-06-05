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
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<HomeResult> HomeResults { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Class> Classes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {            
            base.OnModelCreating(builder);
        }
    }


    public class Lesson
    {
        [Required()]
        public int Id { get; set; }
        [Required()]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        [Required()]
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        [Required()]
        public string Cabinet { get; set; }
        [Required()]
        public int Day { get; set; }
        [Required()]
        public int Order { get; set; }
    }

    public class Homework
    {
        public int Id { get; set; }
        [Required()]
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int ClassId { get; set; }
        [Required()]
        public Class Class { get; set; }//Класс
        public string Title { get; set; }
        public string TaskText { get; set; }
        public DateTime Deadline { get; set; }
        public List<Attachment> Attachments { get; set; } = new List<Attachment>();
        // public File {get;set;}
    }

    public class Attachment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Data { get; set; }
    }
    
    public class HomeResult
    {
        public int Id { get; set; }
        [Required()]
        public int TeacherId { get; set; }
        [Required()]
        public int StudentId { get; set; }
        public string Title { get; set; }
        public List<Attachment> Attachments { get; set; } = new List<Attachment>();
        // public File {get;set;}
    }
    /*public class TableLessons
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string ClassName { get; set; }
        public string SubjectName { get; set; }
        public string Cabinet { get; set; }
        public int Order { get; set; }
    }*/
}
