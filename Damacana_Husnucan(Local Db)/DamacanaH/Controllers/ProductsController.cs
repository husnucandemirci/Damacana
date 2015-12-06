﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DamacanaH.Models;

namespace DamacanaH.Controllers
{
    

    public class ProductsController : Controller
    {
        public static List<Product> CartProducts = new List<Product>
        {

        };
        private ProductDBContext db = new ProductDBContext();
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
       
        public ActionResult NewProduct(Product product)
        {
         
        //<div class="form-group">
        //<label>Id</label>
        //@Html.TextBoxFor(x => x.Id, new { @class = "form-control" })
        //</div>
            return View(product);
        }
        
        public ActionResult SaveProduct(Product product)
        {
            
            db.Products.Add(product);
            db.SaveChanges();
            return View(product);
        }
        public ActionResult DeleteFromList(string Name)
        {
            foreach (Product p in db.Products)
            {
                if (p.Name == Name)
                {
                    db.Products.Remove(p);
                    break;
                }
            }
            
            db.SaveChanges();
            return View();
        }
        public ActionResult Edit(string Name)
        {
            Product product = new Product();
            foreach (Product p in db.Products)
            {

                if (p.Name == Name)
                {


                    product.Name = p.Name;
                    product.Price = p.Price;
                    product.Id = p.Id;


                    db.Products.Remove(p);
                    break;
                }

            }
            db.SaveChanges();
            return View(product);
          //<div class="form-group">
          //@Html.LabelFor(model => model.Id, htmlAttributes: new { @class = "control-label col-md-2" })
          //<div class="col-md-10">
          //@Html.EditorFor(model => model.Id, new { htmlAttributes = new { @class = "form-control" } })
          //@Html.ValidationMessageFor(model => model.Id, "", new { @class = "text-danger" })
          //</div>
          //</div>
        }
        public ActionResult Editlenmis(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return View(product);
            
        }
        public ActionResult AddCart(string Name)
        {

            Product product = new Product();
            
            foreach (var p in db.Products)
            {
                if (p.Name == Name)
                {
                    product.Name = p.Name;
                    product.Id = p.Id;
                    product.Price = p.Price;
                    CartProducts.Add(p);
                    break;
                 }
             }
           return View(product);
         }
        public ActionResult Cart()
        {
            
            return View(CartProducts);
        }
        public ActionResult DeleteFromCart(string Name)
        {
            foreach(Product p in CartProducts )
            {
                if(p.Name == Name)
                {
                    CartProducts.Remove(p);
                    break;
                }

                
            }

            return View();
        }

         public ActionResult Purchase()
        {
            Purchase purchase = new Purchase();
            decimal totalprice = 0;
            purchase.PurchaseList = new List<Product>();
            foreach(Product p in CartProducts)
            {
                purchase.PurchaseList.Add(p);
                totalprice = p.Price + totalprice;
            }
            purchase.TotalPrice = totalprice;
            return View(purchase);
           
        }
  }
}
//