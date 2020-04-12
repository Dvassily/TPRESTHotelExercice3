using System;
using System.Collections.Generic;
using System.Text;

namespace HotelProtocol
{
    public class RequeteOffreAgence
    {
        public string Ville { get; set; }
        public DateTime DateArrivee { get; set; }
        public DateTime DateDepart { get; set; }
        public int NombrePersonnes { get; set; }
        public int NombreEtoiles { get; set; }
    }
}
