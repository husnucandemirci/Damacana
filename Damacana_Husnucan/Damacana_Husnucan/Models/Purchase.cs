using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Damacana_Husnucan.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal TotalPrice { get; set; }

        public List<Product> PurchaseList { get; set; }

        public virtual User User { get; set; }
    }
}