using System.Collections.Generic;

namespace ClientAgenceService
{
    internal class OffreComparee
    {
        public string NomHotel { get; set; }
        public string VilleHotel { get; set; }
        public string AdresseHotel { get; set; }
        public int NombreEtoiles { get; set; }
        public int NombreDeLits { get; set; }
        public Dictionary<string, double> ComparatifPrix { get; set; } = new Dictionary<string, double>();
        public long HotelId { get; set; }
        public long ChambreId { get; set; }
    }
}