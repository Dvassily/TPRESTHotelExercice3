using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelModel;
using HotelProtocol;
using InterfaceAgence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agence1Service.Controllers
{
    [Route("agence1/[controller]")]
    [ApiController]
    public class OffreController : ControllerBase
    {
        [HttpPost]
        public List<OffreAgence> PostAsync([FromBody] RequeteOffreAgence requete)
        {
            List<ClientRechercheHotelService> clients = new List<ClientRechercheHotelService>();
            clients.Add(new ClientRechercheHotelService("https://localhost:44393/hotel1/Recherche"));
            clients.Add(new ClientRechercheHotelService("https://localhost:44309/hotel2/Recherche"));

            List<OffreAgence> offres = new List<OffreAgence>();
            foreach (ClientRechercheHotelService client in clients)
            {
                RequeteRecherche requeteRecherche = new RequeteRecherche
                {
                    IdentifiantAgence = "abcd",
                    MotDePasseAgence = "efgh",
                    NombrePersonnes = requete.NombrePersonnes,
                    DateArrivee = requete.DateArrivee,
                    DateDepart = requete.DateDepart,
                    VilleHotel = requete.Ville,
                    NombreEtoiles = requete.NombreEtoiles
                };

                foreach (Offre offre in client.Rechercher(requeteRecherche).Result)
                {
                    offres.Add(new OffreAgence
                    {
                        NomHotel = offre.NomHotel,
                        VilleHotel = offre.VilleHotel,
                        AdresseHotel = offre.AdresseHotel,
                        NombreEtoiles = offre.NombreEtoiles,
                        NombreDeLits = offre.NombreDeLits,
                        Prix = offre.Prix,
                        NomAgence = "Agence Francis",
                        HotelId = offre.HotelId,
                        ChambreId = offre.ChambreId
                    });
                }
            }

            return offres;
        }
    }
}