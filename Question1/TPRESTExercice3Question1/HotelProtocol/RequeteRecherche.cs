using System;

namespace HotelProtocol
{
    public class RequeteRecherche
    {
        public string IdentifiantAgence { get; set; }
        public string MotDePasseAgence { get; set; }
        public int NombrePersonnes { get; set; }
        public DateTime DateArrivee { get; set; }
        public DateTime DateDepart { get; set; }
        public string VilleHotel { get; set; }
        public int NombreEtoiles { get; set; }
    }
}