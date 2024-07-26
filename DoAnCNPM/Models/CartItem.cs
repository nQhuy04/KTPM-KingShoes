using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnCNPM.Models
{
    public class CartItem
    {
        DB_KingShoesEntities db = new DB_KingShoesEntities();

        public int ProductID { get; set; }
        public string NamePro { get; set; }
        public string ImagePro { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
        public int Size { get; set; }

        public decimal FinalPrice()
        {
            return Number * Price;
        }

        public CartItem()
        {
            // Constructor mặc định
        }

        public CartItem(int productID)
        {
            this.ProductID = productID;
            var productDB = db.Products.Single(s => s.ProductID == this.ProductID);
            this.NamePro = productDB.ProductName;
            this.ImagePro = productDB.ImageProduct;
            this.Price = (decimal)productDB.Price;
            this.Number = 1;
        }

        public CartItem(int productID, string namePro, string imagePro, decimal price, int number, int size)
        {
            this.ProductID = productID;
            this.NamePro = namePro;
            this.ImagePro = imagePro;
            this.Price = price;
            this.Number = number;
            this.Size = size;
        }
    }
}