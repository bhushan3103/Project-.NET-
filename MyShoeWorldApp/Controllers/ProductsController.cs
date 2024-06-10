using MyShoeWorldApp.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShoeWorldApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductDal _productDal;
        //IoC will inject the required object instance via constructor dependency injection
        public ProductsController(ProductDal productDal)
        {
            _productDal = productDal;
        }
        // GET: Products
        public ActionResult List()
        {
            ViewBag.PageTitle = "Welcome To MyShoeWorld Products List";
            return View(_productDal.GetAllProducts());
        }
        public ActionResult Details(int id)
        {
            ViewBag.PageTitle = "Details Of - ";
            return View(_productDal.GetProductDetails(id));
        }
    }
}