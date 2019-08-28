using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuraboStockManagement.Models
{
    public class TypeMouvement
    {
        public int TypeMouvementID { get; set; }
        public string Designation { get; set; }
        public short Sens { get; set; }

    }
}