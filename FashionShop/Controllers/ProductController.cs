using FashionShop.Models.DAO;
using FashionShop.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop.Controllers
{
    public class ProductController : Controller
    {
        FashionShopDB db = null;
        public ProductController()
        {
            db = new FashionShopDB();
        }
        // GET: Product
        public ActionResult MenuCate()
        {
            var model = new Models.DAO.Category().Cate();
            return PartialView(model);
        }

        //Get product theo Category
        public ActionResult CategoryMenu(Int32 id)
        {
            var cate = new Models.DAO.Category().MenuCate(id);
            return PartialView(cate);
        }

        public ActionResult ProductDetail(string metatitle, int ID)
        {         
            var prodDetail = new ShowProduct().ProductDetail(ID);
            return View(prodDetail);
        }

        public ActionResult SearchPrice(int price, int? page)
        {
            var pageNumber = page ?? 1;

            var product = new ShowProduct().SearchProductPrice(price);
            return PartialView(product.ToPagedList(pageNumber, 12));
        }

        public ActionResult Products(int? page)
        {
            var pageNumber = page ?? 1;

            var product = new ShowProduct().products();
            return PartialView(product.ToPagedList(pageNumber, 12)); 
        }

        //formcollection dùng cho search form lấy dữ liệu khi nhập vào ô textbox
        public ActionResult Product(string meta, int? id, int? page, FormCollection fc)
        {
            var pid = id ?? 1;
            var pageNumber = page ?? 1;

            string name = fc["search-product"];
            if(name != null)
            {
                var product = new ShowProduct().SearchProduct(name);
                return View(product.ToPagedList(pageNumber, 12));
            }
            else
            {
                var products = new ShowProduct().Product(pid);
                return View(products.ToPagedList(pageNumber, 12));
            }
        }

        public ActionResult PartialProduct(int id)
        {
            var p = new ShowProduct().Product(id);
            return PartialView(p);
        }

        //Search product
        public ActionResult SearchProduct()
        {
            return PartialView();
        }
    }
}