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
        
        public string UserId { get; set; }
        
        public int ClassId { get; set; }
        [Required()]
        public Class Class { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
    }
    
}
