
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuraboStockManagement.Models
{
    public class DemandeMateriel
    {
        public int DemandeID { get; set; }
        public DateTime DateDemande { get; set; }
        
        public int CooperativeID { get; set; }
        public Cooperative Entree { get; set; }

        public int MagasinID { get; set; }
        public Magasin Sortie { get; set; }
        public ICollection<Article> Articles { get; set; }

        public int QuantitéDemandée { get; set; }

        public bool EstApprouvee { get; set; }
        public bool EstRefusee { get; set; }

        public string NomApprobateur { get; set; }
        public string NomDemandeur { get; set; }
    }
}