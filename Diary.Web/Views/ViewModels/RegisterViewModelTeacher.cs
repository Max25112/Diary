using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Diary.Web.Data;

namespace Diary.Web.Views.ViewModels
{
    public class RegisterViewModelTeacher
    {
        [Required()]
        [Display(Name = "Должность")]
        public string Post { get; set; }

        [Required()]
        [Display(Name = "Предмет")]
        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
