using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace FrontToBack.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string? Name { get; set; }
        [Required,MinLength(5)]
        public string ?Description { get; set; }
        public List<Product>? Products { get; set; } 
    }
}
