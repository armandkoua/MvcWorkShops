using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuraboStockManagement.Models
{
   
    public class Article
    {
        public int ArticleID { get; set; }
        public string Designation { get; set; }
        public virtual ICollection<Mouvement> Mouvements { get; set; }

    }
}