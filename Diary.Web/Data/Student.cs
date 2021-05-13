using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        //[Required()]
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
    }
    
}
