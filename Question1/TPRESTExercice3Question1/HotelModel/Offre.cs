using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelModel
{
    public class Offre
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nombreDeLits")]
        public int NombreDeLits { get; set; }

        [JsonProperty("dateArrivee")]
        public DateTime DateArrivee { get; set; }

        [JsonProperty("dateDepart")]
        public DateTime DateDepart { get; set; }

        [JsonProperty("prix")]
        public double Prix { get; set; }

        [JsonProperty("chambreId")]
        public long ChambreId { get; set; }

        [JsonProperty("hotelId")]
        public long HotelId { get; set; }
    }
}
