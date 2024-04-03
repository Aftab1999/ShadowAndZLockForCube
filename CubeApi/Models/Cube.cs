using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class Cube
    {
        public int Id { get; set; }
        [Required]
        public double Width { get; set; }
        [Required]
        public double Length { get; set; }
        [Required]
        public double Height { get; set; }
    }
}
