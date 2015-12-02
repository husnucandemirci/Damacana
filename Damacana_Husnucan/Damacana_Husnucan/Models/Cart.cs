using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Damacana_Husnucan.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }

        public List<Product> Cartproducts { get; set; }

        public virtual User User { get; set; }
    }
}