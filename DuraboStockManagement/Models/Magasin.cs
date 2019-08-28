using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuraboStockManagement.Models
{
    public class Magasin
    {
        public int MagasinID { get; set; }
        public string NomMagasin { get; set; }
        public int QuantitéMaximale { get; set; }
    }
}