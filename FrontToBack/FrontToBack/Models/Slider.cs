using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrontToBack.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string ImageUrl{ get; set; }
        [NotMapped]
        [Required]
        public IFormFile Photo  { get; set; }

       
    }
}
