using Newtonsoft.Json;
using System.Collections.Generic;

namespace Comparaison
{
    public class OffreComparee
    {
        [JsonProperty("nomHotel")]
        public string NomHotel { get; set; }

        [JsonProperty("adresseHotel")]
        public string AdresseHotel { get; set; }

        [JsonProperty("nombreEtoiles")]
        public int NombreEtoiles { get; set; }

        [JsonProperty("villeHotel")]
        public string VilleHotel { get; set; }

        [JsonProperty("prixAgences")]
        public Dictionary<string, double> prices = new Dictionary<string, double>();
    }
}