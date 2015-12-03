using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Damacana_Husnucan.Models;

namespace Damacana_Husnucan.Controllers
{
    public class HomeController : Controller
    {
        public static List<Product> products = new List<Product>()
        {
            
            new Product
            {
                Id = 1,
                Name = "Pinar 19L",
                Price = (decimal) 10.0
            },
            new Product
            {
                Id = 2,
                Name = "Erikli 19L",
                Price = (decimal) 12.5
            },
            new Product
            {
                Id = 3,
                Name = "Sırma 19L",
                Price = (decimal) 11.5
            },
            new Product
            {
                Id = 4,
                Name = "Evian 19L",
                Price = (decimal) 45
            },
       

        };
        public static List<Product> CartProducts = new List<Product>
        {

        };
        public static List<Cart> Cartlist = new List<Cart>
        {
        

        };
        
        public ActionResult Index()
        {

            return View(products);
        }

        public ActionResult NewProduct()
        {
            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        public ActionResult SaveProduct(Product product)
        {
            
            products.Add(product);



            return View(product);
        }
        public ActionResult Editlenmis(Product product)
        {
           
            products.Add(product);



            return View(product);
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
        public ActionResult DeleteFromList(string Name)
        {
            foreach (Product p in products)
            {
                if (p.Name == Name)
                {
                    products.Remove(p);
                    break;
                }

                
            }

            return View();
        }
        public ActionResult Edit(string Name)
        {
            
           
            Product product = new Product();

            foreach (Product p in products)
            {

                if (p.Name == Name)
                {


                    product.Name = p.Name;
                    product.Price = p.Price;
                    product.Id = p.Id;


                    products.Remove(p);
                    break;
                }

            }
            return View(product);
        }
        public ActionResult Cart()
        {
            

            return View(CartProducts);
        }
       
        public ActionResult AddCart(string Name)
        {
            Product product = new Product();
            
            foreach (var p in products)
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
        int Cartnumber = 1;
        public static Cart cart = new Cart();
        public ActionResult Purchase ()
        {

            cart.TotalPrice = 0;
            cart.Cartproducts = new List<Product>();
            cart.Id = Cartnumber;
            cart.UserId = 1;
            Product product = new Product();
            foreach (Product p in CartProducts)
            {
           
            product.Id = p.Id;
            product.Price = p.Price;
            product.Name = p.Name;
            cart.Cartproducts.Add(product);
            cart.TotalPrice = cart.TotalPrice + p.Price;
            Cartnumber++;
        }
            

         CartProducts.Clear();
         
           
        
        return View(cart);
        }
        public static List<Purchase> PurchaseList = new List<Purchase>
        {

        };
        static int Purchasenumber = 1;
       
        public ActionResult PurchaseDone()
        {
            Purchase p = new Purchase();
            p.Id = Purchasenumber;
            p.TotalPrice = cart.TotalPrice;
            p.UserId = 1;
            p.PurchaseList = new List<Product>();
            //Product K = new Product();
            //var Elemansayisi = cart.Cartproducts.Count();
            //int i = 0;
           
            //foreach (Product L in cart.Cartproducts){
                //p.PurchaseList[i].Id = L.Id;
                //p.PurchaseList[i].Price = L.Price;
                //p.PurchaseList[i].Name = L.Name;
                //i++;}
            
            p.CreatedOn = DateTime.Now;
            PurchaseList.Add(p);
            Purchasenumber++;
            
        return View(p);
        }
        public ActionResult PurchaseHistory()
        {

            return View(PurchaseList);
        }

    }
}
   