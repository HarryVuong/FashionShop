using FashionShop.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FashionShop.Models.DAO
{
    public class ShowProduct
    {
        FashionShopDB db = null;

        public ShowProduct()
        {
            db = new FashionShopDB();
        }

        public List<Product> products()
        {
            return db.Product.ToList();
        }

        public List<Product> SearchProductPrice(int price)
        {
            if(price == 50000)
            {
                return db.Product.Where(x => x.ProductPrice > price).OrderBy(x => x.ID).ToList();
            }
            else if(price == 100000)
            {
                return db.Product.Where(x => x.ProductPrice >= price && x.ProductPrice < 300000).OrderBy(x => x.ID).ToList();
            }else if (price == 300000)
            {
                return db.Product.Where(x => x.ProductPrice >= price && x.ProductPrice < 600000).OrderBy(x => x.ID).ToList();
            }else
            {
                return db.Product.Where(x => x.ProductPrice >= price).OrderBy(x => x.ID).ToList();
            }
        }

        public List<Product> SearchProduct(string productName)
        {
            return db.Product.Where(x => x.ProductName.Contains(productName)).OrderBy(x => x.ID).ToList();
        }

        public List<Product> Product(Int32 id)
        {
            return db.Product.Where(x => x.MenuCateID == id).OrderBy(x => x.ID).ToList();
        }

        public List<Product> newProduct()
        {
            return db.Product.OrderByDescending(x => x.ID).Take(8).ToList();
        }

        public List<Product> ProductHot()
        {
            return db.Product.OrderByDescending(x => x.ID).Take(5).ToList();
        }

        public Product ProductDetail(int id)
        {
            var prod = from p in db.Product
                       where p.ID == id
                       select p;
            return prod.FirstOrDefault();
        }
    }
}