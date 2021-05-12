using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Web.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required()]
        public string FirstName { get; set; }
        [Required()]
        public string LastName { get; set; }
        [Required()]
        public string MiddleName { get; set; }
        //public Student Student { get; set; }
        public Teacher Teacher { get; set; }
    }
}
