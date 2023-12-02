using System.ComponentModel.DataAnnotations;

namespace ACLC_WebDevMidtermExam_Group01.Models
{
    public class User
    {
        [Key]
        public int? id { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
