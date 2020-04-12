using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelModel
{
    public class OffreAgence
    {
        [JsonProperty("nomHotel")]
        public string NomHotel { get; set; }

        [JsonProperty("villeHotel")]
        public string VilleHotel { get; set; }

        [JsonProperty("adresseHotel")]
        public string AdresseHotel { get; set; }

        [JsonProperty("nombreEtoiles")]
        public int NombreEtoiles { get; set; }

        [JsonProperty("nombreDeLits")]
        public int NombreDeLits { get; set; }

        [JsonProperty("prix")]
        public double Prix { get; set; }

        [JsonProperty("chambreId")]
        public long ChambreId { get; set; }

        [JsonProperty("hotelId")]
        public long HotelId { get; set; }

        [JsonProperty("NomAgence")]
        public string NomAgence { get; set; }
    }
}
