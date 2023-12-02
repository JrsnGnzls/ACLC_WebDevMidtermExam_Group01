using System.ComponentModel.DataAnnotations;

namespace ACLC_WebDevMidtermExam_Group01.Models
{
    public class joborder
    {
        [Key]
        public int? id { get; set; }
        public string? name { get; set; }
        public string? category { get; set; }
        public DateTime? date_time { get; set; }
        public string? description { get; set; }
    }
}
