using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Web.ViewModels
{
    public class DataViewModel
    {
        public string Name { get; set; }
        public IFormFile Data { get; set; }
    }
}
