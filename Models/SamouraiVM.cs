using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Samouraï.Models
{
    public class SamouraiVM
    {
        public Samourai Samourai { get; set; }
        public List<Arme> Armes { get; set; }

        public int IdArmes { get; set; }
    }
}