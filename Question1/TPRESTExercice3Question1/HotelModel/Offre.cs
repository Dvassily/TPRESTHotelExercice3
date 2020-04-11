using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelModel
{
    public class Offre
    {
        public long Id { get; set; }
        public int NombreDeLits { get; set; }
        public DateTime DateArrivee { get; set; }
        public DateTime DateDepart { get; set; }
        public double Prix { get; set; }
        public long ChambreId { get; set; }
    }
}
