using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Diary.Web.Views.ViewModels
{
    public class SubjectViewModel
    {
        [Required()]
        [Display(Name = "Название предмета")]
        public string Name { get; set; }
    }
}
