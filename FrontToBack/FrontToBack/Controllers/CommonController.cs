using FrontToBack.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack.Controllers
{
    public class CommonController : Controller
    {
        private readonly AppDbContext appDbContext;

        public CommonController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IActionResult Search(string search)
        {
            var products=appDbContext.Products
            .Where(p => p.Name.Contains(search.ToLower()))
            .Take(2)
            .OrderByDescending(p => p.Id)  
            .ToList();
            return PartialView("_SearchPartial",products);
        }
    }
}
