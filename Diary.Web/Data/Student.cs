using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diary.Web.Data
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public int UserId { get; set; }
        //
        [Required()]
        public string Grade { get; set; }
        //[Required()]
         
        public ApplicationUser User { get; set; }
    }
}
