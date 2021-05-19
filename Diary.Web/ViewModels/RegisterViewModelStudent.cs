using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Diary.Web.Data;

namespace Diary.Web.ViewModels
{
    public class RegisterViewModelStudent
    {
        [Required()]
        public Class Class { get; set; }
    }
}
