using FashionShop.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FashionShop.Models;
using PagedList;

namespace FashionShop.Controllers
{
    public class HomeController : Controller
    {
        private const string CartSession = "CartSession";

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //Header Icon
        public ActionResult HeaderIcon()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();

            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }

        //Header quantity
        public ActionResult HeaderQuantity()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();

            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }

            return PartialView(list);
        }

        //Show menubar
        public ActionResult menubar()
        {
            var bar = new MenuBar().menu();
            return PartialView(bar);
        }

        //Show data banner
        public ActionResult showBanner()
        {
            var banner = new Category().Cate();
            return PartialView(banner);
        }

        //Show new products
        public ActionResult newProducts()
        {
            var _newProduct = new ShowProduct().newProduct();
            return PartialView(_newProduct);
        }

        //show news
        public ActionResult news()
        {
            var _news = new News().showNews();

            return PartialView(_news);
        }
    }
}