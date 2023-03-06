using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack.ViewComponents
{
    public class FooteriewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public FooteriewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
             FooterBio footerBio = _appDbContext.FooterBios.FirstOrDefault();
            return View(await Task.FromResult(footerBio));

        }
    }
}

