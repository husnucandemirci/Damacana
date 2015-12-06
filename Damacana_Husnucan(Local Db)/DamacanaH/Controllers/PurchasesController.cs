using System;
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
    public class PurchasesController : Controller
    {

        private PurchaseDBContext db2 = new PurchaseDBContext();
       
        public ActionResult PurchaseDone(Purchase purchase)
        {
            purchase.CreatedOn = DateTime.Now;
            purchase.UserId = 1;
            db2.Purchases.Add(purchase);
            db2.SaveChanges();
            return View(purchase);
              //@for (int i = 0; i < Model.PurchaseList.Count(); i++)
              //{
              //<ul>
              //<li>
              //@Model.PurchaseList[i].Price TL -  @Model.PurchaseList[i].Name
              //</li>
              //</ul>}
                
        }
        public ActionResult PurchaseHistory()
        {

        return View(db2.Purchases);

        }
    }
}
