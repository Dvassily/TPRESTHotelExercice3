using HotelModel;
using System.Collections.Generic;

namespace InterfaceAgence
{
    public class ReponseRecherche
    {
        public List<Offre> offres { get; set; }
        public long hotelId { get; set; }
    }
}