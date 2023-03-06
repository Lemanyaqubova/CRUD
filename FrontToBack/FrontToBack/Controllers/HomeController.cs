using FrontToBack.DAL;
using FrontToBack.Models;

using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FrontToBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;
        

        

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
           
            HomeVM homeVM = new HomeVM();
            homeVM.Sliders = _appDbContext.Sliders.ToList();
            homeVM.SliderDetail = _appDbContext.SliderDetails.FirstOrDefault();
            homeVM.Categories = _appDbContext.Categories.ToList();
            homeVM.Products = _appDbContext.Products.Include(p=>p.ProductImages).ToList();
            return View(homeVM);
        }

       
    }
}