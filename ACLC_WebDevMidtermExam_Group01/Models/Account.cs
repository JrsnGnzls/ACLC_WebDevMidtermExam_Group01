using System.ComponentModel.DataAnnotations;

namespace ACLC_WebDevMidtermExam_Group01.Models
{
    public class Account
    {
        [Key]
        public int? id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
