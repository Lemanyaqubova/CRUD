using FrontToBack.DAL;
using FrontToBack.Models.Demo;
using FrontToBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FrontToBack.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class DemeController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _env;

        public DemeController(AppDbContext appDbContext, IWebHostEnvironment env)
        {
            _appDbContext = appDbContext;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.Authors=new SelectList(_appDbContext.Authors.ToList(),"Id","Name");
            ViewBag.Genres=new SelectList(_appDbContext.Genres.ToList(),"Id","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookCreateVM bookCreateVM) 
        {
            ViewBag.Authors = new SelectList(_appDbContext.Authors.ToList(), "Id", "Name");
            ViewBag.Genres = new SelectList(_appDbContext.Genres.ToList(), "Id", "Name");
            List<BookGenre> bookGenres = new();
            List<BookAuthor> bookAuthors = new();

            Book newBook = new();
            newBook.Name = bookCreateVM.Name;
            return View();
        }
    }
}
