using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Samouraï.BO;

namespace TP_Samouraï.Models
{
    public class SamouraiVM
    {
        public Samourai Samourai { get; set; }
        public List<Arme> Armes { get; set; }
        public List<ArtMartial> ArtsMartiaux { get; set; } = new List<ArtMartial>();
        public int IdArmes { get; set; }

        public List<int> IdArtMartiaux { get; set; }
    }
}