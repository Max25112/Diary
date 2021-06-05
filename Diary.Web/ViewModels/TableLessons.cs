using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Web.ViewModels
{
    public class TableLessons
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string ClassName { get; set; }
        public string SubjectName { get; set; }
        public string Cabinet { get; set; }
        public int Order { get; set; }
    }
}
