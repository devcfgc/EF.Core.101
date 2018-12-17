using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NorthWind.DAL;
using NorthWind.Entities;

namespace NorthWind.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Category> categories;
            using (var context = new NorthWindContext())
            {
                categories = context.Categories.ToList();
            }

            return View(categories);
        }

        [HttpPost]
        public ActionResult Index(string categoryName)
        {
            using (var context = new NorthWindContext())
            {
                var newCategory = new Category()
                {
                    CategoryName = categoryName
                };
                context.Categories.Add(newCategory);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var category = new Category();
            using (var context = new NorthWindContext())
            {
                category = context.Categories.FirstOrDefault(c => c.CategoryId == id);
            }

            return View(category);
        }

        [HttpPost]
        public ActionResult UpdateOrDelete(Category category, string BtnUpdate, string BtnDelete)
        {
            using (var context = new NorthWindContext())
            {
                if (BtnUpdate != null)
                {
                    context.Categories.Update(category);
                }
                else if (BtnDelete != null)
                {
                    context.Categories.Remove(category);
                }

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}