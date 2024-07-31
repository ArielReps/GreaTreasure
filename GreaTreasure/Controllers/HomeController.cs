using GreaTreasure.DAL;
using GreaTreasure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml;

namespace GreaTreasure.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(Data.Get.Libraries);
        }
        public IActionResult CreateLibrary()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateLibrary(Library library)
        {
            if ((library != null))
            {
                Data.Get.Libraries.Add(library);
                Data.Get.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Shelves(int? id)
        {
            if (!IsNull(id))
            {
                Library? library = Data.Get.Libraries.FirstOrDefault(x => x.Id == id);
                if (library != null)
                {
                    TempData["libID"] = library.Id;
                    return View(library.Shelves);
                }
            }
            return RedirectToAction("Index");


        }
        public IActionResult CreateShelf(int? id)
        {
            ViewBag.libID = id;
            return View();
        }
        [HttpPost]
        public IActionResult CreateShelf(Shelf shelf, int libID)
        {
            if (shelf != null)
            {
                Library? templib = Data.Get.Libraries.Include(s => s.Shelves).FirstOrDefault(x => x.Id == libID);
                if (templib != null)
                {
                    shelf.library = templib;
                    templib.Shelves.Add(shelf);
                    Data.Get.SaveChanges();
                }
            }
            return RedirectToAction("Shelves");
        }

        public bool IsNull(int? num)
        {
            return num == null;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
