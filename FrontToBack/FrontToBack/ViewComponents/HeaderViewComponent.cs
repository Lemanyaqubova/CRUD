using FrontToBack.DAL;
using FrontToBack.Models;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontToBack.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public HeaderViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {


            string basket = Request.Cookies["basket"];
            if (string.IsNullOrWhiteSpace(basket))
            {
                BasketVM basketVM = new();
                basketVM.BasketCount = 0;
            }
            else
            {
                var products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                ViewBag.BasketProductCount = products.Count();
            }
          
            Bio bio = _appDbContext.Bios.FirstOrDefault();
            return View(await Task.FromResult(bio));

        }
    }
}
