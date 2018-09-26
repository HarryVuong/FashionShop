using FashionShop.Models.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionShop.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult News(int? page)
        {
            var showNews = new News().show();

            int pageSize = 3;
            int pageNumber = page ?? 1;

            if (showNews == null)
                return View("Error");
            return View(showNews.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult NewsDetail(string meta, int id)
        {
            var showNews = new News().newsDetail(id);
            return View(showNews);
        }

        //Category
        public ActionResult Category()
        {
            var cate = new Category().Cate();
            return PartialView(cate);
        }

        //Product
        public ActionResult Product()
        {
            var Prod = new ShowProduct().ProductHot();
            return PartialView(Prod);
        }
    }
}