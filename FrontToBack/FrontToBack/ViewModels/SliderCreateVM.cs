using Microsoft.Build.Framework;
using Microsoft.Extensions.FileProviders;

namespace FrontToBack.ViewModels
{
    public class SliderCreateVM
    {
        [Required]
        public IFormFile Photo { get; set; }
    }
}
