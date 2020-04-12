using HotelModel;
using System;
using System.Collections.Generic;

namespace ClientAgenceService
{
    internal class Comparateur
    {
        private List<OffreAgence> Offres;
        public List<OffreComparee> Resultat { get; set; } = new List<OffreComparee>();

        public Comparateur(List<OffreAgence> offres)
        {
            Offres = offres;
        }

        internal Comparateur Comparer()
        {
            foreach (OffreAgence offre in Offres)
            {
                Console.WriteLine(offre.HotelId + " " + offre.ChambreId);
                OffreComparee offreComparee = trouverOffreComparee(offre.HotelId, offre.ChambreId);

                if (offreComparee != null)
                {
                    offreComparee.ComparatifPrix[offre.NomAgence] = offre.Prix;
                } else
                {
                    offreComparee = new OffreComparee
                    {
                        NomHotel = offre.NomHotel,
                        VilleHotel = offre.VilleHotel,
                        AdresseHotel = offre.AdresseHotel,
                        NombreEtoiles = offre.NombreEtoiles,
                        NombreDeLits = offre.NombreDeLits,
                        HotelId = offre.HotelId,
                        ChambreId = offre.ChambreId
                    };

                    offreComparee.ComparatifPrix[offre.NomAgence] = offre.Prix;

                    Resultat.Add(offreComparee);
                }
            }

            return this;
        }

        private OffreComparee trouverOffreComparee(long hotelId, long chambreId)
        {
            foreach (OffreComparee offreComparee in Resultat)
            {
                if (offreComparee.HotelId == hotelId && offreComparee.ChambreId == chambreId)
                {
                    return offreComparee;
                }
            }

            return null;
        }
    }
}