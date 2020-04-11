using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelModel
{
    public class Agence
    {
        public long Id { get; set; }
        public string IdentifiantAgence { get; set; }
        public string MotDePasseAgence { get; set; }
        public double Reduction { get; set; }
    }
}
