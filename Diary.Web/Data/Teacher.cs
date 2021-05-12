﻿using System;
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
    public class Teacher
    {
        //[Key]
        //public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public int UserId { get; set; }
        //
        public string Post { get; set; }
        public List<Subject> Subjects { get; set; } = new List<Subject>();
        //[Required()]
        
        [Required()]
        public ApplicationUser User { get; set; }
    }
}
