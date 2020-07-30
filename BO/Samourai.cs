using System.Collections.Generic;
using TP_Samouraï.BO;

namespace BO
{
    public class Samourai
    {
        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }

        public virtual List<ArtMartial> ArtsMartiaux { get; set; }
    }
}
