using System.ComponentModel.DataAnnotations;

namespace ACLC_WebDevMidtermExam_Group01.Models
{
    public class Account
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
