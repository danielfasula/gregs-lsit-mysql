using System.ComponentModel.DataAnnotations;

namespace gregs_list_mysql.Models
{
    public class Job
    {
        [Required]
        public string Company { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public int? Hours { get; set; }
        [Required]
        public int? Rate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Id { get; set; }
    }
}