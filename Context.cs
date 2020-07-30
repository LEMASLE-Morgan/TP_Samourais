using BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TP_Samouraï.BO;

namespace TP_Samouraï
{
    public class Context : DbContext
    {
        public DbSet<Samourai> Samourais { get; set; }

        public DbSet<Arme> Armes { get; set; }

        public DbSet<ArtMartial> ArtMartials { get; set; }

       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Un samourai possède une liste d'arts martiaux
            modelBuilder.Entity<Samourai>().HasMany(s => s.ArtsMartiaux).WithMany();

            //Une arme ne peut appartenir qu'à un seul samourai
            modelBuilder.Entity<Samourai>().HasOptional(s => s.Arme);

            
        }
    }
}