using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository repository;
        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ActionResult Edit(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["savemessage"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                /*foreach (ModelState state in ViewData.ModelState.Values.Where(x => x.Errors.Count > 0))
                {
                    //state.Errors
                }*/
                return View(product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "ProductID")]Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["savemessage"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", product);
            }
        }
	}
}