using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UberEats.Models;

namespace UberEats.Controllers
{
    public class DriverController : Controller
    {
        private UberContext context;
        private List<Category> categories;
       
        public DriverController(UberContext ctx)
        {
            context = ctx;
            categories = context.Categories
                    .OrderBy(c => c.CategoryID)
                    .ToList();
            ViewBag.Categories = categories;
        }

        public IActionResult List(string id = "All")
        {
            List<Driver> products;
            if (id == "All")
            {
                products = context.Drivers
                    .OrderBy(p => p.DriverID).ToList();
            }
            else
            {
                products = context.Drivers
                    .OrderBy(p => p.DriverID).ToList();
            }

            // use ViewBag to pass category data to view
            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = id;

            // bind products to view
            return View(products);
        }

        public IActionResult Detail(int id)
        {
            var session = new UberSession(HttpContext.Session);
            var model = new DriversViewModel
            {
                Driver = context.Drivers
                    .FirstOrDefault(t => t.DriverID == id) ?? new Driver(),
                ActiveDiv = session.GetActiveDiv(),
                ActiveConf = session.GetActiveConf()
            };
            return View(model);
        }
      
        public IActionResult Index()
        {
            return View();
        }

       [Route("[controller]/add")]
       [HttpGet]
        public IActionResult add()
        {
            Driver driver = new Driver(); 
            ViewBag.Categories = categories;
            return View("add",driver);
        }
       
        [HttpPost]
        public IActionResult Add(Driver driver)
        {
            if (ModelState.IsValid)
            {
                context.Drivers.Add(driver);
                context.SaveChanges();
                TempData["Message"] = "Driver Application has been received. We will email you once the application has been received.";
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Categories = categories;
            // If ModelState is not valid, return to the add view with validation errors
            return View("Add", driver);
        }
    }
}
