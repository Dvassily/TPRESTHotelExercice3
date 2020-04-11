using System;
using System.Collections.Generic;
using System.Text;

namespace HotelModel
{
    public class Reservation
    {
        public long Id { get; set; }
        public long ChambreId { get; set; }
        public DateTime DateArrivee { get; set; }
        public DateTime DateDepart { get; set; }
        public double Prix { get; set; }
        public string NomClient { get; set; }
        public string PrenomClient { get; set; }
        public string NumeroCarteClient { get; set; }
        public string IdentifiantAgence { get; set; }
    }
}
