using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShoeWorldApp.Dal;
using MyShoeWorldApp.Models;
namespace MyShoeWorldApp.Controllers
{
    public class CartsController : Controller
    {
        List<Cart> carts;
        private readonly ProductDal _productDal;
        public CartsController(ProductDal productDal) 
        { 
            _productDal= productDal;
        }
        // GET: Carts
        public ActionResult AddToCart(int id)
        {
            Cart cart=new Cart()
            {
                CartDate= DateTime.Now,
                ProductId=id,
                Quantity=1
            };
            if (Session["Cart"].ToString() == string.Empty || Session["Cart"] == null)
            {
                carts = new List<Cart>();
                carts.Add(cart);
            }
            else
            {
                carts= Session["Cart"]as List<Cart>;
                carts.Add(cart);
            }
            Session["Cart"] = carts;
            List<Product> products = _productDal.GetCartProducts(carts);
            return View(products);
        }
    }
}