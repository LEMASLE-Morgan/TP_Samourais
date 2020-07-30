using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Samouraï.BO
{
    public class ArtMartial
    {

        public int Id { get; set; }
        public string Nom { get; set; }

        public virtual List<Samourai> Samourais { get; set; }
    }
}