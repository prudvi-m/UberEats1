using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberEats.Models;

namespace UberEats.Areas.Admin.Controllers
{
    [Area("Admin")]
    
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
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [Route("[area]/[controller]s/{id?}")]
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
        [Route("[area]/[controller]/add")]
        [HttpGet]
        public IActionResult Add()
        {
            // create new Driver object
            Driver driver = new Driver();                

            // use ViewBag to pass action and category data to view
            ViewBag.Action = "Add";
            ViewBag.Categories = categories;

            // bind driver to AddUpdate view
            return View("AddUpdate", driver);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            // get Driver object for specified primary key
            Driver driver = context.Drivers
                .FirstOrDefault(p => p.DriverID == id) ?? new Driver();

            // use ViewBag to pass action and category data to view
            ViewBag.Action = "Update";
            ViewBag.Categories = categories;

            // bind driver to AddUpdate view
            return View("AddUpdate", driver);
        }

        [HttpPost]
        public IActionResult Update(Driver driver)
        {
            if (ModelState.IsValid)
            {
                if (driver.DriverID == 0)           // new driver
                {
                    context.Drivers.Add(driver);
                }
                else                                  // existing driver
                {
                    context.Drivers.Update(driver);
                    TempData["Message"] = "Driver Application has been Updated";
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                ViewBag.Categories = categories;
                return View("AddUpdate", driver);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Driver driver = context.Drivers
                .FirstOrDefault(p => p.DriverID == id) ?? new Driver();
            return View(driver);
        }

        [HttpPost]
        public IActionResult Delete(Driver driver)
        {
            context.Drivers.Remove(driver);
            context.SaveChanges();
            TempData["Message"] = "Driver Application has been Removed";
            return RedirectToAction("List");
        }

        

        [HttpGet]
       
        public IActionResult Approve(int id)
        {
            Driver driver = context.Drivers
                .FirstOrDefault(p => p.DriverID == id) ?? new Driver();
                 ViewBag.Dta="Approve";
                 TempData["data"]="Approve";
              
            return View(driver);
        }

        [HttpPost]
        public IActionResult Approve(Driver driver)
        {
            if (driver.Status == "Approved" || driver.Status == "Reject")
            {
                // Retrieve the existing driver from the database
                var existingDriver = context.Drivers.Find(driver.DriverID);

                if (existingDriver != null)
                {
                    // Update the status of the existing driver
                    existingDriver.Status = driver.Status;
                    context.Drivers.Update(existingDriver);
                    // Save the changes to the database
                    context.SaveChanges();

                    TempData["Message"] = "Driver Application has been " + driver.Status.ToLower();
                }
                else
                {
                    TempData["Message"] = "Driver not found. Please provide a valid driver ID.";
                }
            }
            else
            {
                TempData["Message"] = "Invalid status value. Please provide a valid status.";
            }

            return RedirectToAction("List");
        }

    }
}