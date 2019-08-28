using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DuraboStockManagement.Models
{
    public class Mouvement
    {
        public int MouvementID { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateMouvement { get; set; }

        [ForeignKey("TypeMouvement")]
        public int TypeMouvementID { get; set; }
        public TypeMouvement TypeMouvement { get; set; }

        [ForeignKey("MagasinEntree")]
        public int EntreeMagasinID { get; set; }       
        public virtual Magasin MagasinEntree { get; set; }


        [ForeignKey("MagasinSortie")]
        public int SortieMagasinID { get; set; }
        public virtual Magasin MagasinSortie { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public int QuantitéDemandée { get; set; }
        public bool EstApprouvee { get; set; }
        public bool EstRefusee { get; set; }
        public string NomApprobateur { get; set; }
        public string NomDemandeur { get; set; }

       
    }
}