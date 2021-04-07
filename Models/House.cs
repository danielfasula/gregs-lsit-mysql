using System.ComponentModel.DataAnnotations;

namespace gregs_list_mysql.Models
{
    public class House
    {
        [Required]
        public int? Bedrooms { get; set; }
        [Required]
        public int? Bathrooms { get; set; }
        [Required]
        public int? Levels { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int? Price { get; set; }
        [Required]
        public int Id { get; set; }
    }
}