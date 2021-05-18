using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Diary.Web.Data;
namespace Diary.Web.Views.ViewModels
{
    public class ClassViewModelcs
    {
        [Required()]
        [Display(Name = "Название класса")]
        public string Name { get; set; }
    }
}
