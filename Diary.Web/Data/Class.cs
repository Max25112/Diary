using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Web.Data
{
    public class Class
    {
        public int Id {get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

    }
}
