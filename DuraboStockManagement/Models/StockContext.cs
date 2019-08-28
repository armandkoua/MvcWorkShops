using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DuraboStockManagement.Models
{
    public class StockContext: DbContext
    {
        public StockContext(): base ("CMSStockDB")
        {

        }

        //protected override void OnModelCreating(DbModelBuilder builder)
        //{
        //    //builder.Entity<Mouvement>()
        //    //    .HasRequired<Magasin>( m => m.MagasinSortie)
        //    //    .WithMany()
        //    //    .HasForeignKey<int>(m => m.SortieMagasinID)
        //    //    .WillCascadeOnDelete(false);
        //}

        public DbSet<Article> Articles { get; set; }
        public DbSet<Magasin> Magasins { get; set; }
        public DbSet<Mouvement> Mouvements { get; set; }
        public DbSet<TypeMouvement> TypeMouvements { get; set; }

        public System.Data.Entity.DbSet<DuraboStockManagement.Models.Cooperative> Cooperatives { get; set; }
    }
}