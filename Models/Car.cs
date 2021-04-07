using System.ComponentModel.DataAnnotations;

namespace gregs_list_mysql.Models
{
    public class Car
    {
        [Required]
        public string Make { get; set; }
        [Required]

        public string Model { get; set; }
        [Required]

        public int? Year { get; set; }
        [Required]
        public int? Miles { get; set; }
        [Required]
        public int? Price { get; set; }
        public int Id { get; set; }
    }
}