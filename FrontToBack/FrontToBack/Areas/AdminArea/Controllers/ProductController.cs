using FrontToBack.DAL;
using FrontToBack.Extentions;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_appDbContext.Products
                .Include(p=>p.ProductImages)
                 .Include(p => p.Category)
                 .ToList()
                );
        }
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_appDbContext.Categories.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductCreateVM productCreateVM)
        {
            ViewBag.Categories = new SelectList(_appDbContext.Categories.ToList(), "Id", "Name");
            if (!ModelState.IsValid) return View();
            List<ProductImage> productImages = new();

            foreach (var photo in productCreateVM.Photos)
            {
             
                if (!photo.IsImage())
                {
                    ModelState.AddModelError("Photos", "ancag shekil");
                    return View();
                }
                if (!photo.CheckImageSize(500))
                {
                    ModelState.AddModelError("Photos", "olcusu boyukdur");
                    return View();
                }   
                ProductImage productImage= new();
                productImage.ImageUrl = photo.SaveImage(_env, "img", photo.FileName);
                productImages.Add(productImage);

            }

            Product newproduct = new();
            newproduct.Name= productCreateVM.Name;
            newproduct.Price= productCreateVM.Price;
            newproduct.CategoryId= productCreateVM.CategoryId;
            newproduct.ProductImages= productImages;
            _appDbContext.Products.Add(newproduct);
            _appDbContext.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}
